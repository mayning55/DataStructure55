namespace Arrays.SortArray;

public class Bubble
{
    /// <summary>
    /// 冒泡排序
    /// 是一种简单的排序算法，它通过重复地遍历待排序的列表，比较相邻的元素并交换它们的位置来实现排序。
    /// </summary>
    /// <param name="intArrays"></param>
    public static void BubbleSort(int[] array)
    {
        int n = array.Length;
        bool swapped;//
        for (int i = 0; i < n - 1; i++)
        {
            //新一轮循环，重置调换状态为未发生过调换。
            swapped = false;
            //遍历内循环，比较相邻俩元素是否需要调换位置，
            for (int j = 0; j < n - i - 1; j++)
            {
                //当前元素大于后一个元素，调换位置
                if (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;//调换状态调整为真；
                }
            }
            //如果内循环一轮后，全部是排序状态，没有发生调换。则直接跳出循环，返回结果。
            if (!swapped)
            {
                break;
            }
        }
    }

}
