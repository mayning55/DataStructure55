using System;

namespace Graph;
/// <summary>
/// 邻接哈希图
/// </summary>
public class AdjacencyHash
{
    public int vertices; // 顶点数量
    private bool directed = false; // 是否为有向图
    /// <summary>
    /// 邻接哈希表
    /// 使用字典存储邻接表，键为顶点编号，值为邻接边字典
    /// 邻接边字典：键为相邻顶点编号，值为边权重
    /// </summary>
    private Dictionary<int, Dictionary<int, double>> adjacencyHash;

    public AdjacencyHash(int n, bool directed = false)
    {
        if (n <= 0)
        {
            throw new ArgumentException("顶点数必须大于0", nameof(vertices));
        }
        this.vertices = n;
        this.directed = directed;
        adjacencyHash = new Dictionary<int, Dictionary<int, double>>();
        // 初始化邻接哈希表
        for (int i = 0; i < vertices; i++)
        {
            adjacencyHash[i] = new Dictionary<int, double>();
        }
    }
    /// <summary>
    ///  添加边
    /// </summary>
    /// <param name="od">出度</param>
    /// <param name="id">入度</param>
    /// <param name="weight">权重，默认1.0</param>
    public void AddEdge(int od, int id, double weight = 1.0)
    {
        // 顶点是否超出边界
        ValidateVertex(od);
        ValidateVertex(id);
        // 添加边到邻接哈希表
        adjacencyHash[od][id] = weight;
        // 如果是无向图，添加反向边
        if (!directed)
        {
            adjacencyHash[id][od] = weight;
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
        if (adjacencyHash[od].TryGetValue(id, out double weight))
        {
            return weight;
        }
        else
        {
            return double.PositiveInfinity; // 如果边不存在，返回正无穷大
        }
    }
    /// <summary>
    /// 顶点的所有邻接边
    /// </summary>
    /// <param name="od"></param>
    /// <returns></returns>
    public List<double[]> GetAllEdges(int od)
    {
        ValidateVertex(od);
        List<double[]> edges = new List<double[]>();
        foreach (var kvp in adjacencyHash[od])
        {
            edges.Add(new double[] { kvp.Key, kvp.Value });
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
            foreach (var kvp in adjacencyHash[i])
            {
                Console.Write($"(到顶点 {kvp.Key}, 权重 {kvp.Value}) ");
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
