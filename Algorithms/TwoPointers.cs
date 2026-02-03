using System;

namespace Algorithms;

/// <summary>
/// 双指针
/// </summary>
public class TwoPointers
{
    /// <summary>
    /// 对撞（相向）双指针,两数之和
    /// </summary>
    /// <param name="nums">递增的正整数数组</param>
    /// <param name="target">目标值</param>
    /// <returns>返回相加之和等于目标数 target 的两个数。如果设这两个数分别是 numbers[index1] 和 numbers[index2] ，则 1 <= index1 < index2 <= numbers.length 。</returns>
    public int[] OppositeDirection(int[] nums, int target)
    {
        //左指针指向第一个元素，右指针指向最末元素
        int left = 0;
        int right = nums.Length - 1;
        while (left < right)
        {
            //判断两个指针元素和是否等于目标值
            if (nums[left] + nums[right] == target)
            {
                return new int[] { left + 1, right + 1 };
            }
            //如果小于目标值，左指针右移，继续检测。
            else if (nums[left] + nums[right] < target)
            {
                left++;
            }
            //如果大于目标值，右指针左移，继续检测。直到左右指针相等
            else
            {
                right--;
            }
        }
        return new int[] { 0, 0 };

    }
    /// <summary>
    /// 快慢（同向）指针
    /// 去除重复元素后的数组长度
    /// </summary>
    /// <param name="nums">递增的正整数数组</param>
    /// <returns></returns>
    public int SameDirection(int[] nums)
    {
        int m = nums.Length;
        if (m < 2)
        {
            return m;
        }
        //分别定义两个指针 fast 快指针和 slow 慢指针，快指针表示遍历数组到达的下标位置，慢指针表示指针指向去重后数组的最后一个元素
        int fast = 1;
        int slow = 0;
        //快指针指向最末元素前重复
        while (fast < m)
        {
            //如果当前 fast 指向的元素和 slow 指向的元素不同时，表示俩值不重复。
            if (nums[slow] != nums[fast])
            {
                slow++;//慢指针进一位
                nums[slow] = nums[fast];//将快指针的值赋值给慢指针。
            }
            fast++;//无论如何，快指针都进一位
        }
        //返回慢指针指向的下标即为不重复数组长度（下标从0开始，+1）。
        return slow + 1;
    }
    /// <summary>
    /// 分离双指针
    /// 两个数组的交集
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>

    public int[] Separation(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        List<int> result = new List<int>();
        //俩数组排序
        Array.Sort(nums1);
        Array.Sort(nums2);
        //两个指针分别指向两个数组的首位
        int left1 = 0;
        int left2 = 0;
        //由于数组已排序，结果去重只需判断上一个加入的元素即可
        while (left1 < m && left2 < n)
        {
            //若俩数组的元素相同
            if (nums1[left1] == nums2[left2])
            {
                //检查结果为空或当前元素与上一个加入的元素不同时才添加，避免重复
                if (result.Count == 0 || nums1[left1] != result[result.Count - 1])
                {
                    result.Add(nums1[left1]);
                }
                left1++;
                left2++;
            }
            //那边数值小，那一边进位。
            else if (nums1[left1] < nums2[left2])
            {
                left1++;
            }
            else
            {
                left2++;
            }
        }
        return result.ToArray();
    }

}
