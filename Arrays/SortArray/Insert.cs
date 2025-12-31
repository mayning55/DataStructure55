using System;

namespace Arrays.SortArray;

public class Inserts
{
    /// <summary>
    /// 插入排序
    /// 将数组分为有序区间和无序区间，每次从无序区间取出一个元素插入到有序区间的正确位置。插入排序通过逐步构建有序序列来实现排序，每次插入后有序区间保持有序。对于未排序的数据，在已排序序列中从后向前扫描，找到相应位置并插入。
    /// </summary>
    /// <param name="array"></param>

    public static void InsertSort(int[] array)
    {
        int m = array.Length;
        //将数组首位当有序区间，遍历无序区间
        for (int i = 1; i < m; i++)
        {
            int temp = array[i];
            //从右往左遍历有序区间
            for (int j = i - 1; j >= 0; j--)
            {
                //如果当前元素大于temp的
                if (array[j] > temp)
                {
                    //右移
                    array[j + 1] = array[j];
                    //当前位置放入无序元素
                    array[j] = temp;
                }
                //否则，跳出循环。
                else
                {
                    break;
                }
            }
        }
    }
}
