using System;

namespace DynamicProgramming.PackMethod;
/// <summary>
/// 0-1背包
/// </summary>
public class ZeroOnePacket
{
    /// <summary>
    /// 0-1背包问题，二维动态规划
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="value"></param>每种物品的价值
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>返回最大可获得价值
    public int ZeroOnePacketMethod(int[] weight, int[] value, int W)
    {
        int m = weight.Length;
        //初始化
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[W + 1];
        }
        //遍历每一种物品
        for (int i = 1; i <= m; i++)
        {
            // 放或者不放的背包容量
            for (int j = 0; j <= W; j++)
            {
                //背包满了，不放，状态不变
                if (j < weight[i - 1])
                {
                    dp[i][j] = dp[i - 1][j];
                }
                //当前物品选择放入还是不放入，取两状态的价值的最大值。
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 1][j - weight[i - 1]] + value[i - 1]);
                }

            }
        }
        return dp[m][W];
    }
    /// <summary>
    /// 0-1背包问题，一维动态规划，滚动数组优化
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public int ZeroOnePacketMethodArray(int[] weight, int[] value, int W)
    {
        if (weight.Length == 0 || value.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        int[] dp = new int[W + 1];
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            //倒序遍历容量，选择不放时，状态不变。放，容量减少，价值增加。确保每个物品只被选一次
            for (int j = W; j >= weight[i]; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - weight[i]] + value[i]);
            }
        }
        return dp[W];
    }
    /// <summary>
    /// 分割子数组和相等，0-1背包问题，一维动态规划，滚动数组优化
    /// </summary>
    /// <param name="nums"></param>正整数的非空数组
    /// <returns></returns>判断是否可以将这个数组分成两个子集，使得两个子集的元素和相等。

    public bool CanPartition(int[] nums)
    {
        int total = nums.Sum();
        if (total % 2 != 0)
        {
            return false;
        }
        int half = total / 2;
        return ZeroOnePacketMethodArray(nums, nums, half) == half;
    }
}
