using System;

namespace DynamicProgramming.PackMethod;
/// <summary>
/// 完全背包
/// </summary>
public class CompletePacket
{
    /// <summary>
    /// 完全背包问题，二维动态
    /// </summary>
    /// <param name="weight">每种物品的重量</param>
    /// <param name="value">每种物品的价值</param>
    /// <param name="W">背包最大承重</param>
    /// <returns>返回最大可获得价值</returns>
    public int CompletePacketMethod(int[] weight, int[] value, int W)
    {
        int m = weight.Length;
        //初始化
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[W + 1];
        }
        //物品数量无限，可以重复放入
        for (int i = 1; i <= m; i++)
        {
            // 枚举背包容量
            for (int j = 0; j <= W; j++)
            {
                //当背包装不下时，取前一种物品的价值
                if (j < weight[i - 1])
                {
                    dp[i][j] = dp[i - 1][j];
                }
                //否则，取前一种物品装入背包中的最大价值与当前物品装入背包中最大价值两者中的最大值，是两种物品的选择那一样。
                //与01背包不同的是，01是当前物品选择放与不放的两种比较选择。
                //dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - weight[i - 1]] + value[i - 1]);
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - weight[i - 1]] + value[i - 1]);
                }
            }
        }
        return dp[m][W];
    }
    /// <summary>
    /// 完全背包，一维动态规划，滚动数组优化
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public int CompletePacketMethodArray(int[] weight, int[] value, int W)
    {
        if (weight.Length == 0 || value.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        int[] dp = new int[W + 1];
        //遍历每一件物品.
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];
            if (curWeight > W || curWeight <= 0)
            {
                continue;
            }
            ////正序遍历背包容量，选择前一件物品与当前物品价值较大的。
            /* 与01不同，01背包是反向递减的，物品是取放与不放的两种状态比较。每个物品只被选一次。
            for (int j = W; j > weight[i] - 1; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - weight[i]] + value[i]);
            }
            */
            for (int j = curWeight; j <= W; j++)
            {
                dp[j] = Math.Max(dp[j], dp[j - curWeight] + curValue);
            }
        }
        return dp[W];
    }

}
