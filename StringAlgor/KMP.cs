
namespace StringAlgor;

/// <summary>
/// KMP算法
/// </summary>
public class KMP
{
    
    /// <summary>
    /// KMP算法
    /// </summary>
    /// <param name="haystack"></param>
    /// <param name="needle"></param>
    /// <returns></returns>
    public int KMPAlgor(string haystack, string needle)
    {
        int n = haystack.Length;
        int m = needle.Length;
        if (m == 0)
        {
            return 0;
        }
        if (n < m)
        {
            return -1;
        }
        int[] next = new int[m];
        //按字字符串生成nextO数组，记录最长的相前后辍的长度
        GetNext(next, needle);
        //子字符串索引位置
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            //如果当前字符不匹配，且 j > 0，则回退 j 到 next[j-1]
            while (j > 0 && needle[j] != haystack[i])
            {
                j = next[j - 1];
            }
            //如果当前字符匹配，继续。
            if (needle[j] == haystack[i])
            {
                j++;
            }
            //如果相同，返回匹配开始的位置。
            if (j == m)
            {
                return i - m + 1; //返回匹配开始的位置
            }
        }
        return -1;
    }
    /// <summary>
    /// 生成next数组，获取子字符串最长相等前后缀
    /// </summary>
    /// <param name="next"></param>
    /// <param name="s"></param>
    public static void GetNext(int[] next, string s)
    {
        //s=“ABCABDEF”==>[0,0,0,1,2,0,0,0]
        int k = 0;//当前已知的最长相等前后缀的长度
        next[0] = 0;
        for (int i = 1; i < s.Length; i++)
        {
            //如果前后缀不相等，尝试回退 left 到更短的前后缀
            while (k > 0 && s[i] != s[k])
            {
                //回退到上一个最长相等前后缀,尝试寻找更短的相等前后缀
                k = next[k - 1];
            }
            //如果前后缀相等，最长相等前后缀长度继续延长
            if (s[i] == s[k])
            {
                k++;
            }
            //记录当前最长相等前后缀长度
            next[i] = k;
        }
    }

}
