using System.Net;

namespace Algorithms;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        /*
        枚举,
        数组中两元素之和等于10的队数。
        字符串组合
        */
        // int[] arrays = new int[] { 1, 9, 7, 0, 10, -8, -1, -7, 17, };
        //Enumeration ea = new Enumeration();
        // int cnt = ea.TwoSum(arrays);
        // System.Console.WriteLine(cnt);
        // string s = "abcd";
        // var result = ea.Combination(s);
        // foreach (var item in result)
        // {
        //     System.Console.WriteLine(string.Join(",", item));
        // }
        /*
        递归
        阶乘、等数差求和
        */
        // Recursion rec = new Recursion();
        // System.Console.WriteLine(rec.Factorial(100));
        // System.Console.WriteLine(rec.NumSum(100));
        /*
        回溯
        子集、全排列，组合。
        */

        Backtracking bc = new Backtracking();
        // int[] arrays = new int[] { 1, 3, 2, 1 };
        // var sresult = bc.SubsetsWithDup(arrays);
        // 子集
        // foreach (var sub in sresult)
        // {
        //     System.Console.WriteLine(string.Join(",", sub));
        // }
        // 排列
        // var presult = bc.PermuteUnique(arrays);
        // foreach(var per in presult)
        // {
        //     System.Console.WriteLine(string.Join(",", per));
        // }
        // 组合等于目标值的数量
        // var csresult = bc.CombinationSum(arrays, 4);
        // foreach (var com in csresult)
        // {
        //     System.Console.WriteLine(string.Join(",", com));
        // }
        // 在范围1至4中两两排列的组数量
        // var ccresutl = bc.CombinationCount(4, 3);
        // foreach (var item in ccresutl)
        // {
        //     System.Console.WriteLine(string.Join(",", item));
        // }
        // k个不重复元素之和组合
        // var cckresult = bc.CombinationSumK(3, 8);
        // foreach (var item in cckresult)
        // {
        //     System.Console.WriteLine(string.Join(",", item));
        // }
        /*
        贪心Greedy
        最大地满足
        */
        // Greedy greedy = new Greedy();
        // int[] childens = new int[] { 5, 2, 3, 1, 3, 4 };
        // int[] cookies = new int[] { 1, 1, 2, 3, 2, 4 };
        // int result = greedy.FindContentChildren(childens, cookies);
        // System.Console.WriteLine(result);
        /*
        分治
        */
        // DivideConquer dc = new DivideConquer();
        // int[] arrays = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        // System.Console.WriteLine(dc.MaxSubArray(arrays).Sum());
        // var subArrays = dc.MaxSubArray(arrays);
        // System.Console.WriteLine(string.Join(",", subArrays));
        /*
        二分查找
        */
        // int[] arrays = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // BinarySearch bs = new BinarySearch();
        // System.Console.WriteLine(bs.Search(arrays, 2));
        // System.Console.WriteLine(bs.Search2(arrays, 8));
        // System.Console.WriteLine(bs.Search(arrays, 11));
        /*
        双指针
        */
        // int[] arrays = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        // TwoPointers tp = new TwoPointers();
        // var odresult = tp.OppositeDirection(arrays, 22);
        // System.Console.WriteLine(string.Join(",", odresult));
        // int[] arrays2 = new int[] { 1, 2, 2, 2, 3, 5 };
        // System.Console.WriteLine(tp.SameDirection(arrays2));
        // var sresult = tp.Separation(arrays, arrays2);
        // System.Console.WriteLine(string.Join(",", sresult));
        /*
        滑动窗口
        */
        // int[] arrays = new int[] { 11, 13, 17, 23, 29, 31, 7, 5, 2, 3 };
        // int k = 3;
        // int threshold = 5;
        // SlidingWindow sw = new SlidingWindow();
        // System.Console.WriteLine(sw.FixedLengthSlidingWindow(arrays, k, threshold));
        // string str = "abcabcbb";
        // System.Console.WriteLine(sw.NoFixedLengthSlidingWindow(str));

    }
}
