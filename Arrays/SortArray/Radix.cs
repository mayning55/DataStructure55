using System;

namespace Arrays.SortArray;

public class Radix
{
    /// <summary>
    /// 基数排序
    /// 是一种非比较型的排序算法，它通过逐位比较元素的每一位（从最低位到最高位）来实现排序。基数排序的核心思想是将整数按位数切割成不同的数字，然后按每个位数分别进行排序。
    /// </summary>
    /// <param name="array"></param>

    public static void RadixSort(int[] array)
    {
        int m = array.Length;
        if (m < 2)
        {
            return;
        }
        // 找到数组中的最大值
        int maxValue = array.Max();
        // int maxValue = array[0];
        // foreach (int num in array)
        // {
        //     if (num > maxValue) maxValue = num;
        // }
        //进行基数排序
        for (int exp = 1; maxValue / exp > 0; exp *= 10)
        {
            CountingSort(array, exp);
        }
    }
    public static void CountingSort(int[] array, int exp)
    {
        int arrayLength = array.Length;
        int[] output = new int[arrayLength];
        int[] count = new int[10];

        //统计每个桶中的元素个数
        for (int i = 0; i < arrayLength; i++)
        {
            count[(array[i] / exp) % 10]++;
        }

        //计算每个桶中最后一个元素的位置
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        //从原数组中取出元素，放入到输出数组中
        for (int i = arrayLength - 1; i >= 0; i--)
        {
            output[count[(array[i] / exp) % 10] - 1] = array[i];
            count[(array[i] / exp) % 10]--;
        }

        //将输出数组复制回原数组
        for (int i = 0; i < arrayLength; i++)
        {
            array[i] = output[i];
        }
    }
}
