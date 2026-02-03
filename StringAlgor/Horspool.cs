namespace StringAlgor;

public class Horspool
{
    /// <summary>
    /// Horspool 字符串匹配算法
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int HorspoolAlgor(string a, string b)
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
        int i = 0;
        while (i <= n - m)
        {
            //从后往前比较是否匹配
            int j = m - 1;
            while (j >= 0 && a[i + j] == b[j])
            {
                j--;
            }
            //匹配成功，返回起始下标
            if (j < 0)
            {
                return i;
            }
            //取文本串当前窗口最右字符，查表决定滑动距离
            int bcd = bc_table.ContainsKey(a[i + m - 1]) ? bc_table[a[i + m - 1]] : m;
            i += bcd;
        }
        return -1;
    }
    /// <summary>
    /// 生成后移位数表.记录子字符串中每个字符最右则的距离
    /// </summary>
    /// <param name="b"></param>
    /// <returns>返回生成的后移位数表。bc_table[bad_char] 表示遇到坏字符时可以向右移动的距离</returns>
    public Dictionary<char, int> GenerateBadCharTable(string b)
    {
        int m = b.Length;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < m - 1; i++)
        {
            //对于每个字符 b[i]，记录其对应的移动距离= 子字符串长度 - 1 - 当前字符下标
            dict[b[i]] = m - i - 1;
        }
        return dict;
    }

}
