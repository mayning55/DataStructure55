using System;

namespace DynamicProgramming;

/// <summary>
/// 记忆化搜索 
/// </summary>
public class MemoizationSearch
{
    /// <summary>
    /// 记忆化搜索 
    /// 泰波那契数（Tribonacci数）：从第三项开始，每一项是前三项的和。
    /// T0 = 0, T1 = 1, T2 = 1, 且在 n >= 0 的条件下 Tn+3 = Tn + Tn+1 + Tn+2
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int Tribonacci(int x)
    {
        //保存已经计算过的值
        int[] memoization = new int[x + 1];
        return TribonacciMemoSearch(x, memoization);
    }
    //递归，记忆化搜索（Memoization Search）
    public int TribonacciMemoSearch(int x, int[] memo)
    {
        if (x <= 0)
        {
            return 0;
        }
        if (x > 0 && x <= 2)
        {
            return 1;
        }
        //不等于表示已经计算过，直接返回结果。
        if (memo[x] != 0)
        {
            return memo[x];
        }
        //递归调用，保存结果备用并返回。
        memo[x] = TribonacciMemoSearch(x - 3, memo) + TribonacciMemoSearch(x - 2, memo) + TribonacciMemoSearch(x - 1, memo);
        return memo[x];
    }
    /// <summary>
    /// 目标和,
    /// </summary>
    /// <param name="nums"></param>正整数数组
    /// <param name="target"></param>整数
    /// <returns></returns>数组元素间添加+,-，使运算结果等于target的数目数量。
    public int FindTargetSumWays(int[] nums, int target)
    {
        this.nums = nums;
        this.target = target;
        curSum = new Dictionary<int[], int>();
        return FTSDFS(0, 0);
    }
    private int[] nums;
    private int target;
    //哈希字典，保存运算后元素下标，增加或减去后的值的数目数量。
    private Dictionary<int[], int> curSum;
    //记忆化搜索递归数组每个元素。
    private int FTSDFS(int index, int val)
    {
        //如果运算结果等于目标，返回1，否则返回0
        if (index == nums.Length)
        {
            return val == target ? 1 : 0;
        }
        //如果已经记录过计算结果，返回记录的结果。
        if (curSum.ContainsKey(new int[] { index, val }))
        {
            return curSum[new int[] { index, val }];
        }
        //分别递归计算增加当前元素与减去当前元素的数目对数。保存记录并返回。
        int cnt = FTSDFS(index + 1, val + nums[index]) + FTSDFS(index + 1, val - nums[index]);
        curSum[new int[] { index, val }] = cnt;
        return cnt;
    }
}
