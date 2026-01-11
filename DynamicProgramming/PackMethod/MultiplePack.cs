using System;

namespace DynamicProgramming.PackMethod;
/// <summary>
/// 多重背包
/// </summary>
public class MultiplePacket
{
    /// <summary>
    /// 多重背包，二维动态规划
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="value"></param>每种物品的价值
    /// <param name="count"></param>每种物品的数量上限
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>返回最大可获得价值
    public int MultiplePacketMethod(int[] weight, int[] value, int[] count, int W)
    {
        int m = weight.Length;
        //初始化
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[W + 1];
        }
        //外层遍历每一种物品
        for (int i = 1; i <= m; i++)
        {
            // 中层枚举背包容量
            for (int j = 0; j <= W; j++)
            {
                //前一种物品最多可以能够加入的数量，取决于物品种类的数量和是否超过总重量
                int num = Math.Min(count[i - 1], j / weight[i - 1]) + 1;
                //内层，前一种物品可以放入多少。
                for (int k = 0; k < num; k++)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - k * weight[i - 1]] + k * value[i - 1]);
                }
            }
        }
        return dp[m][W];
    }
    /// <summary>
    /// 多重背包问题，一维动态规划，滚动数组优化
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public int MultiplePacketMethodArray(int[] weight, int[] value, int[] count, int W)
    {
        if (weight == null || value == null || count == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        int[] dp = new int[W + 1];
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];
            int curCount = count[i];
            if (curWeight > W || curWeight <= 0)
            {
                continue;
            }
            //倒序遍历背包容量
            for (int j = W; j >= curWeight; j--)
            {
                //当前容量最多能放多少个该物品
                int maxCount = Math.Min(curCount, j / curWeight);
                //遍历物品数量可以放入多少。
                for (int k = 1; k <= maxCount; k++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - k * curWeight] + k * curValue);
                }
            }
        }
        return dp[W];
    }
    /// <summary>
    /// 二进制优化
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="count"></param>
    /// <param name="W"></param>
    /// <returns></returns>

    public int MultiplePacketMethodBit(int[] weight, int[] value, int[] count, int W)
    {
        if (weight == null || value == null || count == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        //存储拆分后的物品分组
        List<int> newWeight = new List<int>();
        List<int> newValue = new List<int>();
        //二进制分组
        /*
        二进制分组
        2=1+1；5=1+2+2；3=1+2；10=1+2+4+3；20=1+2+4+8+5
        */
        for (int i = 0; i < m; i++)
        {
            int cnt = count[i];
            int k = 1;
            while (k <= cnt)
            {
                cnt -= k;
                newWeight.Add(weight[i] * k);
                newValue.Add(value[i] * k);
                k *= 2;
            }
            //处理余下的。
            if (cnt > 0)
            {
                newWeight.Add(weight[i] * cnt);
                newValue.Add(value[i] * cnt);
            }
        }
        //二进制分组后标准的 0/1 背包一维滚动分组优化
        int[] dp = new int[W + 1];
        for (int i = 0; i < newWeight.Count; i++)
        {
            int curWeight = newWeight[i];
            int curValue = newValue[i];
            //倒序遍历背包重量
            for (int j = W; j > curWeight; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - curWeight] + curValue);
            }
        }
        return dp[W];
    }

}
