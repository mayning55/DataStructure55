using System;

namespace Graph;

/// <summary>
/// 次短路径（Second Shortest Path）
/// </summary>
public class SecondShortestPath
{
    private AdjacencyHash graph;
    private int vertices;
    private int startVertex;
    private int endVertex;
    private double[] minDistance1;
    private double[] minDistance2;

    /// <summary>
    /// 次短路径
    /// </summary>
    /// <param name="graph"></param>权重（非负）图邻接哈希表
    /// <param name="s"></param>起始顶点  
    /// <param name="e"></param>目标顶点
    public SecondShortestPath(AdjacencyHash graph, int s, int e)
    {
        this.graph = graph;
        this.vertices = graph.vertices;
        this.startVertex = s;
        this.endVertex = e;
        //存储最短路径
        minDistance1 = new double[vertices];
        //存储次短路径
        minDistance2 = new double[vertices];
        SSP();
        if (minDistance2[e] == double.PositiveInfinity)
        {
            System.Console.WriteLine($"顶点{startVertex}出发到顶点{endVertex}之间不存在路径。");
        }
        else
        {
            System.Console.WriteLine($"顶点{startVertex}出发到顶点{endVertex}之间次短路径为: {minDistance2[e]} 。");
        }

    }
    /// <summary>
    /// Dijkstra优先队列算法扩展
    /// </summary>
    public void SSP()
    {
        //优先队列，存储待处理顶点及其当前最短路径权重
        PriorityQueue<int, double> pq = new PriorityQueue<int, double>();
        ///初始化最短和次短距离数组
        for (int i = 0; i < vertices; i++)
        {
            minDistance1[i] = double.PositiveInfinity;
            minDistance2[i] = double.PositiveInfinity;
        }
        //起始顶点权重为0
        minDistance1[startVertex] = 0;
        //将起始顶点加入优先队列
        pq.Enqueue(startVertex, 0);
        while (pq.Count > 0)
        {
            //取出当前权重起始顶点最近的顶点
            pq.TryDequeue(out int curVertex, out double curDist);
            //如果当前距离大于次短路径权重，跳过
            if (curDist > minDistance2[curVertex])
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
                //新的路径权重
                double newWeight = weight + curDist;
                //如果新的路径权重小于最短路径，更新最短和次短路径。，并加入优先队列
                if (newWeight < minDistance1[neighbor])
                {
                    minDistance2[neighbor] = minDistance1[neighbor];
                    minDistance1[neighbor] = newWeight;
                    pq.Enqueue(neighbor, minDistance1[neighbor]);
                }
                //如果介于最短与次短之间，更新次短路径。并加入优先队列。
                else if (minDistance1[neighbor] < newWeight && newWeight < minDistance2[neighbor])
                {
                    minDistance2[neighbor] = newWeight;
                    pq.Enqueue(neighbor, minDistance2[neighbor]);
                }
            }
        }
    }
}
