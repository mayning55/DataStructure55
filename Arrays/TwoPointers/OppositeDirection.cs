using System;

namespace Arrays.TwoPointers;

public class OppositeDirection
{
    /// <summary>
    /// 对撞（相向）双指针
    /// 两数之和
    /// </summary>
    /// <param name="array"></param>递增的正整数数组 
    /// <param name="target"></param>目标值
    /// <returns></returns>返回相加之和等于目标数 target 的两个数。如果设这两个数分别是 numbers[index1] 和 numbers[index2] ，则 1 <= index1 < index2 <= numbers.length 。
    /// 以长度为 2 的整数数组 [index1, index2] 的形式返回这两个整数的下标 index1 和 index2。
    public static int[] ODTwoPointers(int[] array, int target)
    {
        //左指针指向第一个元素，右指针指向最末元素
        int left = 0;
        int right = array.Length - 1;
        while (left < right)
        {
            //判断两个指针元素和是否等于目标值
            if (array[left] + array[right] == target)
            {
                return new int[] { left + 1, right + 1 };
            }
            //如果小于目标值，左指针右移，继续检测。
            else if (array[left] + array[right] < target)
            {
                left++;
            }
            //如果大于目标值，右指针左移，继续检测。直到左右指针相等
            else
            {
                right--;
            }
        }
        return new int[] { 0, 0 };
    }

}
