using System;

namespace Graph;

/// <summary>
/// 单源最短路径（Single Source Shortest Path）
/// </summary>
public class SSSPDijkstra
{
    private AdjacencyHash graph;
    private int startVertex;
    private int vertices;
    private double[] minDistance;
    /// <summary>
    /// Dijkstra算法求单源最短路径
    /// </summary>
    /// <param name="graph">权重（非负）图邻接哈希表</param>
    /// <param name="startVertex">起始顶点,计算去往其它顶点的最短路径</param>
    public SSSPDijkstra(AdjacencyHash graph, int startVertex)
    {
        this.graph = graph;
        this.startVertex = startVertex;
        //顶点数量
        vertices = graph.vertices;
        //存储起始顶点到各顶点的最短路径权重
        minDistance = new double[vertices];
        //贪心
        //Dijkstra();
        //优先队列
        DijkstraPQ();
        //输出起始顶点到各顶点的最短路径权重
        Console.WriteLine($"Dijkstra算法计算从顶点{startVertex}出发到各顶点的最短路径权重：");
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
    /// 贪心算法计算最短路径
    /// </summary>
    public void Dijkstra()
    {
        //存储顶点是否已确定最短路径
        bool[] visited = new bool[vertices];
        //初始化距离数组
        for (int i = 0; i < vertices; i++)
        {
            minDistance[i] = double.PositiveInfinity;
            visited[i] = false;
        }
        //起始顶点距离为0
        minDistance[startVertex] = 0;
        //遍历剩下顶点的最短路径
        for (int i = 0; i < vertices - 1; i++)
        {
            double minDist = double.PositiveInfinity;
            int curVertex = -1;
            //遍历所有顶点，找到距离起始顶点最近且未访问的顶点
            for (int v = 0; v < vertices; v++)
            {
                //如果顶点未访问，且距离小于当前最小距离，
                if (!visited[v] && minDistance[v] < minDist)
                {
                    //更新最小距离和顶点索引
                    minDist = minDistance[v];
                    curVertex = v;
                }
            }
            if (curVertex == -1)
            {
                break; //所有可达顶点均已访问,剩下无法访问的，跳出循环
            }
            //标记该顶点为已确定最短路径
            visited[curVertex] = true;
            //更新与该顶点相邻的未确定最短路径顶点的距离
            var edges = graph.GetAllEdges(curVertex);
            foreach (var edge in edges)
            {
                //获取相邻顶点和边权重
                int neighbor = (int)edge[0];
                double weight = edge[1];
                //如果顶点未访问，且距离小于当前最小距离，
                if (!visited[neighbor] && minDistance[curVertex] + weight < minDistance[neighbor])
                {
                    //更新距离
                    minDistance[neighbor] = minDistance[curVertex] + weight;
                }
            }
        }
    }
    /// <summary>
    /// 使用优先队列计算最短路径
    /// </summary>
    public void DijkstraPQ()
    {
        //优先队列，存储待处理顶点及其当前最短路径权重
        PriorityQueue<int, double> pq = new PriorityQueue<int, double>();
        //初始化距离数组
        for (int i = 0; i < vertices; i++)
        {
            minDistance[i] = double.PositiveInfinity;
        }
        //起始顶点权重为0
        minDistance[startVertex] = 0;
        //将起始顶点加入优先队列
        pq.Enqueue(startVertex, 0);
        while (pq.Count > 0)
        {
            //取出当前权重起始顶点最近的顶点
            pq.TryDequeue(out int curVertex, out double curDist);
            //如果当前距离大于已知最短路径权重，跳过
            if (curDist > minDistance[curVertex])
            {
                continue;
            }
            //更新与该顶点相邻的顶点的权重
            var edges = graph.GetAllEdges(curVertex);
            foreach (var edge in edges)
            {
                //获取相邻顶点和边权重
                int neighbor = (int)edge[0];
                double weight = edge[1];
                //如果通过curVertex到达neighbor的权重更短，更新权重并加入优先队列
                if (minDistance[curVertex] + weight < minDistance[neighbor])
                {
                    minDistance[neighbor] = minDistance[curVertex] + weight;
                    pq.Enqueue(neighbor, minDistance[neighbor]);
                }
            }
        }

    }
}
