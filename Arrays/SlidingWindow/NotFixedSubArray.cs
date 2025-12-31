
namespace Arrays;

public class NotFixedSubArray
{
    /// <summary>
    /// 3. 无重复字符的最长子串
    /// 滑动窗口（可变长度窗口）
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>

    public static int NotFixedSubArrayWindow(string s)
    {
        int m = s.Length;
        //窗口子数组左边界和右边界
        int left = 0;
        int right = 0;
        //记录窗口内每个字符出现的次数
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int result = 0;

        while (right < m)
        {
            //将当前字符加入窗口，统计出现次数
            if (dict.ContainsKey(s[right]))
            {
                dict[s[right]]++;
            }
            else
            {
                dict.Add(s[right], 1);
            }
            //如果当前字符出现次数大于1，说明有重复，需要收缩左边界
            while (dict[s[right]] > 1)
            {
                dict[s[left]]--;
                left++;
            }
            //更新最长无重复子串的长度
            result = Math.Max(result, right - left + 1);
            //右边界右移
            right++;
        }
        return result;
    }

}
