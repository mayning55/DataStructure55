namespace LinkedList;

/// <summary>
/// 单向链表
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListNode<T>
{
    public T val;//节点内容
    public ListNode<T> next;//指向下一节点
    public ListNode(T value)
    {
        val = value;
        next = null;
    }
    public T Value
    {
        get { return val; }
        set { val = value; }
    }
}
/// <summary>
/// 定义ListNode接口
/// </summary>
/// <typeparam name="T"></typeparam>

public interface IListNode<T>
{
    void CreateListNode(T item);//创建链表。
    int GetListNodeLength();//返回链表的长度
    void InsertNode(T item, int index);//将对象节点插入指定index位置
    T DeleteNodeByIndex(int index);//将下标index的节点删除，返回删除节点
    void DeleteNode(T item);//在链表里找出对象，删除
    void UpdateNode(T item, int index);//修改下标index的节点
    T GetNodeValueByIndex(int index);//根据位置查找节点值
    int GetNodeIndex(T item);//根据节点值查找节点所在位置
    ListNode<T> GetListNode();//返回链表
}

/// <summary>
/// ListNode的实现
/// </summary>
/// <typeparam name="T"></typeparam>
public class ListNodeImplementer<T> : IListNode<T>
{
    private ListNode<T> node;
    public ListNodeImplementer()
    {
        node = null;
    }
    /// <summary>
    /// 返回ListNode的长度
    /// </summary>
    /// <returns></returns>
    public int GetListNodeLength()
    {
        if (node == null)
        {
            return 0;
        }
        ListNode<T> cur = node;
        int cnt = 0;
        while (cur != null)
        {
            cnt++;
            cur = cur.next;
        }
        return cnt;
    }
    /// <summary>
    /// 创建链表
    /// </summary>
    /// <param name="item"></param>传入的对象转换新成节点加入到链表的末部
    public void CreateListNode(T item)
    {
        //传入的对象转换新成节点
        ListNode<T> newNode = new ListNode<T>(item);
        //如果链表为空，则新节点就是链表的首节点
        if (node == null)
        {
            node = newNode;
        }
        else
        {
            ListNode<T> cur = node;
            //遍历链表直到末节点
            while (cur.next != null)
            {
                cur = cur.next;
            }
            //在链表末节点下一节点指向新节点。
            cur.next = newNode;
        }
    }
    /// <summary>
    /// 插入节点
    /// </summary>
    /// <param name="item"></param>
    /// <param name="index"></param>
    public void InsertNode(T item, int index)
    {
        ////传入的对象转换新成节点
        ListNode<T> newNode = new ListNode<T>(item);
        ////如果链表为空，则新节点就是链表的首节点
        if (index == 0)
        {
            newNode.next = node;
            node = newNode;
        }
        else
        {
            ListNode<T> cur = node;
            int cnt = 0;
            //遍历链表，找到index前一位节点，下一位就是插入的节点
            while (cur.next != null && cnt < index - 1)
            {
                cur = cur.next;
                cnt++;
            }
            //如果已经在链表末部，在末节点下一节点指向新节点。
            if (cur.next == null)
            {
                cur.next = newNode;
            }
            //插入节点的下一节点指向当前节点的下一节点，再将当前节点指向插入节点。
            else
            {
                newNode.next = cur.next;
                cur.next = newNode;
            }

        }
    }
    /// <summary>
    /// 删除节点
    /// </summary>
    /// <param name="index"></param>要删除节点的下标位置
    /// <returns></returns>删除的节点值
    /// <exception cref="ArgumentException"></exception>
    public T DeleteNodeByIndex(int index)
    {
        //初始化实体泛型对象
        T val = default(T);
        //如果下标小于0，链表首位直接指向下一节点。返回首位节点的值
        if (index <= 0)
        {
            val = node.Value;
            node = node.next;
            return val;
        }
        else
        {
            ListNode<T> cur = node;
            int cnt = 0;
            //遍历链表，cur 移动到第 index - 1 个节点（即待删除节点的前一位）
            while (cur.next != null && cnt < index - 1)
            {
                cnt++;
                cur = cur.next;
            }
            if (cur.next != null)
            {
                //临时节点就是要删除的节点
                ListNode<T> temp = cur.next;
                val = temp.Value;
                //将链表指向删除节点的下一节点
                cur.next = temp.next;
                return val;
            }
            else
            {
                throw new ArgumentException("index超出范围!!!!!");
            }
        }
    }
    /// <summary>
    /// 根据对象内容删除节点
    /// </summary>
    /// <param name="item"></param>
    public void DeleteNode(T item)
    {
        //当链表首位值等转入对象时，直接指向下一节点。
        while (node != null && node.Value.Equals(item))
        {
            ListNode<T> temp = node;
            node = node.next;
            temp = null;
        }
        //如果整个链表都是传入对象，删除后直接返回
        if (node == null)
        {
            return;
        }
        //双指针（慢快）分别指针首节点和次节点，遍历链表找出传入的对象
        ListNode<T> slow = node;
        ListNode<T> fast = node.next;
        while (fast != null)
        {
            //如果快节点等传入对象，慢节点下一节点指向快节点的下一节点，即跳过快节点（传入对象）。
            // 同时，快节点指向慢节点的下一节点。
            if (fast.Value.Equals(item))
            {
                slow.next = fast.next;
                fast = slow.next;
            }
            else
            {
                slow = slow.next;
                fast = fast.next;
            }
        }
    }
    /// <summary>
    /// 更新节点
    /// </summary>
    /// <param name="item"></param>传入的新节点对象
    /// <param name="index"></param>修改的节点下标位置
    public void UpdateNode(T item, int index)
    {
        ListNode<T> cur = node;
        int cnt = 0;
        //遍历链表，找到要更新的节点下标位置
        while (cur != null && cnt != index)
        {
            cur = cur.next;
            cnt++;
        }
        if (cur != null && cnt == index)
        {
            cur.Value = item;
        }
    }
    /// <summary>
    /// 根据节点下标位置返回节点值
    /// </summary>
    /// <param name="index"></param>节点下标位置
    /// <returns></returns>节点值
    /// <exception cref="ArgumentException"></exception>下标超范围
    public T GetNodeValueByIndex(int index)
    {
        T val = default(T);
        //如果下标小于0，链表首位直接指向下一节点。返回首位节点的值
        if (index <= 0)
        {
            val = node.Value;
            //node = node.next;
            return val;
        }
        else
        {
            ListNode<T> cur = node;
            int cnt = 0;
            //遍历链表，cur 移动到第 index - 1 个节点（即待查找节点的前一位）
            while (cur != null && cnt < index - 1)
            {
                cnt++;
                cur = cur.next;
            }
            if (cur.next != null)
            {
                //临时节点就是要查找的节点
                ListNode<T> temp = cur.next;
                val = temp.Value;
                return val;
            }
            else
            {
                throw new ArgumentException("index超出范围!!!!!");
            }
        }
    }
    /// <summary>
    /// 根据传入对象查找所在链表的下标位置
    /// </summary>
    /// <param name="item"></param>传入对象
    /// <returns></returns>如果返回-1，表示未找到。
    public int GetNodeIndex(T item)
    {
        ListNode<T> cur = node;

        int index = 0;
        while (cur != null)
        {
            if (cur.Value.Equals(item))
            {
                return index;
            }
            else
            {
                cur = cur.next;
                index++;
            }
        }
        return -1;
    }
    /// <summary>
    /// 返回链表
    /// </summary>
    /// <returns></returns>
    public ListNode<T> GetListNode()
    {
        return node;
    }
}
