using System;
using System.Linq.Expressions;

namespace Graph;

/// <summary>
/// 多源最短路径（All-Pairs Shortest Paths）
/// </summary>
public class FloydWarshall
{
    private AdjacencyHash graph;
    private int vertices;
    private double[,] minDistance;

    /// <summary>
    /// Floyd-Warshall算法计算所有顶点对之间的最短路径
    /// </summary>
    /// <param name="graph">权重图邻接哈希表</param>
    /// <param name="od">出度与入度默认-1时，打印顶点间矩阵</param>
    /// <param name="id"></param>
    public FloydWarshall(AdjacencyHash graph, int od = -1, int id = -1)
    {
        this.graph = graph;
        //顶点数量
        vertices = graph.vertices;
        //初始化距离矩阵
        minDistance = new double[vertices, vertices];
        FloydWarshallAllPairs();
        if (od != -1 && id != -1)
        {
            //俩顶点间最短路径
            if (minDistance[od, id] == double.PositiveInfinity)
            {
                System.Console.WriteLine($"顶点{od}到顶点{id}间不可达");
            }
            else if (od == id)
            {
                System.Console.WriteLine($"同一顶点");
            }
            else
            {
                System.Console.WriteLine($"顶点{od}到顶点{id}间最短路径权重：" + minDistance[od, id]);
            }
        }
        else
        {
            //输出所有顶点对之间的最短路径权重
            Console.WriteLine("Floyd-Warshall算法计算顶点对之间的最短路径权重：");
            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (minDistance[i, j] == double.PositiveInfinity)
                    {
                        Console.Write(double.PositiveInfinity.ToString().PadLeft(8));
                    }
                    else
                    {
                        Console.Write(minDistance[i, j].ToString().PadLeft(8));
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public void FloydWarshallAllPairs()
    {
        //初始化距离矩阵
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                //自身到自身距离为0
                if (i == j)
                {
                    minDistance[i, j] = 0;
                }
                //否则若俩顶点间可达，距离为边权重。不可达侧为无穷大。
                else
                {
                    double weight = graph.GetWeight(i, j);
                    minDistance[i, j] = weight == double.PositiveInfinity ? double.PositiveInfinity : weight;
                }
            }
        }
        //三重循环，更新距离矩阵，枚举所有中间顶点k
        for (int k = 0; k < vertices; k++)
        {
            for (int i = 0; i < vertices; i++)
            {
                //不可达的中间顶点跳过
                if (minDistance[i, k] == double.PositiveInfinity)
                {
                    continue;
                }
                for (int j = 0; j < vertices; j++)
                {
                    //三点间均可达。若通过k点路径更短，更新距离
                    if (minDistance[i, k] != double.PositiveInfinity && minDistance[k, j] != double.PositiveInfinity)
                    {
                        double newDist = minDistance[i, k] + minDistance[k, j];
                        if (newDist < minDistance[i, j])
                        {
                            minDistance[i, j] = newDist;
                        }
                    }
                }
            }
        }
    }

}
