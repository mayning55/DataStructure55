using System;

namespace Arrays.SortArray;

public class Quicks
{
    /// <summary>
    /// 快速排序
    /// 基于分治法（Divide and Conquer）的思想。它的核心是通过选择一个基准元素（pivot），将数组分为两部分：一部分小于基准元素，另一部分大于基准元素，然后递归地对这两部分进行排序。本质上来看，快速排序应该算是在冒泡排序基础上的递归分治法。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>

    public static void QuickSort(int[] array, int left, int right)
    {
        if (left > right)//当左边小于基准元素大于右边大于基本元素时，结束递归。
        {
            return;
        }
        int i = left;
        int j = right;
        int temp = array[i];//基准元素（选择第一个）
        while (i < j)
        {
            while (i < j && array[j] >= temp)//从右向左找出比基本元素小的元素
            {
                j--;
            }
            array[i] = array[j];
            while (i < j && array[i] <= temp)//从左边右找出比基本元素大的元素
            {
                i++;
            }
            array[j] = array[i];
        }
        array[i] = temp;
        QuickSort(array, left, i - 1);//递归调用左边元素进行排序
        QuickSort(array, i + 1, right);//递归调用右边元素进行排序

    }
}
