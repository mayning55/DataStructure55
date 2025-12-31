

namespace Arrays;

public class Separation
{
    // int[] intArray1 = new int[] { 1, 2, 1, 2 };
    // int[] intArray2 = new int[] { 2, 2 };
    /// <summary>
    /// 分离双指针
    /// 两个数组的交集
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>

    public static int[] SeparationTwoPointers(int[] nums1, int[] nums2)
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
