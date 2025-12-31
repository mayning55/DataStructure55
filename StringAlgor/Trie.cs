using System;
using System.Collections.Generic;

namespace StringAlgor;

public class Trie
{
    private Node root = new Node();
    /// <summary>
    /// 将字符串插入字典树。
    /// </summary>
    /// <param name="s"></param>
    public void InsertNode(string s)
    {
        if (string.IsNullOrEmpty(s)) return;
        //从根节点开始，
        var cur = root;
        //遍历字符串的每一个字符
        foreach (var ch in s)
        {
            //如果当前节点的子节点不存在字符ch,则创建一个节点加入字典树。
            if (!cur.subNode.TryGetValue(ch, out var next))
            {
                next = new Node();
                cur.subNode[ch] = next;
            }
            //如果存在，则移动到下一节点上，继续插入。
            cur = next;
        }
        //最后，改变状态。
        cur.isEnd = true;
    }
    /// <summary>
    /// 在字典树中查找字符串是否存在。
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    // public bool SearchString(string s)
    // {
    //     //从根节点开始。
    //     var cur = root;
    //     //遍历单词中的每个字符
    //     foreach (var ch in s)
    //     {
    //         //如果当前节点的子节点中不存在该字符，返回false。
    //         if (!cur.subNode.TryGetValue(ch, out var next))
    //         {
    //             return false;
    //         }
    //         //移动到对应的子节点，继续查找下一个字符
    //         cur = cur.subNode[ch];
    //     }
    //     return cur.isEnd;
    // }

    /// <summary>
    /// 在字典树中查找字符串是否存在。通配符.表示任何一个字母
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public bool SearchString(string s)
    {
        //var cur = root;
        return SearchMath(s, 0, root);
    }
    private bool SearchMath(string s, int index, Node node)
    {
        if (index == s.Length)
        {
            return node.isEnd;
        }
        char ch = s[index];
        //如果当前字符是通配符"."
        if (ch == '.')
        {
            //递归匹配当前节点所有子节点，并依次向下查找。
            foreach (var subNode in node.subNode.Values)
            {

                if (subNode != null && SearchMath(s, index + 1, subNode))
                {
                    return true;
                }
            }
        }
        //除通配符"."外，其它按字符串顺序进行匹配
        else
        {
            //如果当前节点的子节点中不存在该字符，返回false。
            if (!node.subNode.TryGetValue(ch, out _))
            {
                return false;
            }
            //按当前字符依次向下查找。
            var subNode = node.subNode[ch];
            if (subNode != null && SearchMath(s, index + 1, subNode))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 在字典树查找指定的字符前辍
    /// </summary>
    /// <param name="pre"></param>
    /// <returns></returns>
    public bool StartWith(string pre)
    {
        var cur = root;
        foreach (var ch in pre)
        {
            //如果当前节点的子节点中不存在该字符，说明前缀不存在，返回 False
            if (!cur.subNode.TryGetValue(ch, out var next))
            {
                return false;
            }
            //移动到对应的子节点，继续查找下一个字符
            cur = cur.subNode[ch];
        }
        return true;
    }


}

public class Node
{
    //用哈希表存储所有子节点，key 为字符，value 为 Node 实例
    public Dictionary<char, Node> subNode = new Dictionary<char, Node>();
    //判断是否字符串的末部。
    public bool isEnd = false;
}
