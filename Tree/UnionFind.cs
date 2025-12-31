using System;

namespace Tree;

/// <summary>
/// 基于数组实现的并查集
/// </summary>
public class UnionFind
{
    //存储每个节点的父节点
    private readonly int[] parent;
    //树的秩（高度或深度的一个上界）
    private readonly int[] rank;
    public UnionFind(int m)
    {
        if (m <= 0)
        {
            throw new ArgumentException("Size must be positive.");
        }
        //初始化：每个元素的父节点是它自己,秩为 0
        parent = new int[m];
        rank = new int[m];
        for (int i = 0; i < m; i++)
        {
            parent[i] = i;
            rank[i] = 0;
        }
    }
    /// <summary>
    /// 查找元素 x 所在集合的根节点（代表元素）。
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int Find(int x)
    {
        //数组结构实现，返回在集合中自己的下标（查询快，但合并慢）
        //return parent[x];
        //森林结构，循环查找父节点，直到找到根节点
        // while(parent[x]!=x)
        // {
        //     x=parent[x];
        // }
        //return x;
        //路径压缩-隔代压缩,每次将当前节点直接连接到其父节点的父节点（即跳过一层）
        // while(parent[x]!=x)
        // {
        //     parent[x]=parent[parent[x]];
        //     x=parent[x];
        // }
        // return x;
        //路径压缩-完全压缩,将从当前节点到根节点路径上的所有节点的父节点都直接指向根节点
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];

    }
    /// <summary>
    /// 合并元素 x 和元素 y 所在的集合,按秩合并优化
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void Union(int x, int y)
    {
        int indexX = Find(x);
        int indexY = Find(y);
        if (indexX == indexY)
        {
            return;
        }
        // 按秩合并：将秩较小的树合并到秩较大的树上
        if (rank[indexX] < rank[indexY])
        {
            parent[indexX] = indexY;
        }
        else if (rank[indexX] > rank[indexY])
        {
            parent[indexY] = indexX;
        }
        // 如果秩相等，选择任意一个作为新的根，并增加其秩
        else
        {
            parent[indexY] = indexX;
            rank[indexX]++;
        }
    }
    /// <summary>
    /// 判断两个元素是否在同一个集合中
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool Connected(int x, int y)
    {
        return Find(x) == Find(y);
    }
}
