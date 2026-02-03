using System;

namespace Graph;
/// <summary>
/// 邻接矩阵
/// </summary>
public class AdjMatrixGraph
{
    private int vertices;//顶点数
    private bool directed = false;//是否有向图

    private double[,] adjancencyMatric;//二维数组，存储图的邻接矩阵。

    public AdjMatrixGraph(int n, bool directed = false)
    {
        if (n <= 0)
        {
            throw new ArgumentException("顶点数必须大于0", nameof(vertices));
        }
        this.vertices = n;
        this.directed = directed;
        adjancencyMatric = new double[vertices, vertices];
        //初始化，将所有元素设为无穷大，表示彼此之间没有边。
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                adjancencyMatric[i, j] = double.PositiveInfinity;
            }
        }
    }
    /// <summary>
    /// 两点之间添加一条边
    /// </summary>
    /// <param name="od">有向图顶点的出度（Out Degree），无向图不指定，下同。</param>
    /// <param name="id">顶点的入度</param>
    /// <param name="weight">权重默认</param>
    public void AddEdge(int od, int id, double weight)
    {
        //顶点是否超出边界
        ValidateVertex(od);
        ValidateVertex(id);
        //有向图，出度指向入度
        if (directed)
        {
            adjancencyMatric[od, id] = weight;
        }
        //无向图
        else
        {
            adjancencyMatric[od, id] = weight;
            adjancencyMatric[id, od] = weight;
        }
    }
    /// <summary>
    /// 移除俩顶点间的边（权重）
    /// </summary>
    /// <param name="od"></param>
    /// <param name="id"></param>
    public void RemoveEdge(int od, int id)
    {
        ValidateVertex(od);
        ValidateVertex(id);
        if (directed)
        {
            adjancencyMatric[od, id] = double.PositiveInfinity;
        }
        else
        {
            adjancencyMatric[od, id] = double.PositiveInfinity;
            adjancencyMatric[id, od] = double.PositiveInfinity;
        }
    }
    /// <summary>
    /// 是否存在边
    /// </summary>
    /// <param name="od">有向图顶点的出度，无向图不指定，下同。</param>
    /// <param name="id">顶点的入度</param>
    /// <returns></returns>
    public bool HasEdge(int od, int id)
    {
        ValidateVertex(od);
        ValidateVertex(id);
        return !double.IsPositiveInfinity(GetWeight(od, id));
    }
    /// <summary>
    /// 顶点间的权重
    /// </summary>
    /// <param name="od"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public double GetWeight(int od, int id)
    {
        ValidateVertex(od);
        ValidateVertex(id);
        return adjancencyMatric[od, id];
    }

    /// <summary>
    /// 打印邻接矩阵
    /// </summary>
    public void GetMatrix()
    {
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                if (double.IsPositiveInfinity(adjancencyMatric[i, j]))
                {
                    System.Console.Write("INF" + " ");
                }
                else
                {
                    System.Console.Write($"{adjancencyMatric[i, j] + " ":F2}");
                }
            }
            System.Console.WriteLine();
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
