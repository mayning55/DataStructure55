using DynamicProgramming.PackMethod;

namespace DynamicProgramming;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        /*
        动态规划，递推
        斐波那契数
        */
        // Fibonacci fb = new Fibonacci();
        // System.Console.WriteLine(fb.Fibo(4));
        /*
        记忆搜索法
        泰波那契数；
        目标和
        */
        // MemoizationSearch ms = new MemoizationSearch();
        // System.Console.WriteLine(ms.Tribonacci(4));
        // int[] arrays = new int[] { 1, 1, 1, 1, 1, 1 };
        // System.Console.WriteLine(ms.FindTargetSumWays(arrays, 4));
        /*
        一维性DP（单串）
        */
        // SingleLinearDP sldp = new SingleLinearDP();
        // int[] arrays = new int[] { 10, 9, 2, 5, 3, 7, 101, 18 };
        // System.Console.WriteLine(sldp.LengthOfLIS(arrays));
        // System.Console.WriteLine(sldp.LengthOfLISWithBinarySearch(arrays));
        // int[] arrays2 = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        // var sub = sldp.MaxSubArray(arrays2);
        // System.Console.WriteLine(sub.Sum());
        // System.Console.WriteLine(string.Join(",", sub));
        /*
        二维性DP（双串）
        */
        DoubleLinearDP dldp = new DoubleLinearDP();
        // string s1 = "abcde";
        // string s2 = "acce";
        // System.Console.WriteLine(dldp.LongestCommonSubsequence(s1, s2));
        // int[] nums1 = new int[] { 1, 2, 3, 2, 1 };
        // int[] nums2 = new int[] { 3, 2, 1, 4, 7 };
        // System.Console.WriteLine(dldp.FindLength(nums1, nums2));
        // string s1 = "abcde", s2 = "bfxde";
        // System.Console.WriteLine(dldp.MinDistance(s1, s2));
        /*
        矩阵线性DP
        */
        // int[][] matrixPath = new int[][] { [1, 3, 4, 8], [3, 2, 2, 4], [5, 7, 1, 9], [2, 3, 2, 3] };
        // MatrixLinearMinPath mdp = new MatrixLinearMinPath(matrixPath);
        // var minPath = mdp.GetMinPath();
        // System.Console.WriteLine(string.Join(",", minPath));
        // System.Console.WriteLine(mdp.MinPathSum());
        // int[][] martixSquare = new int[][] { [1, 0, 1, 0, 0], [1, 0, 1, 1, 1], [1, 1, 1, 1, 1], [1, 0, 0, 1, 0] };
        // MatrixLinearDP mds = new MatrixLinearDP();
        // Console.WriteLine(mds.MaximalSquare(martixSquare));
        // System.Console.WriteLine(mds.CountSquares(martixSquare));
        /*
        无串线性DP
        */
        // NonLinearDP ndp = new NonLinearDP();
        // System.Console.WriteLine(ndp.IntegerBreak(10));
        /*
        0-1背包
        */
        // int[] weight = new int[] { 100, 120, 150, 200, 50 };
        // int[] value = new int[] { 500, 79, 59, 39, 10 };
        // int[] count = new int[] { 2, 3, 1, 10, 20 };
        // int[] mpcount = new int[] { 1, 1, 1, 1, 1 };
        //int[] h1count = new int[] { -1, -1, -1, -1, -1 };
        // int[] h0count = new int[] { 0, 0, 0, 0, 0 };
        // int[] hcount = new int[] { 1, 0, 0, 6, 1 };
        // ZeroOnePacket zop = new ZeroOnePacket();
        // System.Console.WriteLine(zop.ZeroOnePacketMethod(weight, value, 400));
        // System.Console.WriteLine(zop.ZeroOnePacketMethodArray(weight, value, 400));
        // int[] nums = new int[] { 1, 5, 11, 2 };
        // System.Console.WriteLine(zop.CanPartition(nums));
        /*
        完全背包
        */
        // CompletePacket cp = new CompletePacket();
        // System.Console.WriteLine(cp.CompletePacketMethod(weight, value, 400));
        // System.Console.WriteLine(cp.CompletePacketMethodArray(weight, value, 400));
        /*
        多重背包
        */
        // MultiplePacket mp = new MultiplePacket();
        // System.Console.WriteLine(mp.MultiplePacketMethod(weight, value, count, 400));
        // System.Console.WriteLine(mp.MultiplePacketMethodArray(weight, value, count, 400));
        /*
        二进制分组
        2=1+1；5=1+2+2；3=1+2；10=1+2+4+3；20=1+2+4+8+5
        */
        // System.Console.WriteLine(mp.MultiplePacketMethodBit(weight, value, count, 400));
        //全1
        // System.Console.WriteLine(mp.MultiplePacketMethod(weight, value, mpcount, 400));
        // System.Console.WriteLine(mp.MultiplePacketMethodArray(weight, value, mpcount, 400));
        // System.Console.WriteLine(mp.MultiplePacketMethodBit(weight, value, mpcount, 400));
        /*
        混合背包
        */
        // HybridPacket hp = new HybridPacket();
        // System.Console.WriteLine(hp.HybridPacketMethod(weight, value, h0count, 400));
        // System.Console.WriteLine(hp.HybridPacketMethodBit(weight, value, h0count, 400));
        /*
        分组背包
        */
        // GroupPacket gp = new GroupPacket();
        // int[] groupCount = new int[] { 2, 2, 2 };
        // int[][] gpWeight = new int[][] { [100, 120], [200, 50], [100, 30] };
        // int[][] gpValue = new int[][] { [500, 79], [39, 10], [59, 20] };
        // System.Console.WriteLine(gp.GroupPacketMethod(groupCount, gpWeight, gpValue, 400));
        // System.Console.WriteLine(gp.GroupPacketMethodArray(groupCount, gpWeight, gpValue, 400));
        /*
        二维费用背包
        */
        // int[] volume = new int[] { 24, 40, 2300, 2000, 100 };
        // TwoDimensionalPacket tdp = new TwoDimensionalPacket();
        // System.Console.WriteLine(tdp.TwoDimensionalPacketArray(weight, volume, value, 400, 2000));
        /*
        其它背包
        */
        // int[] otherweight = new int[] { 100, 300, 350, 120, 150, 200, 50 };
        // int[] othervalue = new int[] { 500, 109, 579, 59, 39, 10, 50 };
        //int[] otherweight = new int[] { 100, 300, 350, 120, 150, 200, 50 };
        //int[] othervalue = new int[] { 500, 129, 579, 59, 39, 10, 50 };
        //OtherPacket fp = new OtherPacket();
        //恰好装满背包
        // System.Console.WriteLine(fp.FullPacketMethod(otherweight, othervalue, 400));
        //装满背包的方案总数
        // System.Console.WriteLine(fp.TotalPacketSolution(otherweight, othervalue, 400));
        //方案路径
        // var path = fp.ZeroOnePacketPath(otherweight, othervalue, 400);
        // System.Console.WriteLine(string.Join(",", path));
        //最优方案数
        // System.Console.WriteLine(fp.BestPacketSolution(otherweight, othervalue, 400));
        // var resultSolution = fp.BestPacketSolutionDetail(otherweight, othervalue, 400);
        // foreach (var index in resultSolution)
        // {
        //     Console.WriteLine($"物品索引: {index}, 重量: {otherweight[index]}, 价值: {othervalue[index]}");
        // }
        // var resutlAllSolutions = fp.BestPacketAllSolutions(otherweight, othervalue, 400);
        // for (int i = 0; i < resutlAllSolutions.Count; i++)
        // {
        //     System.Console.WriteLine($"最优方案{i + 1}:");
        //     foreach (var index in resutlAllSolutions[i])
        //     {
        //         Console.WriteLine($"物品索引: {index}, 重量: {otherweight[index]}, 价值: {othervalue[index]}");
        //     }
        // }
        //背包的第 k 优解
        // for (int i = 100; i > 0; i--)
        // {
        //     System.Console.WriteLine(fp.ZeroOnePacketBestK(weight, value, 400, i));
        // }
        /*
        区间DP
        */
        // IntervalDP idp = new IntervalDP();
        // string s = "bbbab";
        // System.Console.WriteLine(idp.LongestPalindromeSubseq(s));
        // int[] nums = new int[] { 3, 1, 5, 8 };
        // int[] nums2 = new int[] { 1, 5 };
        // System.Console.WriteLine(idp.MaxCoins(nums));
        // System.Console.WriteLine(idp.MaxCoins(nums2));
        /*计数DP*/
        CountDP cdp = new CountDP();
        System.Console.WriteLine(cdp.UniquePaths(2, 3));
        System.Console.WriteLine(cdp.IntegerBreak(11));




    }
}
