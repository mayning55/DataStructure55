
namespace Graph;

/// <summary>
/// 拓扑排序DFS算法
/// </summary>
public class TopologicalSortingDFS
{
    //判断是否有环
    private bool hasCycle = false;
    //记录当前递归栈中的顶点
    private Stack<int> onStack = new Stack<int>();
    //记录已经访问过的顶点
    private Stack<int> visited = new Stack<int>();
    //存储拓扑排序结果
    private List<int> ints = new List<int>();
    private readonly AdjacencyHash graph;

    public TopologicalSortingDFS(AdjacencyHash graph)
    {
        this.hasCycle = false;
        this.onStack = new Stack<int>();
        this.visited = new Stack<int>();
        this.ints = new List<int>();
        this.graph = graph;
        SortingDFS();
    }
    /// <summary>
    /// 拓扑排序DFS算法
    /// </summary>
    public void SortingDFS()
    {
        //图的顶点数量
        int vertices = graph.vertices;
        //遍历所有顶点
        for (int i = 0; i < vertices; i++)
        {
            if (!visited.Contains(i))
            {
                DFS(i);
            }
        }
        //如果有环，无法进行拓扑排序
        if (hasCycle)
        {
            Console.WriteLine("图中存在环，无法进行拓扑排序。");
            return;
        }
        ints.Reverse();
        Console.WriteLine("拓扑排序结果（DFS）：");
        System.Console.WriteLine(string.Join(" -> ", ints));

    }
    /// <summary>
    /// 深度优先搜索，找出当前顶点的拓扑排序
    /// </summary>
    /// <param name="vertex"></param>
    private void DFS(int vertex)
    {
        //如果已经检测到环，直接返回
        if (hasCycle)
        {
            return;
        }
        //如果当前顶点在递归栈中，说明存在环，标记hasCycle为true并返回
        if (onStack.Contains(vertex))
        {
            hasCycle = true;
            return;
        }
        //如果当前顶点已经访问过，直接返回
        if (visited.Contains(vertex))
        {
            return;
        }
        //将当前顶点加入递归栈和已访问集合
        onStack.Push(vertex);
        visited.Push(vertex);
        //遍历该顶点的所有邻接边，进行深度优先搜索
        var edges = graph.GetAllEdges(vertex);
        foreach (var edge in edges)
        {
            int neighbor = (int)edge[0];
            DFS(neighbor);

        }
        //将当前顶点从递归栈中移除，并加入拓扑排序结果
        ints.Add(vertex);
        onStack.Pop();
    }
}
