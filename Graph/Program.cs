namespace Graph;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");

        /*
        邻接矩阵图
        */
        //AdjMatrixGraph amg = new AdjMatrixGraph(4);
        // AdjMatrixGraph amg = new AdjMatrixGraph(4, true);
        // amg.AddEdge(0, 1, 5.5);
        // amg.AddEdge(1, 3, 10);
        // Console.WriteLine(amg.HasEdge(1, 3));
        // Console.WriteLine(amg.HasEdge(1, 2));
        // Console.WriteLine(amg.GetWeight(1, 2));
        // Console.WriteLine(amg.GetWeight(1, 3));
        // amg.GetMatrix();
        // amg.RemoveEdge(0, 1);
        // amg.GetMatrix();
        /*
        邻接表连接图
        */
        // AdjacencyListGraph alg = new AdjacencyListGraph(4, true);
        // alg.AddEdge(1, 3, 2.55);
        // alg.AddEdge(1, 2, 4.5);
        // System.Console.WriteLine(alg.GetWeight(1, 3));
        // System.Console.WriteLine(alg.GetWeight(2, 3));
        // var edges = alg.GetAllEdges(1);
        // foreach (var edge in edges)
        // {
        //     System.Console.WriteLine($"顶点1的邻接边：到顶点{edge[0]}，权重为{edge[1]}");
        // }
        // alg.PrintGraph();
        /*
        链式前向星图（静态邻接表）
        */
        // LinkedForwardStarGraph lfs = new LinkedForwardStarGraph(4, true);
        // lfs.AddEdge(1, 3, 2.55);
        // lfs.AddEdge(0, 1, 1.5);
        // lfs.AddEdge(1, 2, 4.5);
        // System.Console.WriteLine(lfs.GetWeight(1, 3));
        // System.Console.WriteLine(lfs.GetWeight(2, 3));
        // var edges = lfs.GetAllEdges(1);
        // foreach (var edge in edges)
        // {
        //     System.Console.WriteLine($"顶点1的邻接边：到顶点{edge[0]}，权重为{edge[1]}");
        // }
        // lfs.PrintGraph();
        /*
        邻接哈希图
        */
        AdjacencyHash ahg = new AdjacencyHash(8,true);
        ahg.AddEdge(0, 1, 5.0);
        ahg.AddEdge(0, 2, 20.0);
        ahg.AddEdge(0, 4, 18.0);
        ahg.AddEdge(1, 3, 39.0);
        ahg.AddEdge(2, 3, 8.0);
        ahg.AddEdge(4, 5, 52.0);
        ahg.AddEdge(3, 5, 16.0);
        ahg.AddEdge(6, 7, 100.0);
        // System.Console.WriteLine(ahg.GetWeight(1, 3));
        // System.Console.WriteLine(ahg.GetWeight(2, 3));
        //ahg.PrintGraph();
        /*
        深度优先搜索 DepthFirstSearch(DFS)
        */
        // LinkedForwardStarGraph lfs = new LinkedForwardStarGraph(9, true);
        // lfs.AddEdge(3, 4);
        // lfs.AddEdge(1, 4);
        // lfs.AddEdge(2, 6);
        // lfs.AddEdge(2, 7);
        // lfs.AddEdge(7, 8);
        // lfs.AddEdge(0, 1);
        // lfs.AddEdge(0, 2);
        // lfs.AddEdge(1, 3);
        // lfs.AddEdge(1, 5);

        // lfs.PrintGraph();
        // System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        // DepthFirstSearch dfs = new DepthFirstSearch(lfs, 1);
        /*
        广度优先搜索 BreadthFirstSearch(BFS)
        */
        // LinkedForwardStarGraph lfs = new LinkedForwardStarGraph(9);
        // lfs.AddEdge(0, 1);
        // lfs.AddEdge(0, 2);
        // lfs.AddEdge(1, 3);
        // lfs.AddEdge(2, 3);
        // lfs.AddEdge(2, 4);
        // lfs.AddEdge(3, 5);
        // BreadthFirstSearch bfs = new BreadthFirstSearch(lfs, 0);
        /*
        * 拓扑排序 Kahn算法
        */
        // TopologicalSortingKahn tsk = new TopologicalSortingKahn();
        // tsk.SortingKahn(ahg);
        /*
        * 拓扑排序 DFS算法
        */
        //TopologicalSortingDFS tsd = new TopologicalSortingDFS(ahg);

        /*
        最小生成树 Prim算法
        */
        //MSPPrim msp = new MSPPrim(ahg, 0);
        /*
        最小生成树 Kruskal算法
        */
        //MSPKruskal msk = new MSPKruskal(ahg);
        /*
        单源最短路径 Dijkstra算法
        */
        //SSSPDijkstra ssspd = new SSSPDijkstra(ahg, 6);
        /*
        单源最短路径 Bellman-Ford算法
        */
        // AdjacencyHash ahgBF = new AdjacencyHash(5, true);
        // ahgBF.AddEdge(0, 1, 3);
        // ahgBF.AddEdge(1, 2, 2);
        // ahgBF.AddEdge(0, 2, -1);
        // ahgBF.AddEdge(1, 3, 7);
        // ahgBF.AddEdge(1, 4, 1);
        // ahgBF.AddEdge(2, 4, 2);
        // ahgBF.AddEdge(3, 4, 5);
        // SSSPDijkstra ssspd = new SSSPDijkstra(ahgBF, 0);
        // SSSPBellmanFord ssspb = new SSSPBellmanFord(ahgBF, 0);

        /*
        多源最短路径 FloydWarshall
        */
        //FloydWarshall fw = new FloydWarshall(ahg, 1, 2);
        /*
        多源最短路径 Johnson
        */
        //Johnson js = new Johnson(ahg, 1, 2);
        /*
        次短路径
        */
        SecondShortestPath ssp = new SecondShortestPath(ahg, 0, 3);

    }
}
