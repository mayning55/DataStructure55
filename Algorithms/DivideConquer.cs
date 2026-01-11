using System;

namespace Algorithms;

/// <summary>
/// 分治算法
/// </summary>
public class DivideConquer
{
    /// <summary>
    /// 分治，查找数组中子数组最大和
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] MaxSubArray(int[] nums)
    {
        if (nums == null || nums.Length == 0) return new int[0];

        // 最大子数组和对应的起始和结束下标
        int[] subArrayIndex = DivideAndConquerArray(nums, 0, nums.Length - 1);

        // 根据下标截取子数组
        // 切片语法糖
        return nums[subArrayIndex[0]..(subArrayIndex[1] + 1)];
    }

    /// <summary>
    /// 递归函数，返回最大子数组的起始下标和结束下标
    /// </summary>
    private int[] DivideAndConquerArray(int[] nums, int left, int right)
    {
        //递归终止条件：当 left == right 时，说明只有一个元素，直接返回该元素
        if (left == right)
        {
            return new int[] { left, left };
        }
        //取中间，分开两边
        int mid = left + (right - left) / 2;
        //递归计算左边最大子数组和
        int[] leftMaxSum = DivideAndConquerArray(nums, left, mid);
        //递归计算右边最大子数组和
        int[] rightMaxSum = DivideAndConquerArray(nums, mid + 1, right);

        //计算中间部分
        // 从中间向左寻找累加最大值
        int leftCrossSum = int.MinValue;
        int templeftSum = 0;
        //记录跨越部分的起始下标
        int crossStart = mid;
        for (int i = mid; i >= left; i--)
        {
            templeftSum += nums[i];
            //加上当前元素后比较是否大于累加最大值，如果是，更新累加。
            if (templeftSum > leftCrossSum)
            {
                leftCrossSum = templeftSum;
                //更新起始位置
                crossStart = i;
            }
        }
        //从中间向右寻找累加最大值
        int rightCrossSum = int.MinValue;
        int tempRightSum = 0;
        // 记录跨越部分的结束下标
        int crossEnd = mid + 1;

        for (int i = mid + 1; i <= right; i++)
        {
            tempRightSum += nums[i];
            //加上当前元素后比较是否大于累加最大值，如果是，更新累加。
            if (tempRightSum > rightCrossSum)
            {
                rightCrossSum = tempRightSum;
                // 更新结束位置
                crossEnd = i;
            }
        }
        //合计中间部分，左边+右边
        int crossSum = leftCrossSum + rightCrossSum;
        //左边子数组最大和
        int leftSum = nums[leftMaxSum[0]..leftMaxSum[1]].Sum();
        //右边子数组最大和
        int rightSum = nums[rightMaxSum[0]..rightMaxSum[1]].Sum();

        // 比较三者后，返回最大值的下标
        if (leftSum >= rightSum && leftSum >= crossSum)
        {
            return leftMaxSum;
        }
        else if (rightSum >= leftSum && rightSum >= crossSum)
        {
            return rightMaxSum;
        }
        else
        {
            return new int[] { crossStart, crossEnd };
        }
    }
}

