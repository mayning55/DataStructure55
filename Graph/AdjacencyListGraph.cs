namespace Graph;
/// <summary>
/// 邻接表图
/// </summary>
public class AdjacencyListGraph
{
    private int vertices;//顶点数量
    private bool directed = false;//是否为有向图
    private VertexNode[] adjancencyList;//邻接表数组
    public AdjacencyListGraph(int n, bool directed = false)
    {
        if (n <= 0)
        {
            throw new ArgumentException("顶点数必须大于0", nameof(vertices));
        }
        this.vertices = n;
        this.directed = directed;
        adjancencyList = new VertexNode[vertices];
        //初始化，将所有顶点结点设为null
        for (int i = 0; i < vertices; i++)
        {
            adjancencyList[i] = null;
        }
    }
    /// <summary>
    /// 添加边
    /// </summary>
    /// <param name="od">出度</param>
    /// <param name="id">入度</param>
    /// <param name="weight">权重，默认1.0</param>
    public void AddEdge(int od, int id, double weight)
    {
        //顶点是否超出边界
        ValidateVertex(od);
        ValidateVertex(id);
        //有向图添加边，出度指向入度.加入邻接链表。
        EdgeNode oiEdge = new EdgeNode(id, weight);
        // 将新边插入到顶点 od 的邻接边表头（处理 adjancencyList[od] 为 null 的情况）
        oiEdge.Next = adjancencyList[od]?.Head;
        if (adjancencyList[od] == null)
        {
            adjancencyList[od] = new VertexNode(od, oiEdge);
        }
        else
        {
            adjancencyList[od].Head = oiEdge;
        }
        //无向图
        if (!directed)
        {
            //添加id到od的边
            EdgeNode ioEdge = new EdgeNode(od, weight);
            ioEdge.Next = adjancencyList[id]?.Head;
            if (adjancencyList[id] == null)
            {
                adjancencyList[id] = new VertexNode(id, ioEdge);
            }
            else
            {
                adjancencyList[id].Head = ioEdge;
            }
        }
    }
    /// <summary>
    /// 俩顶点间的权重
    /// </summary>
    /// <param name="od"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWeight(int od, int id)
    {
        ValidateVertex(od);
        ValidateVertex(id);
        EdgeNode cur = adjancencyList[od]?.Head;
        while (cur != null)
        {
            if (cur.AdjVex == id)
            {
                return cur.Weight;
            }
            cur = cur.Next;
        }
        return double.PositiveInfinity;
    }
    /// <summary>
    /// 顶点的所有邻接边
    /// </summary>
    /// <param name="od"></param>顶点
    /// <returns></returns>
    public List<double[]> GetAllEdges(int od)
    {
        List<double[]> edges = new List<double[]>();

        EdgeNode cur = adjancencyList[od]?.Head;
        while (cur != null)
        {
            edges.Add(new double[] { cur.AdjVex, cur.Weight });
            cur = cur.Next;
        }
        return edges;
    }
    /// <summary>
    /// 打印图的邻接表
    /// </summary>
    public void PrintGraph()
    {
        for (int i = 0; i < vertices; i++)
        {
            Console.Write($"顶点 {i} 的邻接边：");
            EdgeNode cur = adjancencyList[i]?.Head;
            while (cur != null)
            {
                Console.Write($" -> (顶点: {cur.AdjVex}, 权重: {cur.Weight})");
                cur = cur.Next;
            }
            Console.WriteLine();
        }
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
/// <summary>
/// 边结点，存储终点，权重和下一条边
/// </summary>
public class EdgeNode
{
    public int AdjVex;//邻接点下标（边的终点）
    public double Weight;//边的权重（无权图默认1）
    public EdgeNode Next;//指向下一个邻接点（下一条同起点的边）

    public EdgeNode(int adjVex, double weight = 1, EdgeNode next = null)
    {
        this.AdjVex = adjVex;
        this.Weight = weight;
        this.Next = next;
    }
}
/// <summary>
/// 顶点结点：存储顶点编号与其第一条邻接边
/// </summary>
public class VertexNode
{
    private int vertex;//顶点信息
    public EdgeNode Head;//指向该顶点的第一条邻接边

    public VertexNode(int vertex, EdgeNode head = null)
    {
        this.vertex = vertex;
        this.Head = head;
    }
}

