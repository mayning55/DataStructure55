
namespace Arrays.SortArray;

public class Merges
{
    /// <summary>
    /// 归并排序
    /// 利用分治法，将数组递归地一分为二，直至每个子数组只包含一个元素。随后，将这些有序子数组两两合并，最终得到一个整体有序的数组。归并排序的核心思想是将一个大问题分解成若干个小问题，分别解决这些小问题，然后将结果合并起来，最终得到整个问题的解。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// 分解过程
    public static void MergeSort(int[] array, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        //找出中间位置，分成左右两部分数组
        int mid = (left + right) / 2;
        MergeSort(array, left, mid);//左边部分递归分解和排序
        MergeSort(array, mid + 1, right);//右边部分递归分解和排序
        MergeArray(array, left, mid, right);//分解后的子数组排序归并
    }
    /// <summary>
    /// 归并过程
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="mid"></param>
    /// <param name="right"></param>
    private static void MergeArray(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        int[] leftArray = new int[n1];//左边数组
        int[] rightArray = new int[n2];//右边数组
        for (int i = 0; i < n1; i++)
        {
            leftArray[i] = array[left + i];
        }
        for (int j = 0; j < n2; j++)
        {
            rightArray[j] = array[mid + 1 + j];
        }
        // Array.Copy(array, left, leftArray, 0, n1);//复制数组部分元素
        // Array.Copy(array, mid + 1, rightArray, 0, n2);//复制数组部分元素
        int l = 0, r = 0, k = left;
        //合并两个有序子数组
        while (l < n1 && r < n2)
        {
            if (leftArray[l] <= rightArray[r])
            {
                array[k] = leftArray[l];
                l++;
            }
            else
            {
                array[k] = rightArray[r];
                r++;
            }
            k++;
        }
        //如果左子数组有剩余元素，则将其插入到结果数组中
        while (l < n1)
        {
            array[k++] = leftArray[l++];
        }
        //如果右子数组有剩余元素，则将其插入到结果数组中
        while (r < n2)
        {
            array[k++] = rightArray[r++];
        }
    }
}
