using System;

namespace DynamicProgramming;
/// <summary>
/// 计数DP
/// </summary>
public class CountDP
{
    /// <summary>
    /// 不同路径
    /// </summary>
    /// <param name="m">m x n</param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int UniquePaths(int m, int n)
    {
        int[,] dp = new int[m, n];
        //初始化行和列，只能向右，或向下，首行和首列=1；
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = 1;
        }
        for (int j = 0; j < n; j++)
        {
            dp[0, j] = 1;
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                //只能向右、或者向下移动一步
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

            }
        }
        return dp[m - 1, n - 1];
    }
    /// <summary>
    /// 整数拆分
    /// </summary>
    /// <param name="n">将其拆分为 k(k≥2)k(k≥2) 个正整数的和</param>
    /// <returns>返回这拆分的整数最大乘积</returns>
    public int IntegerBreak(int n)
    {
        int[] dp = new int[n + 1];
        //0,1不能拆分，dp[0],dp[1]为0；
        for (int i = 2; i <= n; i++)
        {
            //拆分后是否继续拆分？取最大值，(i - j) * j； dp[i - j] * j
            for (int j = 0; j < i; j++)
            {
                dp[i] = Math.Max(dp[i], Math.Max((i - j) * j, dp[i - j] * j));
            }
        }
        return dp[n];
    }

}
