namespace StringAlgor;

public class AhoCorasickAutomaton<TKey, TValue> where TValue : IEnumerable<TKey>
{
    //初始化字典树
    public TrieNode<TKey, TValue> root { get; private set; }

    public AhoCorasickAutomaton()
    {
        root = new TrieNode<TKey, TValue>();
    }
    /// <summary>
    /// 构建字典树，将模型串元素插入字典树中。
    /// </summary>
    /// <param name="pattern">模型串</param>

    public void InsertNode(TValue pattern)
    {
        var curNode = root;
        foreach (var ch in pattern)
        {
            //如果不存在当前模型串元素，创建新的节点后加入字典树。
            if (!curNode.Children.ContainsKey(ch))
            {
                curNode.Children[ch] = new TrieNode<TKey, TValue>();
            }
            //移动到子节点，继续插入
            curNode = curNode.Children[ch];
        }
        //标记模式串结尾
        curNode.IsEnd = true;
        //存储完整模式串
        curNode.Pattern = pattern;
    }
    /// <summary>
    /// 构建失配指针
    /// </summary>
    public void BuildFailPointers()
    {
        var queue = new Queue<TrieNode<TKey, TValue>>();
        //根节点的所有子节点的失配指针都指向根节点，并加入队列。
        foreach (var child in root.Children.Values)
        {
            child.FailPointer = root;
            queue.Enqueue(child);
        }
        //BFS广度优先遍历所有其它子节点，将其失配指针从父节点的失配指针开始查找。
        // 如果找到对应key的子节点，则指向该子节点；
        // 否则继续向上查找，直到找到或到达根节点。
        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();
            foreach (var item in cur.Children)
            {
                //当前子节点的Key和Value值
                TKey key = item.Key;
                var child = item.Value;

                // 从当前节点的失配指针开始，向上寻找有无相同key的子节点
                var FailPointer = cur.FailPointer;
                while (FailPointer != null && !FailPointer.Children.ContainsKey(key))
                {
                    FailPointer = FailPointer.FailPointer;
                }
                //找到就指向该节点，否则指向根节点。
                if (FailPointer != null && FailPointer.Children.ContainsKey(key))
                {
                    child.FailPointer = FailPointer.Children[key];
                }
                else
                {
                    child.FailPointer = root;
                }
                queue.Enqueue(child);
            }
        }
    }
    /// <summary>
    /// 查找所有模式串出现的位置
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public IEnumerable<TValue> Search(IEnumerable<TKey> text)
    {
        var result = new List<TValue>();
        var cur = root;
        if (text == null) return result;

        foreach (var ch in text)
        {
            // 如果当前节点没有该字符的子节点，则沿失配指针向上跳转
            while (cur != root && !cur.Children.ContainsKey(ch))
            {
                cur = cur.FailPointer;
            }
            //如果有该字符的子节点，则转移到该子节点
            if (cur.Children.ContainsKey(ch))
            {
                cur = cur.Children[ch];
            }

            //检查当前节点以及沿失配指针上的所有节点是否为单词结尾
            var temp = cur;
            while (temp != null && temp != root)
            {
                if (temp.IsEnd)
                {
                    result.Add(temp.Pattern);
                }
                temp = temp.FailPointer;
            }
            if (cur == root && cur.IsEnd)
            {
                result.Add(cur.Pattern);
            }
        }
        return result;
    }
    public void FilterSerch(IEnumerable<TKey> text)
    {
        
    }
}
/// <summary>
/// 泛型字典树节点
/// </summary>
/// <typeparam name="TKey">构成模式串的基本单元类型</typeparam>
/// <typeparam name="TValue">完整的模式串类型 </typeparam>
public class TrieNode<TKey, TValue>
{
    //子节点,
    public Dictionary<TKey, TrieNode<TKey, TValue>> Children = new Dictionary<TKey, TrieNode<TKey, TValue>>();
    //失配指针。
    public TrieNode<TKey, TValue> FailPointer;
    //是否模型串的末尾。
    public bool IsEnd;
    //存储完整的模型串。
    public TValue Pattern;
}