using System;

namespace DynamicProgramming;

/// <summary>
/// 区间DP
/// </summary>
public class IntervalDP
{
    /// <summary>
    /// 最长回文子序列：扩展型区间DP
    /// (编辑距离，二维线性DP MiniDistanceDP)
    /// </summary>
    /// <param name="s"></param>子序列定义为：不改变剩余字符顺序的情况下，删除某些字符或者不删除任何字符形成的一个序列。
    /// <returns></returns>返回其中最长的回文子序列长度。
    public int LongestPalindromeSubseq(string s)
    {
        int m = s.Length;
        int[,] dp = new int[m, m];
        //状态转移，从较短向较长子序列转移。（倒序）
        for (int i = m - 1; i >= 0; i--)
        {
            ////单个字符的最长回文序列是 1.
            dp[i, i] = 1;
            for (int j = i + 1; j < m; j++)
            {
                //如果相等，s 的下标范围 [i+1,j−1] 扩展首尾。
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                //否则， s[i] 和 s[j] 不可能同时作为同一个回文子序列的首尾，取两者最大。
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }
        return dp[0, m - 1];
    }
    /// <summary>
    /// 戳气球:合并型区间DP
    /// </summary>
    /// <param name="nums"></param>气球上的数字
    /// <returns></returns>返回与相邻的两个气球相乘的值
    public int MaxCoins(int[] nums)
    {
        int m = nums.Length;
        int[,] dp = new int[m + 2, m + 2];
        int[] number = new int[m + 2];
        number[0] = 1;
        number[m + 1] = 1;
        for (int i = 1; i <= m; i++)
        {
            number[i] = nums[i - 1];
        }
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = i + 2; j <= m + 1; j++)
            {
                for (int k = i + 1; k < j; k++)
                {
                    int value = number[i] * number[j] * number[k];
                    dp[i, j] = Math.Max(dp[i, j], dp[i, k] + dp[k, j] + value);
                }
            }
        }
        return dp[0, m + 1];

    }
}
