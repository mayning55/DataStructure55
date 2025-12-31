using System;

namespace Arrays.SortArray;

public class Count
{
    /// <summary>
    /// 计数排序
    /// 是一种非比较型的排序算法，适用于对整数或有限范围内的数据进行排序。统计数组中每个元素出现的次数，然后根据统计信息将元素按顺序放置到正确位置，实现排序。计数排序的核心在于将输入的数据值转化为键存储在额外开辟的数组空间中。作为一种线性时间复杂度的排序，计数排序要求输入的数据必须是有确定范围的整数。
    /// </summary>
    /// <param name="array"></param>

    public static void CountSort(int[] array)
    {
        int m = array.Length;
        if (m < 2)
        {
            return;
        }
        int maxValue = array.Max();
        int minValue = array.Min();
        int[] cnt = new int[maxValue - minValue + 1];
        //统计每个元素出现的次数
        for (int i = 0; i < m; i++)
        {
            cnt[array[i] - minValue]++;
        }
        //根据cnt数组和min值确定每个元素的起始位置
        for (int i = 1; i < cnt.Length; i++)
        {
            cnt[i] += cnt[i - 1];
        }
        //存储排序结果
        int[] temp = new int[m];

        //根据count数组和min值确定每个元素在temp数组中的位置
        for (int i = m - 1; i >= 0; i--)
        {
            int index = cnt[array[i] - minValue] - 1;
            temp[index] = array[i];
            cnt[array[i] - minValue]--;
        }

        //将排序结果复制回原数组
        for (int i = 0; i < m; i++)
        {
            array[i] = temp[i];
        }

    }
}
