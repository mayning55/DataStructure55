using System;

namespace Graph;

/// <summary>
/// 单源最短路径（Single Source Shortest Path）
/// </summary>
public class SSSPBellmanFord
{
    private AdjacencyHash graph;
    private int startVertex;
    private int vertices;
    private double[] minDistance;

    /// <summary>
    /// BellmanFord负权重边的单源最短路径算法
    /// </summary>
    /// <param name="graph"></param>权重（负）图邻接哈希表
    /// <param name="startVertex"></param>起始顶点,计算去往其它顶点的最短路径
    public SSSPBellmanFord(AdjacencyHash graph, int startVertex)
    {
        this.graph = graph;
        this.startVertex = startVertex;
        //顶点数量
        vertices = graph.vertices;
        //存储起始顶点到各顶点的最短路径权重
        minDistance = new double[vertices];
        //使用队列优化的Bellman-Ford算法
        BellmanFordPQ();
        //传统朴素的BellmanFord算法
        //BellmanFord();
        //输出起始顶点到各顶点的最短路径权重
        Console.WriteLine($"Bellman-Ford算法计算从顶点{startVertex}出发到各顶点的最短路径权重：");
        for (int i = 0; i < vertices; i++)
        {
            if (minDistance[i] == double.PositiveInfinity)
            {
                Console.WriteLine($"到顶点{i}不可达");
                continue;
            }
            if (i == startVertex)
            {
                Console.WriteLine($"起始顶点是自己。");
                continue;
            }
            Console.WriteLine($"到顶点{i}的最短路径权重为: {minDistance[i]}");
        }
    }
    /// <summary>
    /// Bellman-Ford算法计算单源最短路径
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>

    public void BellmanFord()
    {
        //初始化距离数组,所有点距离设为无穷大
        for (int i = 0; i < vertices; i++)
        {
            minDistance[i] = double.PositiveInfinity;
        }
        //起始顶点距离为0
        minDistance[startVertex] = 0;

        //遍历剩下顶点进行松弛操作，重复V-1次
        for (int i = 1; i <= vertices - 1; i++)
        {
            //记录是否有更新
            bool isUpdated = false;
            //遍历顶点的所有边
            for (int u = 0; u < vertices; u++)
            {
                var edges = graph.GetAllEdges(u);
                foreach (var edge in edges)
                {
                    int neighbor = (int)edge[0];
                    double weight = edge[1];
                    //如果相邻顶点可达，且到neighbor的路径更短，更新距离
                    if (minDistance[u] != double.PositiveInfinity && minDistance[u] + weight < minDistance[neighbor])
                    {
                        minDistance[neighbor] = minDistance[u] + weight;
                        isUpdated = true;
                    }
                }
            }
            //如果没有更新，表示已经收敛，提前结束。
            if (isUpdated == false)
            {
                break;
            }
        }

        //检测负权重环
        for (int u = 0; u < vertices; u++)
        {
            var edges = graph.GetAllEdges(u);
            foreach (var edge in edges)
            {
                int neighbor = (int)edge[0];
                double weight = edge[1];
                if (minDistance[u] != double.PositiveInfinity && minDistance[u] + weight < minDistance[neighbor])
                {
                    throw new InvalidOperationException("图中存在负权重环，无法计算最短路径");
                }
            }
        }
    }

    /// <summary>
    /// 使用队列计算
    /// </summary>
    public void BellmanFordPQ()
    {
        //队列，存储待处理的节点
        Queue<int> pq = new Queue<int>();
        //记录顶点是否在队列中，避免重复。
        bool[] inQueue = new bool[vertices];
        //进入队列的次数。检测负权重环
        int[] inQueueCount = new int[vertices];
        //初始化距离数组
        for (int i = 0; i < vertices; i++)
        {
            minDistance[i] = double.PositiveInfinity;
            inQueue[i] = false;
        }
        //起始顶点距离为0
        minDistance[startVertex] = 0;
        //将起始顶点加入队列
        pq.Enqueue(startVertex);
        //标记起始顶点在队列中，次数+1
        inQueue[startVertex] = true;
        inQueueCount[startVertex] = 1;
        while (pq.Count > 0)
        {
            //出队列
            int u = pq.Dequeue();
            inQueue[u] = false;
            //遍历顶点的所有边
            var edges = graph.GetAllEdges(u);
            foreach (var edge in edges)
            {
                int neighbor = (int)edge[0];
                double weight = edge[1];
                //如果相邻顶点可达，且到neighbor的路径更短，更新距离
                if (minDistance[u] != double.PositiveInfinity && minDistance[u] + weight < minDistance[neighbor])
                {
                    minDistance[neighbor] = minDistance[u] + weight;
                    //如果邻接点不在队列中，加入队列
                    if (!inQueue[neighbor])
                    {
                        pq.Enqueue(neighbor);
                        inQueue[neighbor] = true;
                        inQueueCount[neighbor]++;
                        //如果某个顶点入队次数超过顶点数，说明存在负权重环
                        if (inQueueCount[neighbor] > vertices)
                        {
                            throw new InvalidOperationException("图中存在负权重环，无法计算最短路径");
                        }
                    }
                }
            }
        }
    }

}
