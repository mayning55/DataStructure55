using System;

namespace StringAlgor;

/// <summary>
/// 朴素匹配算法
/// </summary>
public class BruteForce
{
    /// <summary>
    /// 朴素匹配算法
    /// </summary>
    /// <param name="a"></param>字符串，是否包含b.
    /// <param name="b"></param>字符串b匹配字符串a
    /// <returns></returns>
    public int StringBruteForce(string haystack, string needle)
    {
        int n = haystack.Length;
        int m = needle.Length;
        if (n < m)
        {
            return -1;
        }
        if (m == 0)
        {
            return 0;
        }
        //遍历每个字符会起始下标，（n - m + 1）是子字符串的最小长度，后面的无需遍历。
        for (int i = 0; i < n - m + 1; i++)
        {
            //子字符串索引
            int j = 0;
            while (j < m)
            {
                //如果字符不匹配，退出循环，转入下一位字符
                if (haystack[i + j] != needle[j])
                {
                    break;
                }
                //字符相同，继续匹配
                j++;
            }
            //索引与子字符串长度相同时则完全匹配，返回起始下标。
            if (j == m)
            {
                return i;
            }
        }
        return -1;
    }

}
