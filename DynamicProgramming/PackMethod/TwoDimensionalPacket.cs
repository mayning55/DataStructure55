using System;

namespace DynamicProgramming.PackMethod;

/// <summary>
/// 二维费用背包
/// </summary>
public class TwoDimensionalPacket
{
    /// <summary>
    /// 二维费用背包，数组滚动优化
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="volume"></param>每种物品的体积
    /// <param name="value"></param>每种物品的价值
    /// <param name="W"></param>背包最大承重
    /// <param name="V"></param>背包最大体积
    /// <returns></returns>返回最大可获得价值
    public int TwoDimensionalPacketArray(int[] weight, int[] volume, int[] value, int W, int V)
    {
        if (weight == null || volume == null || value == null || weight.Length == 0 || W <= 0 || V <= 0)
        {
            return 0;
        }
        //初始化,二维数组
        int m = weight.Length;
        int[][] dp = new int[W + 1][];
        for (int i = 0; i < W + 1; i++)
        {
            dp[i] = new int[V + 1];
        }
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curVolume = volume[i];
            int curValue = value[i];

            if (curWeight > W || curVolume > V || curWeight <= 0 || curVolume <= 0)
            {
                continue;
            }
            //倒序遍历重量,0-1 背包（每个物品只能选一次）
            for (int j = W; j >= curWeight; j--)
            {
                //倒序遍历体积
                for (int k = V; k >= curVolume; k--)
                {
                    // 选项1：不放入当前物品，价值为 dp[j][k]
                    // 选项2：放入当前物品，价值为 剩余空间(j-curWeight, k-curVolume)的最大价值 + 当前物品价值
                    dp[j][k] = Math.Max(dp[j][k], dp[j - curWeight][k - curVolume] + curValue);
                }
            }
        }
        return dp[W][V];
    }
}
