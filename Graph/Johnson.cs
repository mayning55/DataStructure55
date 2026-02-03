using System;
using System.Text.Json.Nodes;
using Microsoft.VisualBasic;

namespace Graph;
/// <summary>
/// 多源最短路径（All-Pairs Shortest Paths）
/// </summary>
public class Johnson
{
    private AdjacencyHash graph;
    private int vertices;
    private double[,] minDistance;

    /// <summary>
    /// Johnson算法计算所有顶点对之间的最短路径
    /// </summary>
    /// <param name="graph">权重图邻接哈希表</param>
    /// <param name="od">出度与入度默认-1时，打印顶点间矩阵</param>
    /// <param name="id"></param>
    public Johnson(AdjacencyHash graph, int od = -1, int id = -1)
    {
        this.graph = graph;
        //顶点数量
        vertices = graph.vertices;
        //距离矩阵
        minDistance = new double[vertices, vertices];
        JohnsonAllPairs();
        if (od != -1 && id != -1)
        {
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
            Console.WriteLine("Johnson算法计算顶点对之间的最短路径权重：");
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
    public void JohnsonAllPairs()
    {
        //构建一张新的图，增加顶点 s 到其它顶点的边，权重为0,
        AdjacencyHash newGraph = new AdjacencyHash(vertices);
        //保存以s为出度到其它顶点入度的最短权重。
        double[] newGraphDistance = new double[vertices];
        for (int u = 0; u < vertices; u++)
        {
            newGraphDistance[u] = double.PositiveInfinity;
            //权重为0的边
            newGraph.AddEdge(vertices - 1, u, 0);
        }
        /*
        BellmanFord 算法计算权重
        */
        //起始顶点权重为0
        newGraphDistance[vertices - 1] = 0;
        //遍历剩下顶点进行松弛操作，重复V-1次
        for (int i = 1; i <= vertices - 1; i++)
        {
            //记录是否有更新
            bool isUpdated = false;
            //遍历顶点的所有边
            for (int u = 0; u < vertices; u++)
            {
                var newedges = newGraph.GetAllEdges(u);
                foreach (var newedge in newedges)
                {
                    int neighbor = (int)newedge[0];
                    double weight = newedge[1];
                    //如果相邻顶点可达，且到neighbor的路径更短，更新权重
                    if (newGraphDistance[u] != double.PositiveInfinity && newGraphDistance[u] + weight < newGraphDistance[neighbor])
                    {
                        newGraphDistance[neighbor] = newGraphDistance[u] + weight;
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
            var newedges = newGraph.GetAllEdges(u);
            foreach (var edge in newedges)
            {
                int neighbor = (int)edge[0];
                double weight = edge[1];
                if (newGraphDistance[u] != double.PositiveInfinity && newGraphDistance[u] + weight < newGraphDistance[neighbor])
                {
                    throw new InvalidOperationException("图中存在负权重环，无法计算最短路径");
                }
            }

        }
        /*
        调整权重为w′(u,v)=w(u,v)+h(u)−h(v)
        */
        AdjacencyHash newGraphweigth = new AdjacencyHash(vertices);
        for (int u = 0; u < vertices; u++)
        {
            //原图的所有边
            var edges = graph.GetAllEdges(u);
            //原图所有边的相邻边
            foreach (var edge in edges)
            {
                int id = (int)edge[0];
                double weight = edge[1];
                //新的权重=原权重+新图出度最短权重-新图入度的最短权重
                double newWeight = weight + newGraphDistance[u] - newGraphDistance[id];
                //加入新的权重图
                newGraphweigth.AddEdge(u, id, newWeight);
            }
        }
        /*
        DijkstraPQ还原原图的权重
        */
        //初始化最短路径权重
        for (int i = 0; i < vertices; i++)
        {
            for (int j = 0; j < vertices; j++)
            {
                minDistance[i, j] = double.PositiveInfinity;
            }
        }
        //优先队列，存储待处理顶点及其当前最短路径权重
        PriorityQueue<int, double> pq = new PriorityQueue<int, double>();

        for (int j = 0; j < vertices; j++)
        {
            ////初始化距离数组和记录是否访问过
            double[] dist = new double[vertices];
            bool[] visited = new bool[vertices];
            for (int k = 0; k < vertices; k++)
            {
                dist[k] = double.PositiveInfinity;
                visited[k] = false;
            }
            ////起始顶点权重为0
            dist[j] = 0;
            ////将起始顶点加入优先队列
            pq.Enqueue(j, 0);
            while (pq.Count > 0)
            {
                ////取出当前权重起始顶点最近的顶点
                pq.TryDequeue(out int curVertex, out double curDist);
                //如果已经访问过，跳过
                if (visited[curVertex])
                {
                    continue;
                }
                //记录为已经访问
                visited[curVertex] = true;
                //更新与该顶点相邻的顶点的权重
                var edges = newGraphweigth.GetAllEdges(curVertex);
                foreach (var edge in edges)
                {
                    int neighbor = (int)edge[0];
                    double weight = edge[1];
                    ////如果通过curVertex到达neighbor的权重更短，更新权重并加入优先队列
                    if (dist[neighbor] > curDist + weight)
                    {
                        dist[neighbor] = curDist + weight;
                        pq.Enqueue(neighbor, dist[neighbor]);
                    }
                }
            }
            //还原原图权重。
            for (int i = 0; i < vertices; i++)
            {
                if (dist[i] != double.PositiveInfinity)
                {
                    minDistance[j, i] = dist[i] - newGraphDistance[j] + newGraphDistance[i];
                }
            }
        }
    }

}
