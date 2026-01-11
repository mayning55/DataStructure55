using System;

namespace Algorithms;

public class Recursion
{
    /// <summary>
    /// 递归，阶乘
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public double Factorial(int x)
    {
        if (x == 0 || x == 1)
        {
            return 1;
        }
        else
        {
            return x * Factorial(x - 1);
        }
    }
    /// <summary>
    /// 求和
    /// </summary>(（first+end)*end)/2
    /// <param name="x"></param>
    /// <returns></returns>
    public double NumSum(int x)
    {
        if (x <= 1)
        {
            return 1;
        }
        else
        {
            return x + NumSum(x - 1);
        }
    }
    /// <summary>
    /// Fibonacci斐波那契
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>

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
        else
        {
            return Fibo(x - 1) + Fibo(x - 2);
        }
    }
}
