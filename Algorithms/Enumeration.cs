using System.Text;

namespace Algorithms;

public class Enumeration
{
    /// <summary>
    /// 枚举
    /// </summary>
    /// <param name="nums"></param>数组
    /// <returns></returns>数组里两个数之和等于10的组数。
    public int TwoSum(int[] nums)
    {
        int m = nums.Length;
        int result = 0;
        //枚举
        for (int i = 0; i < m; i++)
        {
            ///for (int j = 0; j < m; j++)
            for (int j = 0; j < i; j++)
            {
                if (nums[i] + nums[j] == 10)
                {
                    result++;
                }
            }
        }
        return result * 2;
    }
    /// <summary>
    /// 组合，
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public List<string> Combination(string s)
    {
        List<string> result = new List<string>();
        int m = s.Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j <= m - i; j++)
            {
                result.Add(s.Substring(i, j));
            }
        }
        return result;
    }
}
