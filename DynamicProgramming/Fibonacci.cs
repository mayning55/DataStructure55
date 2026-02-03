using System;
using System.ComponentModel;

namespace DynamicProgramming;

public class Fibonacci
{
    /// <summary>
    /// 动态规划；递推公式：f(n)=f(n−1)+f(n−2)
    /// Fibonacci斐波那契数
    /// </summary>
    /// <param name="x"></param>
    /// <returns>返回第x位斐波那契数的值</returns>

    public int Fibo(int x)
    {
        if (x <= 0)
        {
            return 0;
        }
        if (x > 0 && x <= 2)
        {
            return 1;
        }
        //初始化数组，给定特定值。
        int[] dp = new int[x + 1];
        dp[0] = 0;
        dp[1] = 1;
        //递推计算，f(n)=f(n−1)+f(n−2)
        for (int i = 2; i <= x; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[x];
    }
}
