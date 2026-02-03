using System;

namespace Algorithms;

public class Greedy
{
    /// <summary>
    /// 给小朋友1个饼干
    /// </summary>
    /// <param name="g">想要多在的饼干</param>
    /// <param name="s">饼干的大小</param>
    /// <returns>饼干的大小是否满足小朋友的期望？</returns>
    public int FindContentChildren(int[] g, int[] s)
    {
        int m = g.Length;
        int n = s.Length;
        if (n == 0)
        {
            return 0;
        }
        //分别排序
        Array.Sort(g);
        Array.Sort(s);
        //双指针，从小到大，如果都满足，有请下一位可爱的小朋友。
        for (int i = 0, j = 0; i < m; i++)
        {
            //当饼干大小小于期望时，换个大的饼干给小朋友。
            while (j < n && s[j] < g[i])
            {
                j++;
            }
            //如果最大的饼干都无法满足时，没了。就这样吧。（不能给两个。）
            if (j++ >= n)
            {
                return i;
            }
        }
        return m;
    }
}
