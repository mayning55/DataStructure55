using System;

namespace StringAlgor;

public class Sunday
{
    public int SundayAlgor(string a, string b)
    {
        int n = a.Length;
        int m = b.Length;
        if (m == 0)
        {
            return 0;
        }
        if (n < m)
        {
            return -1;
        }
        //生成坏字符表
        Dictionary<char, int> bc_table = GenerateBadCharTable(b);
        //当前窗口在文本串中的起始下标
        int i = 0;
        while (i <= n - m)
        {
            //从左往右，逐字符比较当前窗口是否与模式串完全匹配
            int j = 0;
            while (j < m && a[i + j] == b[j])
            {
                j++;
            }
            //匹配成功，返回起始下标
            if (j == m)
            {
                return i;
            }
            //若检测达到字符串末依然无法匹配，返回-1
            if (i + m >= n)
            {
                return -1;
            }
            //当前窗口末尾的下一个字符
            char nextChar = a[i + m];
            //如果 next_char 在后移位数表中，滑动对应距离，否则滑动 m+1
            int bcd = bc_table.ContainsKey(nextChar) ? bc_table[nextChar] : m + 1;
            i += bcd;
        }
        return -1;

    }
    /// <summary>
    /// 生成 Sunday 算法的后移位数表,记录子字符串中每个字符最右则的距离
    /// </summary>
    /// <param name="b"></param>
    /// <returns>返回生成的后移位数表。bc_table[bad_char] 表示遇到坏字符时可以向右移动的距离</returns>
    public Dictionary<char, int> GenerateBadCharTable(string b)
    {
        int m = b.Length;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        //遍历模式串的每一个字符（包括最后一个字符）
        for (int i = 0; i < m; i++)
        {
            //对于每个字符 b[i]，记录其对应的移动距离= = 模式串长度 - 当前字符下标
            dict[b[i]] = m - i;
        }
        return dict;
    }
}
