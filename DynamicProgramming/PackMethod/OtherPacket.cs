using System;
using System.ComponentModel.DataAnnotations;

namespace DynamicProgramming.PackMethod;
/// <summary>
/// 背包装满
/// </summary>
public class OtherPacket
{
    /// <summary>
    /// 背包恰好装满
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="value"></param>每种物品的价值
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>如果背包在刚好装满的情况下返回最大可获得价值，不能装满-1
    public int FullPacketMethod(int[] weight, int[] value, int W)
    {
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        //初始化何时未装入任物品，如果要求恰好装满背包；初始为0，其它为负无穷大。
        int m = weight.Length;
        double[] dp = new double[W + 1];
        for (int i = 0; i <= W; i++)
        {
            dp[i] = -double.PositiveInfinity;
        }
        //初始状态
        dp[0] = 0;
        /*
        ###根据不同的背包问题选择不同的滚动数组方式###
        */
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];
            if (curWeight > W || curWeight <= 0)
            {
                continue;
            }
            //倒序遍历背包容量
            for (int j = W; j >= curWeight; j--)
            {
                dp[j] = Math.Max(dp[j], dp[j - curWeight] + curValue);
            }
        }
        //System.Console.WriteLine(dp[W]);
        //判断背包是否恰好装满
        return dp[W] == -double.PositiveInfinity ? -1 : (int)dp[W];
    }
    /// <summary>
    /// 背包问题解决方案总数目
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="value"></param>每种物品的价值
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>当总重量不超过背包载重上限的情况下，一共有多少种方案？
    public int TotalPacketSolution(int[] weight, int[] value, int W)
    {
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        int[] dp = new int[W + 1];
        ////初始状态
        dp[0] = 1;
        /*
        ##根据不同的背包问题选择不同的滚动数组方式###
        */
        //遍历每一种物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            if (curWeight > W || curWeight <= 0)
            {
                continue;
            }
            for (int j = W; j >= curWeight; j--)
            {
                //求和
                dp[j] = dp[j] + dp[j - curWeight];
            }
        }
        return dp[W];
    }
    /// <summary>
    /// 最优方案数
    /// </summary>
    /// <param name="weight"></param>每种物品的重量
    /// <param name="value"></param>每种物品的价值
    /// <param name="W"></param>背包最大承重
    /// <returns></returns>返回最优方案数
    public int BestPacketSolution(int[] weight, int[] value, int W)
    {
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return 0;
        }
        int m = weight.Length;
        //最大价值
        int[] dp = new int[W + 1];
        //方案数
        int[] op = new int[W + 1];
        //初始化为1，即什么也不放入。
        for (int i = 0; i <= W; i++)
        {
            op[i] = 1;
        }
        /*
        若恰好装备背包：
        double[] dp = new double[W + 1];
        for (int i = 0; i <= W; i++)
        {
            dp[i] = -double.PositiveInfinity;
            op[i] = 0;
        }
        dp[0] = 0
        op[0] = 1;
        */
        //遍历物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];
            //倒序遍历背包容量
            for (int j = W; j >= curWeight; j--)
            {
                /*
                若恰好装备背包增加判断：
                if(dp[j-curWeight]!=-double.PositiveInfinity)
                */
                //选择当前物品时的价值。
                int newValue = dp[j - curWeight] + curValue;
                //如果价值更大，更新最大值和方案数
                if (newValue > dp[j])
                {
                    dp[j] = newValue;
                    op[j] = op[j - curWeight];
                }
                //如果相等，方案累加
                else if (newValue == dp[j])
                {
                    op[j] += op[j - curWeight];
                }
            }
        }
        return op[W];
    }
    /// <summary>
    /// 返回最优方案的下标(若多个，返回其中一个)
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public List<int> BestPacketSolutionDetail(int[] weight, int[] value, int W)
    {
        List<int> result = new List<int>();
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return result;
        }
        int m = weight.Length;
        //最大价值
        int[] dp = new int[W + 1];
        //方案数
        int[] op = new int[W + 1];
        //是否选择物品加入背包
        int[] choice = new int[W + 1];
        //初始化为1，即什么也不放入。
        for (int i = 0; i <= W; i++)
        {
            op[i] = 1;
            choice[i] = -1;
        }

        //遍历物品
        for (int i = 0; i < m; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];
            //倒序遍历背包容量
            for (int j = W; j >= curWeight; j--)
            {
                //选择当前物品时的价值。
                int newValue = dp[j - curWeight] + curValue;
                //如果价值更大，更新最大值和方案数
                if (newValue > dp[j])
                {
                    dp[j] = newValue;
                    op[j] = op[j - curWeight];
                    choice[j] = i;
                }
                //如果相等，方案累加
                else if (newValue == dp[j])
                {
                    op[j] += op[j - curWeight];
                }
            }
        }
        int w = W;
        while (w > 0)
        {
            int index = choice[w];
            if (index == -1)
            {
                // 如果找不到对应的物品，跳出循环。
                break;
            }
            result.Add(index);
            // 减去当前物品的重量，查看前一个状态
            w -= weight[index];
        }

        return result;

    }
    /// <summary>
    /// 全部方案的下标
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public List<List<int>> BestPacketAllSolutions(int[] weight, int[] value, int W)
    {
        List<List<int>> results = new List<List<int>>();
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return results;
        }

        int m = weight.Length;
        // 1. 使用二维数组进行 DP 计算，记录状态以便回溯
        // dp[i, j] 表示使用前 i 个物品，在容量为 j 时的最大价值
        int[,] dp = new int[m + 1, W + 1];

        // 遍历物品
        for (int i = 1; i <= m; i++)
        {
            int curWeight = weight[i - 1];
            int curValue = value[i - 1];
            //遍历背包重量
            for (int j = 0; j <= W; j++)
            {
                // 不选当前物品时。
                dp[i, j] = dp[i - 1, j];

                // 如果可以装下当前物品，选当前物品能获得更大价值，更新。
                if (j >= curWeight)
                {
                    int newValue = dp[i - 1, j - curWeight] + curValue;
                    if (newValue > dp[i, j])
                    {
                        dp[i, j] = newValue;
                    }
                }
            }
        }

        // 2. 使用 DFS 回溯寻找所有路径
        List<int> currentPath = new List<int>();
        FindAllPaths(dp, weight, value, m, W, currentPath, results);
        return results;
    }

    /// <summary>
    /// 递归回溯函数
    /// </summary>
    /// <param name="dp"></param>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="i"></param>当前考虑第 i 个物品 (1 ~ m)
    /// <param name="currentW"></param>当前剩余容量
    /// <param name="currentPath"></param>当前路径
    /// <param name="results"></param>
    private void FindAllPaths(int[,] dp, int[] weight, int[] value, int i, int currentW, List<int> currentPath, List<List<int>> results)
    {
        // 递归退出条件：处理完所有物品，或背包装不下。
        if (i == 0)
        {
            List<int> solution = new List<int>(currentPath);
            solution.Sort();
            results.Add(solution);
            return;
        }

        int itemIndex = i - 1;
        int maxVal = dp[i, currentW];

        //不选当前物品，得到最大价值
        if (dp[i - 1, currentW] == maxVal)
        {
            //路径不包含当前物品，继续向前查找
            FindAllPaths(dp, weight, value, i - 1, currentW, currentPath, results);
        }

        //选第当前物品，得到最大价值
        if (currentW >= weight[itemIndex])
        {
            if (dp[i - 1, currentW - weight[itemIndex]] + value[itemIndex] == maxVal)
            {
                //路径包含当前物品，加入路径，容量减少，继续向前查找
                currentPath.Add(itemIndex);
                FindAllPaths(dp, weight, value, i - 1, currentW - weight[itemIndex], currentPath, results);
                //回溯：移除刚加入的物品，以便尝试其他可能性
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
    /// <summary>
    /// 具体方案（其中一个）
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    public List<int> ZeroOnePacketPath(int[] weight, int[] value, int W)
    {
        List<int> result = new List<int>();
        if (weight == null || value == null || weight.Length == 0 || W <= 0)
        {
            return result;
        }
        int m = weight.Length;
        int[,] dp = new int[m + 1, W + 1];
        //记录状态转移时，false：不选择前一项，true：选择。回溯时再根据选择进行判断。
        bool[,] path = new bool[m + 1, W + 1];

        //如输出最小的方案，倒置重量和价值
        //Array.Reverse(weight);
        //Array.Reverse(value);
        for (int i = 1; i <= m; i++)
        {
            for (int j = 0; j <= W; j++)
            {
                if (j < weight[i - 1])
                {
                    dp[i, j] = dp[i - 1, j];
                    path[i, j] = false;
                }
                else if (dp[i - 1, j] < dp[i - 1, j - weight[i - 1]] + value[i - 1])
                {
                    dp[i, j] = dp[i - 1, j - weight[i - 1]] + value[i - 1];
                    path[i, j] = true;
                }
                else if (dp[i - 1, j] == dp[i - 1, j - weight[i - 1]] + value[i - 1])
                {
                    dp[i, j] = dp[i - 1, j];
                    path[i, j] = true;
                }
            }
        }
        //回溯。
        int w = W;
        for (int i = m; i >= 1; i--)
        {
            if (path[i, w])
            {
                result.Add(i - 1);
                w -= weight[i - 1];
            }
        }
        return result;
    }
    /// <summary>
    /// 背包的第 K 优解
    /// </summary>
    /// <param name="weight"></param>
    /// <param name="value"></param>
    /// <param name="W"></param>
    /// <param name="K"></param>前 k 优解
    /// <returns></returns>
    public int ZeroOnePacketBestK(int[] weight, int[] value, int W, int K)
    {
        int n = weight.Length;

        // 存储前 K 个最大价值
        List<int>[] dp = new List<int>[W + 1];

        // 初始化
        for (int i = 0; i <= W; i++)
        {
            // 初始时，所有容量的最优解只有 0（即什么都不装入）
            dp[i] = new List<int> { 0 };
        }

        // 遍历每一个物品
        for (int i = 0; i < n; i++)
        {
            int curWeight = weight[i];
            int curValue = value[i];

            // 0-1 背包：倒序遍历容量，，确保每个物品只被选一次
            for (int j = W; j >= curWeight; j--)
            {
                // 不选当前物品的列表
                List<int> listA = dp[j];
                // 选当前物品的列表
                List<int> listB = dp[j - curWeight];

                // 合并两个有序列表（归并排序）
                List<int> merged = new List<int>();
                int p1 = 0, p2 = 0;
                while (p1 < listA.Count && p2 < listB.Count && merged.Count < K)
                {
                    int valA = listA[p1];
                    //加上当前物品价值
                    int valB = listB[p2] + curValue;

                    if (valA > valB)
                    {
                        merged.Add(valA);
                        p1++;
                    }
                    else
                    {
                        merged.Add(valB);
                        p2++;
                    }
                }

                // 处理剩余元素
                while (p1 < listA.Count && merged.Count < K)
                {
                    merged.Add(listA[p1++]);
                }
                while (p2 < listB.Count && merged.Count < K)
                {
                    merged.Add(listB[p2++] + curValue);
                }
                dp[j] = merged;
            }
        }
        //处理边界（小数情况下）
        if (K < dp[W].Count)
        {
            return dp[W][K - 1];
        }
        else
        {
            K = dp[W].Count;
            return dp[W][K - 1];
        }
    }
    /// <summary>
    /// 依赖背包
    /// </summary>
    /// <param name="weight"></param>物品的重量
    /// <param name="value"></param>物品的价值
    /// <param name="parents"></param>对应的附属件（父件）
    /// <param name="W"></param>背包最大重量
    /// <returns></returns>

    public int TreePacket(int[] weight, int[] value, int[] parents, int W)
    {
        int m = weight.Length;
        // 为了处理森林，增加一个虚拟根节点 0
        List<int>[] tree = new List<int>[m + 1];
        for (int i = 0; i <= m; i++)
        {
            tree[i] = new List<int>();
        }

        for (int i = 1; i <= m; i++)
        {
            // 没有父节点的挂到虚拟根节点0上
            if (parents[i - 1] == -1)
            {
                tree[0].Add(i);
            }
            //挂到相应的父节点上
            else
            {
                tree[parents[i - 1]].Add(i);
            }
        }


        // 使用容量 j 时的最大价值
        int[][] dp = new int[m + 1][];

        // DFS (后序遍历)
        DFS(0, W, tree, weight, value, dp);
        return dp[0][W];
    }
    /// <summary>
    /// 树形动态规划
    /// </summary>
    /// <param name="u"></param>当前节点
    /// <param name="capacity"></param>当前可用的总背包容量
    /// <param name="tree"></param>树的邻接表
    /// <param name="volumes"></param>体积数组
    /// <param name="values"></param>价值数组
    /// <param name="dp"></param>
    /// <returns></returns>
    static int[] DFS(int u, int capacity, List<int>[] tree, int[] volumes, int[] values, int[][] dp)
    {
        // 初始化当前节点的 dp 数组
        dp[u] = new int[capacity + 1];

        // 对于非虚拟根节点,如果容量不足以装下当前节点，放弃。
        for (int j = volumes[u]; j <= capacity; j++)
        {
            dp[u][j] = values[u];
        }
        // 遍历子节点 (分组背包思路：把每个子节点看作一组)
        foreach (int child in tree[u])
        {
            // 递归处理子节点
            DFS(child, capacity, tree, volumes, values, dp);

            // 外层循环：当前节点 u 的总容量 j
            for (int j = capacity; j >= volumes[u]; j--)
            {
                // 内层循环：分给子节点 child 的容量 k
                // 子节点最多能分到 j - volumes[u] (因为 u 本身要占 volumes[u])
                for (int k = 0; k <= j - volumes[u]; k++)
                {
                    // 状态转移：
                    // 不选 child 的子树: dp[u][j] (原值)
                    // 选 child 的子树: dp[u][j - k] + dp[child][k]
                    dp[u][j] = Math.Max(dp[u][j], dp[u][j - k] + dp[child][k]);
                }
            }
        }

        return dp[u];
    }
}
