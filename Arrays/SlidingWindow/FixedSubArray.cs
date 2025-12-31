namespace Arrays;

public class FixedSubArray
{
    /// <summary>
    /// 滑动窗口（固定长度窗口）
    /// 1343. 大小为 K 且平均值大于等于阈值的子数组数目
    /// </summary>
    /// <param name="arr"></param>整数数组
    /// <param name="k"></param>整数
    /// <param name="threshold"></param>整数
    /// <returns></returns>返回长度为 k 且平均值大于等于 threshold 的子数组数目

    public static int FixedSubArrayWindow(int[] arr, int k, int threshold)
    {
        int m = arr.Length;
        int left = 0;//窗口子数组左边界
        int right = 0;//窗口子数组右边界
        int subArraySum = 0;//窗口子数组和，用来比较k长度的平均值。
        int result = 0;
        while (right < m)
        {
            //将右边界元素加入窗口子数组和
            subArraySum += arr[right];
            //当窗口长度达到k时，判断是否满足返回条件（下标从0开始）
            if ((right - left + 1) >= k)
            {
                if (subArraySum >= k * threshold)
                {
                    result++;
                }
                //窗口子数组和减去最左元素
                subArraySum -= arr[left];
                //左边界右移
                left++;
            }
            //右边界右移
            right++;
        }
        return result;
    }
}
