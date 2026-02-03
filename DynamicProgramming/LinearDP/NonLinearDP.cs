using System;

namespace DynamicProgramming;

public class NonLinearDP
{
    /// <summary>
    /// 整数拆分
    /// </summary>
    /// <param name="n">正整数 n</param>
    /// <returns>其拆分为 k(k≥2) 个正整数的最大乘积。</returns>
    public int IntegerBreak(int n)
    {
        int[] dp = new int[n + 1];
        //从2开始，0和1无法拆分。
        for (int i = 2; i <= n; i++)
        {
            //将i 拆分 j 和 i-j，如果i-j不继续拆分,乘积为  j × ( i − j ) ,继续拆分，乘积为  j × dp( i − j ).
            //取两个种的最大值。
            for (int j = 0; j < i; j++)
            {
                dp[i] = Math.Max(Math.Max((i - j) * j, dp[i - j] * j), dp[i]);
            }
        }
        return dp[n];
    }
}
