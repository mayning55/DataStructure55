using System;
using System.Text.RegularExpressions;

namespace DynamicProgramming.PackMethod;
/// <summary>
/// 组合背包
/// </summary>
public class GroupPacket
{
    /// <summary>
    /// 组合背包，二维动态规划
    /// </summary>
    /// <param name="group_count">物品每个分组里的物品数量</param>
    /// <param name="weight">物品分组里每个物品对应的重量</param>
    /// <param name="value">物品分组里第个物品对应的价值</param>
    /// <param name="W">背包最大重量</param>
    /// <returns></returns>
    public int GroupPacketMethod(int[] groupCount, int[][] weight, int[][] value, int W)
    {
        //初始化
        int m = groupCount.Length;
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[W + 1];
        }
        //遍历每一组物品（从第1组开始）
        for (int i = 1; i <= m; i++)
        {
            // 枚举背包容量
            for (int j = 0; j <= W; j++)
            {
                //假设当前组中一个物品都不选，则最大价值等于前i-1组在容量j时的价值
                dp[i][j] = dp[i - 1][j];
                //遍历当前组里每个物品
                for (int k = 0; k < groupCount[i - 1]; k++)
                {
                    //如果当前背包容量j 大于等于当前组物品的重量
                    if (j >= weight[i - 1][k])
                    {
                        // 比较“不选该物品”与“选该物品”的价值，取较大值
                        dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - weight[i - 1][k]] + value[i - 1][k]);
                    }
                }
            }
        }
        return dp[m][W];
    }
    /// <summary>
    /// 组合背包-一维动态规划，滚动数组优化
    /// </summary>
    /// <param name="group_count"></param>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public int GroupPacketMethodArray(int[] groupCount, int[][] weight, int[][] value, int W)
    {
        if (groupCount == null || weight == null || value == null || groupCount.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = groupCount.Length;
        int[] dp = new int[W + 1];
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            //当前分组
            int count = groupCount[i];
            //从下标1开始与前一组比较 ，跳过下标0.
            if (count == 0)
            {
                continue;
            }
            //当前重量和价值分组
            int[] curWeightGroup = weight[i];
            int[] curValueGroup = value[i];
            //倒序遍历容量
            for (int j = W; j >= 0; j--)
            {
                //遍历前一组的每个物品
                for (int k = 0; k < count; k++)
                {
                    //如果当前背包容量大于等于当前组物品的重量，选择加入或者不加入，取最大值
                    int curItemWeight = curWeightGroup[k];
                    if (j >= curItemWeight)
                    {
                        dp[j] = Math.Max(dp[j], dp[j - curItemWeight] + curValueGroup[k]);
                    }
                }
            }
        }
        return dp[W];
    }

}
