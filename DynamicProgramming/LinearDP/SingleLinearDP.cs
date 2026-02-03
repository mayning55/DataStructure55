using System;

namespace DynamicProgramming;
/// <summary>
/// 一维线性DP（单串）
/// </summary>
public class SingleLinearDP
{
    /// <summary>
    /// 最长递增子序列，一维线性DP（单串）
    /// 子序列：顺序不变，但可以不连续。
    /// 子数组：顺序不变且连续。
    /// </summary>
    /// <param name="nums">整数数组</param>
    /// <returns>找到其中最长严格递增子序列的长度。</returns>
    public int LengthOfLIS(int[] nums)
    {
        int m = nums.Length;
        int[] dp = new int[m];
        for (int i = 0; i < m; i++)
        {
            //初始条件，每个元素自身都可以作为长度为1的递增子序列。
            dp[i] = 1;
            //状态转换（符合条件0≤j<i 且nums[j]<nums[i]）
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        //返回最大值。
        return dp.Max();
    }
    /// <summary>
    /// 最长递增子序列，线性DP+二分查找的优化
    /// 子序列：顺序不变，但可以不连续。
    /// 子数组：顺序不变且连续。
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int LengthOfLISWithBinarySearch(int[] nums)
    {
        int m = nums.Length;
        //子序列，记录递增子序列
        int[] sub = new int[m];
        //记录增子序列的有效长度
        int size = 0;
        foreach (var x in nums)
        {
            //二分查找：在sub中找首个大于或等于当前元素的下标
            int index = Array.BinarySearch(sub, 0, size, x);
            //没有找到，返回负数和，进行取反运算
            if (index < 0)
            {
                index = ~index;
            }
            //修改sub子序列元素值。
            sub[index] = x;
            //如果当前元素的下标等于sub子序列元素最大值的下标，sub长度加1.以便进行下一个元素比较。
            if (index == size)
            {
                size++;
            }
        }
        return size;

    }
    /// <summary>
    /// 最大子数组和
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MaxSubArraySum(int[] nums)
    {
        int m = nums.Length;
        int[] dp = new int[m];
        //初始条件；
        dp[0] = nums[0];
        //状态转换：如果 dp[i−1]<0， dp[i]=nums[i]。如果dp[i−1]≥0，dp[i]=dp[i−1]+nums[i]
        for (int i = 1; i < m; i++)
        {
            if (dp[i - 1] < 0)
            {
                dp[i] = nums[i];
            }
            else
            {
                dp[i] = dp[i - 1] + nums[i];
            }

        }
        //返回最大值
        return dp.Max();
    }
    /// <summary>
    /// 动态规划 + 滚动优化
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>

    public int[] MaxSubArray(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return new int[0];
        }
        int m = nums.Length;
        //最大和
        int subSum = 0;
        //当前累加
        int curSum = 0;
        //开始下标
        int startIndex = 0;
        //结束下标
        int endIndex = 0;
        //临时下标
        int temp = 0;
        for (int i = 1; i < m; i++)
        {
            //如果累加小于0，重新开始吧。
            if (curSum < 0)
            {
                curSum = nums[i];
                // 更新临时起点为当前位置
                temp = i;
            }
            //添加当前元素
            else
            {
                curSum += nums[i];
            }
            // 如果发现了更大的和，更新全局最大值及其对应的索引
            if (curSum > subSum)
            {
                subSum = curSum;
                startIndex = temp; // 当前的临时起点即为最佳起点
                endIndex = i;           // 当前的 i 即为最佳终点
            }
        }
        //返回切片(语法糖)
        return nums[startIndex..(endIndex + 1)];
    }
}
