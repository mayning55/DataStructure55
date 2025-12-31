using System;

namespace Graph;
/// <summary>
/// 链式前向星图（静态邻接表）
/// </summary>
public class LinkedForwardStarGraph
{
    private int vertices;//顶点数量
    private bool directed = false;//是否为有向图
    private LFSEdgeNode[] edgeArray;//边数组
    private int[] vertexHeadIndices;//顶点出度下标数组
    private int edgeCount;//边的数量
    public LinkedForwardStarGraph(int n, bool directed = false)
    {
        if (n <= 0)
        {
            throw new ArgumentException("顶点数必须大于0", nameof(vertices));
        }
        this.vertices = n;
        this.directed = directed;
        edgeArray = new LFSEdgeNode[vertices * (vertices - 1)]; // 最多 n*(n-1) 条边
        vertexHeadIndices = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            vertexHeadIndices[i] = -1; // 初始化为 -1，表示没有边
        }
        edgeCount = 0;
    }
    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="od"></param>出度
    /// <param name="id"></param>入度
    /// <param name="weight"></param>权重，默认1.0
    public void AddEdge(int od, int id, double weight = 1.0)
    {
        //顶点是否超出边界
        ValidateVertex(od);
        ValidateVertex(id);
        //获取可用的边数组下标
        int edgeIndex = GetNextAvailableEdgeIndex();
        //边的next指向当前顶点出度的第一条出边
        LFSEdgeNode oiEdge = new LFSEdgeNode(id, vertexHeadIndices[od], weight);
        //将新边加入边数组
        edgeArray[edgeIndex] = oiEdge;
        //更新顶点出度的第一条边的下标
        vertexHeadIndices[od] = edgeIndex;
        //无向图
        if (!directed)
        {
            int reverseEdgeIndex = GetNextAvailableEdgeIndex();
            LFSEdgeNode ioEdge = new LFSEdgeNode(od, vertexHeadIndices[id], weight);
            edgeArray[reverseEdgeIndex] = ioEdge;
            vertexHeadIndices[id] = reverseEdgeIndex;
        }
    }
    /// <summary>
    /// 根据顶点下标获取边的权重
    /// </summary>
    /// <param name="od"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWeight(int od, int id)
    {
        //顶点是否超出边界
        ValidateVertex(od);
        ValidateVertex(id);
        //顶点出度的第一条边下标
        int edgeIndex = vertexHeadIndices[od];
        //遍历该顶点的所有出边，当前边的终点等于id时，返回权重
        while (edgeIndex != -1)
        {
            LFSEdgeNode edge = edgeArray[edgeIndex];
            if (edge.LFSVex == id)
            {
                return edge.Weight;
            }
            edgeIndex = edge.NextEdgeIndex;
        }
        return double.PositiveInfinity; //无穷大，表示没有边。
    }
    /// <summary>
    /// 获取某顶点的所有邻接边
    /// </summary>
    /// <param name="od"></param>
    /// <returns></returns>
    public List<double[]> GetAllEdges(int od)
    {
        //顶点是否超出边界
        ValidateVertex(od);
        List<double[]> edges = new List<double[]>();
        //顶点出度的第一条边下标
        int edgeIndex = vertexHeadIndices[od];
        //遍历该顶点的所有出边，记录终点和权重
        while (edgeIndex != -1)
        {
            LFSEdgeNode edge = edgeArray[edgeIndex];
            edges.Add(new double[] { edge.LFSVex, edge.Weight });
            edgeIndex = edge.NextEdgeIndex;
        }
        return edges;
    }
    /// <summary>
    /// 打印图的链式前向星
    /// </summary>
    public void PrintGraph()
    {
        for (int i = 0; i < vertices; i++)
        {
            Console.WriteLine($"顶点 {i} 的出边：");
            int edgeIndex = vertexHeadIndices[i];
            while (edgeIndex != -1)
            {
                LFSEdgeNode edge = edgeArray[edgeIndex];
                Console.WriteLine($"  -> (终点: {edge.LFSVex}, 权重: {edge.Weight}) ");
                edgeIndex = edge.NextEdgeIndex;
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 获取下一个可用的边数组下标
    /// </summary>
    /// <returns>可用的边下标</returns>
    private int GetNextAvailableEdgeIndex()
    {
        if (edgeCount >= edgeArray.Length)
        {
            throw new InvalidOperationException("已超过允许的最大边数。");
        }
        return edgeCount++;
    }

    /// <summary>
    /// 顶点是否超出边界
    /// </summary>
    /// <param name="x"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void ValidateVertex(int x)
    {
        if (x < 0 || x >= vertices)
        {
            throw new ArgumentOutOfRangeException(nameof(x), $"顶点下标 {x} 超出范围 [0, {vertices - 1}]");
        }
    }

}
public class LFSEdgeNode
{
    public int LFSVex;//边的终点
    public double Weight;//边的权重
    public int NextEdgeIndex;//下一条边的下标
    public LFSEdgeNode(int lfsVex, int next, double weight = 1.0)
    {
        this.LFSVex = lfsVex;
        this.Weight = weight;
        this.NextEdgeIndex = next;
    }
}

