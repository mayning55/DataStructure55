using Tree;

namespace Graph;

public class MSPKruskal
{
    private AdjacencyHash graph;

    /// <summary>
    /// Kruskal算法最小生成树
    /// </summary>
    /// <param name="graph">无向图邻接哈希表</param>
    public MSPKruskal(AdjacencyHash graph)
    {
        this.graph = graph;
        Kruskal();
    }
    public void Kruskal()
    {
        //顶点数量
        int vertices = graph.vertices;
        //存储最小生成树的边
        List<double[]> minEdges = new List<double[]>();
        //获取所有边
        List<double[]> edges = new List<double[]>();
        for (int i = 0; i < vertices; i++)
        {
            edges.AddRange(graph.GetAllEdges(i).Select(e => new double[] { i, e[0], e[1] }));
        }
        //按权重从小到大排序边
        edges.Sort((edge1, edge2) => edge1[2].CompareTo(edge2[2]));
        //初始化并查集
        Tree.UnionFind union_find = new Tree.UnionFind(vertices);
        double totalWeight = 0;
        //加入边到最小生成树，直到有n-1条边
        int edgeCount = 0;
        //遍历排序后的边
        foreach (var edge in edges)
        {
            //获取边的两个顶点
            int od = (int)edge[0];
            int id = (int)edge[1];
            //如果边的两个顶点od和id不在同一集合中，则加入该边
            if (union_find.Find(od) != union_find.Find(id))
            {
                union_find.Union(od, id);
                edgeCount++;
                minEdges.Add(edge);
                //如果已经加入了n-1条边，停止
                if (edgeCount == vertices - 1)
                {
                    break;
                }
            }
        }
        //输出最小生成树的边和总权重
        System.Console.WriteLine("Kruskal算法最小生成树的边如下：");
        for (int i = 0; i < edgeCount; i++)
        {
            totalWeight += minEdges[i][2];
            System.Console.WriteLine($"{minEdges[i][0]} - {minEdges[i][1]}" + $" 权重：{minEdges[i][2]}");
        }
        System.Console.WriteLine("Kruskal算法最小生成树的总权重为：" + totalWeight);
    }

}

