using System.Text;

namespace DynamicProgramming;
/// <summary>
/// 二维线性DP（双串）
/// </summary>
public class DoubleLinearDP
{
    /// <summary>
    /// 最长公共子序列
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns>返回两个字符串的最长公共子序列</returns>
    public string LongestCommonSubsequence(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                //当前字符相同,+1
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                //当前字符不同,取左边或上边较大的值。
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        int x = m;
        int y = n;
        StringBuilder sb = new StringBuilder();
        while (x > 0 && y > 0)
        {
            if (s1[x - 1] == s2[y - 1])
            {
                // 如果字符相等，
                sb.Append(s1[x - 1]);
                x--;
                y--;
            }
            else
            {
                // 如果不相等，向数值较大的方向移动
                if (dp[x - 1, y] > dp[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
        }
        var result = sb.ToString().ToArray();
        Array.Reverse(result);
        return new string(result);
    }
    /// <summary>
    /// 最长重复子数组
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns>计算两个数组中公共的、长度最长的子数组长度。</returns>

    public int FindLength(int[] nums1, int[] nums2)
    {
        //取短的数组作一维动态，如果nums1小于nums2,调换位置。
        if (nums1.Length < nums2.Length)
        {
            return FindLength(nums2, nums1);
        }
        int m = nums1.Length;
        int n = nums2.Length;
        //一维
        int[] dp = new int[n + 1];

        for (int i = 1; i <= m; i++)
        {
            //临时变量记录 dp[i-1][j-1]
            int prev = 0;
            for (int j = 1; j <= n; j++)
            {
                //// temp 记录的是更新前的 dp[j]，即上一行的值 (dp[i-1][j])
                int temp = dp[j];
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[j] = prev + 1;
                }
                else
                {
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                }
                // 更新 prev 为下一轮的 dp[i-1][j-1]
                prev = temp;
            }
        }
        return dp[n];
    }
    /// <summary>
    /// 编辑距离
    /// 插入一个字符
    /// 删除一个字符
    /// 替换一个字符
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns>操作多少次后s1=s2.</returns>
    public int MinDistance(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;
        int[,] dp = new int[m + 1, n + 1];
        //状态转换首行和首列
        for (int i = 0; i < m + 1; i++)
        {
            dp[i, 0] = i;
        }
        for (int j = 0; j < n + 1; j++)
        {
            dp[0, j] = j;
        }
        //状态转移：其余行和列
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                //如果相等则路过
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                //否则，取三种操作的最小值+1
                //替换：dp[i-1,j-1]
                //插入：dp[i,j-1]
                //删除：dp[i-1,j]
                else
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j], dp[i, j - 1])) + 1;
                }
            }
        }
        return dp[m, n];
    }
    /// <summary>
    /// 编辑距离：空间优化
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public int MiniDistanceDP(string s1, string s2)
    {
        int n = s1.Length, m = s2.Length;
        int[] dp = new int[m + 1];
        //状态转移：首行
        for (int j = 1; j <= m; j++)
        {
            dp[j] = j;
        }
        //状态转移：其余行
        for (int i = 1; i <= n; i++)
        {
            //状态转移：首列
            //暂存首位 dp[i-1, j-1]
            int leftup = dp[0];
            dp[0] = i;
            //状态转移：其余列
            for (int j = 1; j <= m; j++)
            {
                //记下当前值
                int temp = dp[j];
                //若两字符相等，则直接跳过此两字符
                if (s1[i - 1] == s2[j - 1])
                {
                    dp[j] = leftup;
                }
                //否则，取三种操作的最小值+1
                else
                {
                    dp[j] = Math.Min(Math.Min(dp[j - 1], dp[j]), leftup) + 1;
                }
                //更新下一轮循环的首位
                leftup = temp;
            }
        }
        return dp[m];
    }
}
