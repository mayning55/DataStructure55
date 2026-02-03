using System;

namespace DynamicProgramming.PackMethod;

/// <summary>
/// 混合背包
/// </summary>
public class HybridPacket
{
    /// <summary>
    /// 混合背包
    /// </summary>
    /// <param name="weight">种物品的重量</param>
    /// <param name="value">每种物品的价值</param>
    /// <param name="count">每种物品的数量上限：</param>
    /// 当数量等于1时，表示只有1件；
    /// 当数量等于0时，表示无限件；
    /// 当数量大于1时，表示该值的件数。
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>
    public int HybridPacketMethodBit(int[] weight, int[] value, int[] count, int W)
    {
        if (weight == null || value == null || count == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        //初始化
        int m = weight.Length;
        int[] dp = new int[W + 1];
        //二进制分组
        /*
        将多重背包拆解为0-1背包，完全背包保留标记
        数量等于1时，表示只有1件；数量二进制分组为1；
        数量大于1时，表示多件，数量二进制分组后同样为1；
        数量等于0时，表示无限年，数量分组为0；
        */
        List<int> newWeight = new List<int>();
        List<int> newValue = new List<int>();
        List<int> newCount = new List<int>();
        for (int i = 0; i < m; i++)
        {
            int cnt = count[i];
            //多重背包,分组成数量1的物品组，与0-1背包一起计算。
            if (cnt > 0)
            {
                int k = 1;
                while (k <= cnt)
                {
                    cnt -= k;
                    newWeight.Add(weight[i] * k);
                    newValue.Add(value[i] * k);
                    newCount.Add(1);
                    k *= 2;
                }
                //处理余数
                if (cnt > 0)
                {
                    newWeight.Add(weight[i] * cnt);
                    newValue.Add(value[i] * cnt);
                    newCount.Add(1);
                }
            }
            //0-1背包，直接加入当前物品重量与价值，数量1
            // else if (cnt == 1)
            // {
            //     newWeight.Add(weight[i]);
            //     newValue.Add(value[i]);
            //     newCount.Add(1);
            // }
            //完全背包，直接加入当前物品重量与价值，数量无限
            else
            {
                newWeight.Add(weight[i]);
                newValue.Add(value[i]);
                newCount.Add(0);

            }
        }
        //动态规划
        int itemCount = newWeight.Count;
        // 遍历每一种物品,根据分组数量来计算。
        for (int i = 0; i < itemCount; i++)
        {
            int curWeight = newWeight[i];
            int curValue = newValue[i];
            int curCount = newCount[i];
            // 0-1背包 (分组后数量为1)，套用0-1滚动数组计算方式。
            if (curCount == 1)
            {
                // 倒序遍历       
                for (int j = W; j >= curWeight; j--)
                {
                    dp[j] = Math.Max(dp[j], dp[j - curWeight] + curValue);
                }
            }
            // 完全背包 (分组后数量为0)，套用完全背包滚动数组计算方式。
            else
            {
                for (int j = curWeight; j <= W; j++)
                {
                    dp[j] = Math.Max(dp[j], dp[j - curWeight] + curValue);
                }
            }
        }
        return dp[W];
    }
    /// <summary>
    /// 混合背包，根据数量进行选择
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="count"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    // public int HybridPacketMethod(int[] weight, int[] value, int[] count, int W)
    // {
    //     int m = weight.Length;
    //     int[] dp = new int[W + 1];

    //     for (int i = 1; i <= m; i++)
    //     {
    //         //0-1背包
    //         if (count[i - 1] == 1)
    //         {
    //             for (int j = W; j > weight[i - 1] - 1; j--)
    //             {
    //                 dp[j] = Math.Max(dp[j], dp[j - weight[i - 1]] + value[i - 1]);
    //             }
    //         }
    //         //完全背包
    //         else if (count[i - 1] == 0)
    //         {
    //             for (int j = weight[i - 1]; j <= W; j++)
    //             {
    //                 dp[j] = Math.Max(dp[j], dp[j - weight[i - 1]] + value[i - 1]);
    //             }

    //         }
    //         //多重北外
    //         else
    //         {
    //             for (int j = W; j > weight[i - 1] - 1; j--)
    //             {
    //                 int num = Math.Min(count[i - 1], j / weight[i - 1]) + 1;
    //                 for (int k = 0; k < num; k++)
    //                 {
    //                     dp[j] = Math.Max(dp[j], dp[j - k * weight[i - 1]] + k * value[i - 1]);
    //                 }
    //             }
    //         }
    //     }
    //     return dp[W];
    // }

}
