using System;

namespace Arrays.SortArray;

public class Shell
{
    /// <summary>
    /// 希尔排序
    /// 插入排序的一种改进版本，通过设定不同的间隔（gap），将数组分组进行插入排序。逐步缩小间隔，最终完成数组的排序。
    /// </summary>
    /// <param name="array"></param>
    public static void ShellSort(int[] array)
    {
        int m = array.Length;
        //设定间隔为数组长度的一半。
        int gap = m / 2;
        //当间隔大于0时，重复执行排序并缩小间隔
        while (gap > 0)
        {
            //从间隔位置开始遍历无序区间
            for (int i = gap; i < m; i++)
            {
                //记录当前元素及其下标
                int temp = array[i];
                int j = i;
                //从右往左遍历有序区间，将大于当前元素的往右移
                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];//如果当前元素大于temp,右移
                    j -= gap;//往前移动gap个位置
                }
                //当前位置放入无序元素 
                array[j] = temp;

            }
            //缩小间隔
            gap /= 2;
        }
    }
}
