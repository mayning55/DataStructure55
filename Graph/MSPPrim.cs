using System;

namespace Graph;

/// <summary>
/// Prim算法求最小生成树
/// </summary>
public class MSPPrim
{
    private AdjacencyHash graph;
    private int startVertex;
    /// <summary>
    /// Prim算法最小生成树
    /// </summary>
    /// <param name="graph">无向图邻接哈希表</param>
    /// <param name="startVertex">开始顶点</param>
    public MSPPrim(AdjacencyHash graph, int startVertex)
    {
        this.graph = graph;
        this.startVertex = startVertex;
        Prim();
    }
    // public void Prim()
    // {

    //     int vertices = graph.vertices;
    //     // 存储已包含在最小生成树中的顶点
    //     HashSet<int> inMST = new HashSet<int>();
    //     // 存储每个顶点到最小生成树的最小权重边
    //     double[] minWeight = new double[vertices];
    //     // 最小生成树的总权重
    //     double weightTotal = 0;
    //     // 起始顶点的权重为0
    //     minWeight[startVertex] = 0;
    //     //初始化起点到其他顶点的权重
    //     for (int i = 0; i < vertices; i++)
    //     {
    //         if (i != startVertex)
    //         {
    //             minWeight[i] = graph.GetWeight(startVertex, i);
    //         }
    //     }
    //     //将起点加入最小生成树
    //     inMST.Add(startVertex);
    //     for (int i = 1; i < vertices; i++)
    //     {
    //         // 找到不在最小生成树中的顶点中，具有最小权重边的顶点
    //         double minEdgeWeight = double.MaxValue;
    //         int nextVertex = -1;
    //         for (int v = 0; v < vertices; v++)
    //         {
    //             if (!inMST.Contains(v) && minWeight[v] < minEdgeWeight)
    //             {
    //                 minEdgeWeight = minWeight[v];
    //                 nextVertex = v;
    //             }
    //         }
    //         // 将该顶点加入最小生成树
    //         inMST.Add(nextVertex);
    //         weightTotal += minEdgeWeight;
    //         // 更新其他顶点到最小生成树的最小权重边
    //         for (int v = 0; v < vertices; v++)
    //         {
    //             if (!inMST.Contains(v))
    //             {
    //                 double edgeWeight = graph.GetWeight(nextVertex, v);
    //                 if (edgeWeight < minWeight[v])
    //                 {
    //                     minWeight[v] = edgeWeight;
    //                 }
    //             }
    //         }
    //     }
    //     //输出最小生成树的边
    //     Console.WriteLine("最小生成树的边：");
    //     for (int i = 0; i < vertices; i++)
    //     {
    //         if (minWeight[i] != -1)
    //         {
    //             Console.WriteLine($"{minWeight[i]} - {i} 权重: {minWeight[i]}");
    //         }
    //     }
    //     Console.WriteLine($"最小生成树的总权重: {weightTotal}");
    // }
    public void Prim()
    {
        int vertices = graph.vertices;
        // 标记顶点是否已加入最小生成树
        bool[] inMST = new bool[vertices];
        // 存储每个顶点到最小生成树的最小边权重
        double[] minEdgeWeight = new double[vertices];
        // 存储最小生成树的顶点出度
        int[] od = new int[vertices];
        // 最小生成树的总权重
        double weightTotal = 0.0;

        //初始化起点到其他顶点的权重
        for (int i = 0; i < vertices; i++)
        {
            minEdgeWeight[i] = double.MaxValue;
            od[i] = -1;
        }
        //将起点加入最小生成树
        minEdgeWeight[startVertex] = 0;
        //遍历剩下的顶点
        for (int count = 0; count < vertices - 1; count++)
        {
            double minWeight = double.MaxValue;
            int min_dis = -1;
            // 找到未加入最小生成树的顶点中，具有最小边权重的顶点
            for (int v = 0; v < vertices; v++)
            {
                //如果顶点未加入最小生成树且边权重更小
                if (!inMST[v] && minEdgeWeight[v] < minWeight)
                {
                    // 更新最小边权重和对应顶点
                    minWeight = minEdgeWeight[v];
                    min_dis = v;
                }
            }
            // 将顶点u加入最小生成树
            inMST[min_dis] = true;
            // 更新与新加入顶点u相邻的顶点的边权重
            var edges = graph.GetAllEdges(min_dis);
            foreach (var edge in edges)
            {
                //相邻顶点和边权重
                int neighbor = (int)edge[0];
                double weight = edge[1];
                //如果相邻顶点未加入最小生成树且边权重更小，更新边权重和出度
                if (!inMST[neighbor] && weight < minEdgeWeight[neighbor])
                {
                    minEdgeWeight[neighbor] = weight;
                    od[neighbor] = min_dis;
                }
            }
        }

        // 输出最小生成树的边
        Console.WriteLine("最小生成树的边：");
        for (int i = 0; i < vertices; i++)
        {
            if (od[i] != -1)
            {
                weightTotal += minEdgeWeight[i];
                Console.WriteLine($"{od[i]} - {i} 权重: {minEdgeWeight[i]}");
            }
        }
        Console.WriteLine($"最小生成树的总权重: {weightTotal}");
    }
}