using Arrays.SortArray;
using Arrays.TwoPointers;

namespace Arrays;

class Program
{
    static void Main(string[] args)
    {
        int[] intArrays = new int[] { 3, 1, 4, 2, 7, 5, 6, 9, 8 };
        /*
        数组排序SortArray
        */
        //Bubble.BubbleSort(intArrays);//冒泡排序
        //Bucket.BucketSort(intArrays);//桶排序
        //Count.CountSort(intArrays);//计数排序
        //Heap.HeapSort(intArrays);//堆排序
        //Inserts.InsertSort(intArrays);//插入排序
        Merges.MergeSort(intArrays, 0, intArrays.Length - 1);//归并排序
        //Quicks.QuickSort(intArrays,0,intArrays.Length-1);
        //Radix.RadixSort(intArrays);//基数排序
        //Selection.SelectionSort(intArrays);//选择排序
        //Shell.ShellSort(intArrays);//希尔排序
        System.Console.WriteLine(string.Join(",", intArrays));
        /*
        二分查找法,！！！数组是有序的。
        */
        int result = BinarySearchAlgorithm.BinarySearch(intArrays, 6);
        System.Console.WriteLine(result);
        /*
        滑动窗口
        */
        //固定长度窗口
        int kresult = FixedSubArray.FixedSubArrayWindow(intArrays, 3, 3);
        System.Console.WriteLine(kresult);
        //不固定长度窗口
        string s = "abcabcbb";
        int sresult = NotFixedSubArray.NotFixedSubArrayWindow(s);
        System.Console.WriteLine(sresult);
        /*
        双指针
        */
        //相向
        int[] tpresult = OppositeDirection.ODTwoPointers(intArrays, 10);
        System.Console.WriteLine(string.Join(",", tpresult));
        //同向
        int[] intArraysd = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        int sdresult = SameDirection.SDTwoPointers(intArraysd);
        System.Console.WriteLine(sdresult);
        //分离双指针
        int[] intArray1 = new int[] { 4, 9, 5 };
        int[] intArray2 = new int[] { 9, 4, 9, 8, 4 };
        int[] stp = Separation.SeparationTwoPointers(intArray1, intArray2);
        System.Console.WriteLine(string.Join(",", stp));
    }
}
