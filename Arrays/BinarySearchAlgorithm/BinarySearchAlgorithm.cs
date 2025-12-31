
namespace Arrays;

public class BinarySearchAlgorithm
{
    /// <summary>
    /// 二分查找
    /// 直接法，循环过程中，一旦找到目标元素，立即返回其下标。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int BinarySearch(int[] array, int target)
    {
        //查找区间，左右闭合。
        int left = 0;
        int right = array.Length - 1;
        //左边界小于右边界，循环结束时如果未找到目标，直接返回 -1。
        while (left <= right)
        {
            //计算中间值防止溢出
            int mid = left + (right - left) / 2;
            if (array[mid] == target)
            {
                return mid;
            }
            //如果中间数大于目标值，目标在左边，右边界减少至中间
            if (array[mid] > target)
            {
                right = mid - 1;
            }
            //否则，目标在右边，左边界增加中间
            else
            {
                left = mid + 1;
            }
        }
        return -1;
    }
    /// <summary>
    /// 排除法，循环过程中，排队目标不在的区间范围。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int BinarySearch2(int[] array, int target)
    {
        //查找区间，左右闭合。
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            //计算中间值向下取整，防止溢出
            int mid = left + (right - left) / 2;

            //如果中间数小于目标值，目标在右边，继续在 [mid + 1, right] 查找
            if (array[mid] < target)
            {
                left = mid + 1;
            }
            //否则，目标在左边，在[left, mid] 区间查找
            else
            {
                right = mid;
            }
        }
        //循环结束后，left == right，判断该位置是否为目标值
        return array[left] == target ? left : -1;
    }

}
