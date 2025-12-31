using System;

namespace Arrays.TwoPointers;

public class SameDirection
{

    /// <summary>
    /// 快慢（同向）指针
    /// 去除重复元素后的数组长度
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>

    public static int SDTwoPointers(int[] array)
    {
        int m = array.Length;
        if (m < 2)
        {
            return m;
        }
        //分别定义两个指针 fast 快指针和 slow 慢指针，快指针表示遍历数组到达的下标位置，慢指针表示指针指向去重后数组的最后一个元素
        int fast = 1;
        int slow = 0;
        //快指针指向最末元素前重复
        while (fast < m)
        {
            //如果当前 fast 指向的元素和 slow 指向的元素不同时，表示俩值不重复。
            if (array[slow] != array[fast])
            {
                slow++;//慢指针进一位
                array[slow] = array[fast];//将快指针的值赋值给慢指针。
            }
            fast++;//无论如何，快指针都进一位
        }
        //返回慢指针指向的下标即为不重复数组长度（下标从0开始，+1）。
        return slow + 1;
    }

}
