using System;

namespace Tree;
/// <summary>
/// 树状数组
/// </summary>
public class BinaryIndexedTree
{
    private int m;//数组的大小
    private int[] tree;//存储树状数组的数组
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="m"></param>
    public BinaryIndexedTree(int m)
    {
        this.m = m;
        // 树状数组索引从1开始，所以大小要+1
        this.tree = new int[m + 1];
    }
    /// <summary>
    /// 低位计算
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int LowBit(int x)
    {
        return x & -x;
    }
    /// <summary>
    /// 单点更新
    /// </summary>
    /// <param name="index"></param>数组元素下标（从1开始）
    /// <param name="val"></param>元素增加的值（可以为负数）
    public void Update(int index, int val)
    {
        for (int i = index; i <= m; i += LowBit(i))
        {
            tree[i] += val;
        }
    }
    public void UpdateRange(int left, int right, int val)
    {
        Update(left, val);
        Update(right + 1, -val);
    }
    /// <summary>
    /// 统计前辍和
    /// </summary>
    /// <param name="index"></param>从第一个元素到下标的元素
    /// <returns></returns>
    public int Query(int index)
    {
        int sum = 0;
        for (int i = index; i > 0; i -= LowBit(i))
        {
            sum += tree[i];
        }
        return sum;
    }
    public int QueryRange(int left, int right)
    {
        //超出边界了。
        if (left > right || left < 1 || right > m)
        {
            throw new ArgumentOutOfRangeException("Invalid range.");
        }
        // 区间和 = 右边前缀和 - 左边前缀和
        return Query(right) - Query(left - 1);
    }

}
