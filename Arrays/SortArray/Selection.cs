using System;

namespace Arrays.SortArray;

public class Selection
{
    /// <summary>
    /// 选择排序
    /// 是一种简单直观的排序算法，每次从待排序的数据中选择最小（或最大）的元素，放到已排序序列的末尾，直到全部数据排序完成。
    /// </summary>
    /// <param name="array"></param>
    public static void SelectionSort(int[] array)
    {
        int m = array.Length;

        for (int i = 0; i < m - 1; i++)
        {
            //新的一轮循环，将当前元素为最小值
            int minIndex = i;
            //遍历内循环，将当前元素与最小值比较，如果更小，替换最小值下标。
            for (int j = i + 1; j < m; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            //一轮内循环结束后，如果最小值下标变动。则将最小值与当前元素交换位置。
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    private static void SelectionSortMM(int[] array)
    {
        int m = array.Length;
        for (int i = 0; i < m / 2; i++)
        {
            //同时将当前元素为最小值和最大值
            int maxIndex = i;
            int minIndex = i;
            //遍历内循环，将当前元素与最小值和最大值比较，如果更小或更大，替换最小值和最大值下标。
            for (int j = i; j < m - i; j++)
            {
                if (array[minIndex] > array[j])
                {
                    minIndex = j;
                }
                if (array[maxIndex] < array[j])
                {
                    maxIndex = j;
                }
            }
            //一轮内循环结束后，如果最大值下标是当前且最小值下标是最后。最大和最小交换位置。
            if (maxIndex == i && minIndex == m - i - 1)
            {
                Swap(ref array[maxIndex], ref array[minIndex]);
            }
            //如果当前元素是最大值，将最大值放到最后，最小值放到当前。
            else if (maxIndex == i)
            {
                Swap(ref array[maxIndex], ref array[m - i - 1]);
                Swap(ref array[minIndex], ref array[i]);
            }
            //否则，将最小值放到当前，最大值放到最后。
            else
            {
                Swap(ref array[minIndex], ref array[i]);
                Swap(ref array[maxIndex], ref array[m - i - 1]);
            }
        }
    }
    /// <summary>
    /// 通过引用传递参数，调换a，b的值。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    private static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
