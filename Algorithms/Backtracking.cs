using System;

namespace Algorithms;

public class Backtracking
{
    private List<IList<int>> result = new List<IList<int>>();
    private List<int> temp = new List<int>();
    /// <summary>
    /// 子集
    /// </summary>
    /// <param name="nums"></param>有重复元素的数组
    /// <returns></returns>
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        result = new List<IList<int>>();
        temp = new List<int>();
        Array.Sort(nums);
        SubSetDFS(nums, 0);
        return result;
    }

    private void SubSetDFS(int[] nums, int index)
    {
        //当index大于等于数组长度时递归结束，将临时子集加入结果列表中。
        if (index >= nums.Length)
        {
            result.Add(new List<int>(temp));
            return;
        }
        //将当前元素加入临时子集，
        temp.Add(nums[index]);
        //递归
        SubSetDFS(nums, index + 1);
        //回溯
        temp.RemoveAt(temp.Count - 1);
        ////判断当前元素与下一个元素是否相同。相同则跳过。
        while (index + 1 < nums.Length && nums[index + 1] == nums[index])
        {
            index++;
        }
        //继续递归不同的元素
        SubSetDFS(nums, index + 1);
    }

    /// <summary>
    /// 全排列
    /// </summary>
    /// <param name="nums"></param>有重复元素的数组
    /// <returns></returns>
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        result = new List<IList<int>>();
        temp = new List<int>();
        if (nums.Length == 0)
        {
            return result;
        }
        else
        {
            Array.Sort(nums);
            GeneratePermutations(nums, 0, nums.Length - 1, result);
        }
        return result;
    }
    /// <summary>
    /// 递归处理
    /// </summary>
    /// <param name="array"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="allPermutations"></param>
    private void GeneratePermutations(int[] array, int start, int end, IList<IList<int>> allPermutations)
    {
        //只有一个元素或最后一个元素，添加当前数组
        if (start == end)
        {
            List<int> list = new List<int>();
            foreach (int i in array)
            {
                list.Add(i);
            }
            allPermutations.Add(list);
            return;
        }
        ///将当前元素与后面的元素交换
        for (int i = start; i <= end; i++)
        {
            //是否需要交换
            bool hasSwap = true;
            for (int j = i + 1; j <= end; j++)
            {
                if (array[i] == array[j])
                {
                    hasSwap = false;
                    continue;
                }
            }
            if (hasSwap)
            {
                //将当前元素与下标i的元素交换
                Swap(array, start, i);
                //递归处理下一个元素
                GeneratePermutations(array, start + 1, end, allPermutations);
                //回朔，当前元素与下标i的元素交换 
                Swap(array, start, i);
            }
        }
    }
    /// <summary>
    /// 交换元素
    /// </summary>
    /// <param name="array"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    /// <summary>
    /// 组合和
    /// </summary>
    /// <param name="arrays"></param>有重复元素的数组
    /// <param name="target"></param>排列组合和
    /// <returns></returns>
    public IList<IList<int>> CombinationSum(int[] arrays, int target)
    {
        result = new List<IList<int>>();
        temp = new List<int>();
        Array.Sort(arrays);
        CombinationSumDFS(arrays, 0, target);
        return result;
    }
    private void CombinationSumDFS(int[] nums, int index, int target)
    {
        //如果target为0，添加当前数组到列表
        if (target == 0)
        {
            result.Add(new List<int>(temp));
            return;
        }
        //如果下标超过数组长或者target小于当前元素则返回
        if (index >= nums.Length || target < nums[index])
        {
            return;
        }
        //遍历元素
        for (int i = index; i < nums.Length; i++)
        {
            //跳过相同的重复元素
            if (i > index && nums[i] == nums[i - 1])
            {
                continue;
            }

            temp.Add(nums[i]);
            //递归
            CombinationSumDFS(nums, i + 1, target - nums[i]);
            //移除当前元素
            temp.RemoveAt(temp.Count - 1);
        }
    }
    /// <summary>
    /// 组合个数
    /// </summary>
    /// <param name="n"></param[1...n]的数组范围
    /// <param name="k"></param>元素K个的组合
    /// <returns></returns>
    public IList<IList<int>> CombinationCount(int n, int k)
    {
        result = new List<IList<int>>();
        temp = new List<int>();
        CCDFS(n, k, 1);
        return result;
    }
    private void CCDFS(int n, int k, int m)
    {
        //当元素个数等于k时，加入结果列表。
        if (temp.Count() == k)
        {
            result.Add(new List<int>(temp));
            return;
        }
        //大于元素范围，返回。
        if (m > n)
        {
            return;
        }
        //递归1-N的元素
        for (int i = m; i <= n; i++)
        {
            temp.Add(i);
            CCDFS(n, k, i + 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }
    /// <summary>
    /// 若干个元素组合之和
    /// </summary>
    /// <param name="k"></param>不重复个元素
    /// <param name="kSum"></param>k个元素之和
    /// <returns></returns>
    public IList<IList<int>> CombinationSumK(int k, int kSum)
    {
        result = new List<IList<int>>();
        temp = new List<int>();
        CSKDFS(k, kSum, 1);
        return result;
    }
    private void CSKDFS(int k, int n, int m)
    {
        //如果元素和为0，同时元素个数等于k，添加到结果列表中。
        if (n == 0)
        {
            if (temp.Count == k)
            {
                result.Add(new List<int>(temp));
                return;
            }
        }
        //元素个数大于目标k,或者元素大于范围（1-9）或者大于元素和，返回
        if (temp.Count >= k || m > 9 || m > n)
        {
            return;
        }
        //递归1-9每个数字。
        for (int i = m; i <= 9; i++)
        {

            temp.Add(i);
            CSKDFS(k, n - i, i + 1);
            temp.RemoveAt(temp.Count - 1);
        }
    }

}
