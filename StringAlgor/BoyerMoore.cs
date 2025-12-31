
namespace StringAlgor;

public class BoyerMoore
{
    /// <summary>
    /// Boyer-Moore 字符串匹配算法
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int BoyerMooreAlgor(string a, string b)
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
        //生成好后缀规则表
        int[] gs_list = GenerateGoodSuffixArray(b);
        int i = 0;
        while (i <= n - m)
        {
            //从后往前比较
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
            int bcd = bc_table.ContainsKey(a[i + j]) ? bc_table[a[i + j]] : -1;
            //根据坏字符规则获取距离
            int bad_move = j - bcd;
            //根据好后辍规则获取距离
            int good_move = gs_list[j];
            //取俩规则最大值。
            i += Math.Max(bad_move, good_move);
        }
        return -1;
    }
    /// <summary>
    /// 记录子字符串中每个字符最后出现的下标位置
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public Dictionary<char, int> GenerateBadCharTable(string b)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < b.Length; i++)
        {
            dict[b[i]] = i;
        }
        return dict;
    }
    /// <summary>
    /// 生成 suffix 数组
    /// 即最大的k使得p[i-k+1:i+1]==p[m-k:m]。
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>suffix[i] 表示以 i 结尾的子字符串（p[0:i+1]）与模式串后缀的最大匹配长度。

    public int[] GetSuffixArray(string b)
    {
        int m = b.Length;
        int[] suffix = new int[m];
        //最后一个字符的后缀必然和自身完全匹配，长度为 m
        suffix[m - 1] = m;
        //从倒数第二个字符开始向前遍历
        for (int i = m - 2; i > 0; i--)
        {
            //j 指向当前子串的起始位置
            int j = i;
            //比较 b[j] 与 b[m-1-(i-j)]，即从后缀和子串末尾同时向前比较
            while (j >= 0 && b[j] == b[m - 1 - (i - j)])
            {
                j--;
            }
            //以 i 结尾的子串与模式串后缀的最大匹配长度为 i - j
            suffix[i] = i - j;
        }
        return suffix;
    }
    /// <summary>
    /// 生成好后缀规则表gs_list
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>gs_list[j] 表示在 j 处遇到坏字符时可向右移动的距离。
    public int[] GenerateGoodSuffixArray(string b)
    {
        int m = b.Length;
        int[] gs_list = new int[m];
        //情况3：默认全部初始化为 m，表示完全不匹配时的最大移动
        for (int i = 0; i < m; i++)
        {
            gs_list[i] = m;
        }
        //生成后缀数组
        int[] suffix = GetSuffixArray(b);
        //j 表示好后缀前的坏字符位置
        int j = 0;
        //情况 2：从后往前遍历，i 表示前缀的结尾下标
        for (int i = m - 1; i > 0; i--)
        {
            //如果 suffix[i] == i + 1，说明 b[0: i+1] == b[m-i-1: m]，即前缀和后缀相等
            if (suffix[i] == i + 1)
            {
                //对于所有 j < m-i-1 的位置，如果还未被更新，则设置为 m-i-1
                while (j < m - i - 1)
                {
                    if (gs_list[j] == m)
                    {
                        //更新移动距离
                        gs_list[j] = m - i - 1;
                    }
                    j++;
                }
            }
        }
        //情况 1：模式串中存在与好后缀完全相同的子串,k表示好后缀的右端点
        for (int k = 0; k < m - 1; k++)
        {
            //更新在好后缀左端点遇到坏字符时的移动距离,
            //m-1-suffix[k] 是好后缀的左端点,
            //m-k-1 是可移动的距离
            gs_list[m - 1 - suffix[k]] = m - k - 1;
        }
        return gs_list;
    }
}
