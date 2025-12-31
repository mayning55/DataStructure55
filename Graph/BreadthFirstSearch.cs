using System;

namespace Graph;

/// <summary>
/// 广度优先搜索 BreadthFirstSearch(BFS)
/// 从开始顶点出发，按层次遍历所有顶点。
/// </summary>
public class BreadthFirstSearch
{
    //邻接表图
    private readonly LinkedForwardStarGraph graph;
    //已经访问过的顶点集合
    private readonly HashSet<int> visited;
    //将队列头部的顶点的所有邻接点加入队列
    private readonly Queue<int> queue;
    /// <summary>
    /// 构造函数，初始化图和起始顶点
    /// </summary>
    /// <param name="graph"></param>
    /// <param name="startVertex"></param>
    public BreadthFirstSearch(LinkedForwardStarGraph graph, int startVertex)
    {
        this.graph = graph;
        this.visited = new HashSet<int>();
        this.queue = new Queue<int>();
        //将当前顶点加入已访问集合和队列
        visited.Add(startVertex);
        queue.Enqueue(startVertex);
        //开始广度优先搜索
        while (queue.Count > 0)
        {
            //当前顶点为队列头部顶点
            int curVertex = queue.Dequeue();
            Console.WriteLine($"访问顶点: {curVertex}");
            //获取当前顶点的所有邻接边
            var edges = graph.GetAllEdges(curVertex);
            edges.Sort((a, b) => ((int)a[0]).CompareTo((int)b[0]));
            foreach (var edge in edges)
            {
                int vertex = (int)edge[0];
                //如果该终点没有被访问过，则加入已访问集合和队列
                if (!visited.Contains(vertex))
                {
                    visited.Add(vertex);
                    queue.Enqueue(vertex);
                }
            }
        }
    }

}
