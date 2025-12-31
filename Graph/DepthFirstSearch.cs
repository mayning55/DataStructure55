using System;

namespace Graph;
/// <summary>
/// 深度优先搜索 DepthFirstSearch(DFS)
/// 从开始顶点出发，递归遍历所有顶点。
/// </summary>
public class DepthFirstSearch
{
    //邻接表图
    private readonly LinkedForwardStarGraph graph;
    //已经访问过的顶点集合
    private readonly HashSet<int> visited;

    // 构造函数，初始化图和起始顶点
    public DepthFirstSearch(LinkedForwardStarGraph graph, int startVertex)
    {
        this.graph = graph;
        this.visited = new HashSet<int>();
        DFS(startVertex);
    }

    private void DFS(int vertex)
    {
        //将当前顶点添加至已经访问过的集合
        visited.Add(vertex);
        Console.WriteLine($"访问顶点: {vertex}");
        //获取当前顶点的所有邻接边
        var edges = graph.GetAllEdges(vertex);
        // 按终点排序
        edges.Sort((a, b) => ((int)a[0]).CompareTo((int)b[0]));
        //遍历所有邻接边的终点
        foreach (var edge in edges)
        {
            int curVertex = (int)edge[0];
            //如果该终点没有被访问过，则递归访问
            if (!visited.Contains(curVertex))
            {
                DFS(curVertex);
            }
        }
    }
}
