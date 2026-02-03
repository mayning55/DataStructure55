using System;

namespace Graph;

/// <summary>
/// 拓扑排序Kahn算法
/// </summary>
public class TopologicalSortingKahn
{
    /// <summary>
    /// 拓扑排序Kahn算法
    /// </summary>
    /// <param name="graph">有向(无环)的哈希表邻接图</param>
    public void SortingKahn(AdjacencyHash graph)
    {
        int vertices = graph.vertices;
        // 统计每个顶点的入度
        int[] inDegree = new int[vertices];
        for (int i = 0; i < vertices; i++)
        {
            var edges = graph.GetAllEdges(i);
            foreach (var edge in edges)
            {
                int neighbor = (int)edge[0];
                inDegree[neighbor]++;
            }
        }
        // 将所有入度为0的顶点加入到队列中
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < vertices; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        //存储拓扑序列结果
        List<int> topoOrder = new List<int>();
        while (queue.Count > 0)
        {
            //从队列中取出最顶端的顶点
            int vertex = queue.Dequeue();
            //将该顶点加入拓扑序列
            topoOrder.Add(vertex);
            //遍历该顶点的所有邻接边，减少相邻边顶点的入度
            var edges = graph.GetAllEdges(vertex);
            foreach (var edge in edges)
            {
                //相邻边的顶点
                int neighbor = (int)edge[0];
                //减少其入度
                inDegree[neighbor]--;
                //如果相邻顶点的入度变为0，将其加入队列去。
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }
        // 如果拓扑序列topoOrder的长度不等于顶点数，说明图中存在环
        if (topoOrder.Count != vertices)
        {
            Console.WriteLine("图中存在环，无法进行拓扑排序");
        }
        else
        {
            Console.WriteLine("拓扑排序结果： " + string.Join(" -> ", topoOrder));
        }
    }

}
