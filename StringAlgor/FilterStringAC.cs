using System;
using System.Globalization;
using System.Text;

namespace StringAlgor;

//过滤字符
public class FilterStringAC
{
    public FilterTrieNode root;
    public FilterStringAC()
    {
        root = new FilterTrieNode();
    }
    public void AddWord(HashSet<string> words)
    {
        foreach (var w in words)
        {
            var cur = root;
            for (int i = 0; i < w.Length; i++)
            {
                char ch = w[i];
                if (!cur.children.ContainsKey(ch))
                {
                    cur.children[ch] = new FilterTrieNode();
                }
                cur = cur.children[ch];
            }
            cur.isEnd = true;
        }
    }
    public string FilterSearch(string text)
    {
        StringBuilder result = new StringBuilder();
        int index = 0;
        while (index < text.Length)
        {
            int matchLen = CheckFilterWord(text, index);
            if (matchLen > 0)
            {
                result.Append('*',matchLen);
                index += matchLen;
            }
            else
            {
                result.Append(text[index]);
                index++;
            }
        }
        return result.ToString();
    }
    public int CheckFilterWord(string text, int index)
    {
        var cur = root;
        int lenth = 0;
        for (int i = index; i < text.Length; i++)
        {
            char ch = text[i];
            if (!cur.children.ContainsKey(ch))
            {
                break;
            }
            cur = cur.children[ch];
            lenth++;
            if (cur.isEnd)
            {
                return lenth;
            }
        }
        return 0;
    }
}
public class FilterTrieNode
{
    public Dictionary<char, FilterTrieNode> children = new Dictionary<char, FilterTrieNode>();
    public bool isEnd = false;
}


