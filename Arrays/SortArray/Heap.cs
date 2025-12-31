using System;

namespace Arrays.SortArray;

public class Heap
{
    /// <summary>
    /// 堆排序
    /// 是一种基于「堆结构」实现的高效排序算法。利用堆的特性，将数组构建成大顶堆，然后重复取出堆顶元素（最大值）并调整堆结构，最终得到有序数组。
    /// </summary>
    /// <param name="array"></param>
    public static void HeapSort(int[] array)
    {
        int m = array.Length;
        //构建大堆，从下往上调整堆
        for (int i = m / 2 - 1; i >= 0; i--)
        {
            HeapAdjustMax(array, i, m);
            //HeapAdjustMin(array, i, m);
        }
        //调换堆顶元素和最后一个元素并调整堆
        for (int j = m - 1; j > 0; j--)
        {
            //交换堆顶元素与当前末尾元素
            int temp = array[0];
            array[0] = array[j];
            array[j] = temp;
            //最后一位是最大值。堆长度减1，重新调整堆
            HeapAdjustMax(array, 0, j); //大堆
            //HeapAdjustMin(array, 0, j);//小堆
        }
    }
    /// <summary>
    /// 堆调整（大顶堆，递增）
    /// </summary>
    /// <param name="array"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>

    private static void HeapAdjustMax(int[] array, int start, int end)
    {
        int left = 2 * start + 1;//左子节点
        int right = 2 * start + 2;//右子节点
        int rootIndex = start; //根节点
        //如果左子节点大，则指向左子节点
        if (left < end && array[left] > array[rootIndex])
        {
            rootIndex = left;
        }
        //如果右子节点大，则指向右子节点
        if (right < end && array[right] > array[rootIndex])
        {
            rootIndex = right;
        }
        ////如果根节点发生变动，则交换位置，并递归调整子节点
        if (rootIndex != start)
        {
            int temp = array[start];
            array[start] = array[rootIndex];
            array[rootIndex] = temp;
            HeapAdjustMax(array, rootIndex, end);//递归调整子节点
        }
    }
    /// <summary>
    /// 堆调整（小顶堆，递减）
    /// </summary>
    /// <param name="array"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>

    private static void HeapAdjustMin(int[] array, int start, int end)
    {
        int left = 2 * start + 1;//左子节点
        int right = 2 * start + 2;//右子节点
        int rootIndex = start; //根节点
        //如果左子节点小，则指向左子节点
        if (left < end && array[left] < array[rootIndex])
        {
            rootIndex = left;
        }
        //如果右子节点小，则指向右子节点
        if (right < end && array[right] < array[rootIndex])
        {
            rootIndex = right;
        }
        //如果根节点发生变动，则交换位置，并递归调整子节点
        if (rootIndex != start)
        {
            int temp = array[start];
            array[start] = array[rootIndex];
            array[rootIndex] = temp;
            //递归调整子树
            HeapAdjustMin(array, rootIndex, end);
        }
    }

}
