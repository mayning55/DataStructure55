using System;

namespace Algorithms;

public class SlidingWindow
{
    /// <summary>
    /// 滑动窗口（固定长度窗口）
    /// 1343. 大小为 K 且平均值大于等于阈值的子数组数目
    /// </summary>
    /// <param name="nums">整数数组</param>
    /// <param name="k"></param>
    /// <param name="threshold"></param>
    /// <returns>返回长度为 k 且平均值大于等于 threshold 的子数组数目</returns>
    public int FixedLengthSlidingWindow(int[] nums, int k, int threshold)
    {
        int m = nums.Length;
        int left = 0;//窗口子数组左边界
        int right = 0;//窗口子数组右边界
        int subArraySum = 0;//窗口子数组和，用来比较k长度的平均值。
        int result = 0;
        while (right < m)
        {
            //将右边界元素加入窗口子数组和
            subArraySum += nums[right];
            //当窗口长度达到k时，判断是否满足返回条件（下标从0开始）
            if ((right - left + 1) >= k)
            {
                if (subArraySum >= k * threshold)
                {
                    result++;
                }
                //窗口子数组和减去最左元素
                subArraySum -= nums[left];
                //左边界右移
                left++;
            }
            //右边界右移
            right++;
        }
        return result;
    }
    /// <summary>
    /// 滑动窗口（可变长度窗口）
    /// 无重复字符的最长子串
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int NoFixedLengthSlidingWindow(string s)
    {
        int m = s.Length;
        //窗口子数组左边界和右边界
        int left = 0;
        int right = 0;
        //记录窗口内每个字符出现的次数
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int result = 0;

        while (right < m)
        {
            //将当前字符加入窗口，统计出现次数
            if (dict.ContainsKey(s[right]))
            {
                dict[s[right]]++;
            }
            else
            {
                dict.Add(s[right], 1);
            }
            //如果当前字符出现次数大于1，说明有重复，需要收缩左边界
            while (dict[s[right]] > 1)
            {
                dict[s[left]]--;
                left++;
            }
            //更新最长无重复子串的长度
            result = Math.Max(result, right - left + 1);
            //右边界右移
            right++;
        }
        return result;
    }

}
