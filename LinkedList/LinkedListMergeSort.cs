
namespace LinkedList;

public class LinkedListMergeSort<T> where T : IComparable
{
    // private ListNode<T> node;
    // public LinkedListMergeSort()
    // {
    //     node = null;
    // }
    /*
    链表归并排序:递归式
    */
    /// <summary>
    /// 链表归并排序
    /// </summary>
    /// <param name="listNode"></param>
    /// <returns></returns>
    public ListNode<T> MergeSort(ListNode<T> node)
    {
        if (node == null || node.next == null)
        {
            return node;
        }
        //查找中间点，分割成左边右边两个子链表
        ListNode<T> left = GetMiddle(node);
        //中间点后面就是右边节点
        ListNode<T> right = left.next;
        //清空右边，剩下的就是左边节点
        left.next = null;
        //递归直到只有一个节点
        ListNode<T> left_node = MergeSort(node);
        ListNode<T> right_node = MergeSort(right);
        //归并
        return MergeLinkedList(left_node, right_node);
    }
    /// <summary>
    /// 查找中间节点
    /// </summary>
    /// <param name="listNode"></param>
    /// <returns></returns>
    public static ListNode<T> GetMiddle(ListNode<T> node)
    {
        if (node == null)
        {
            return node;
        }
        //初始快慢指针
        ListNode<T> slow = node;
        ListNode<T> fast = node;
        //分别+1和+2，直到快指针到节点末。
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        //慢指针就是中间节点
        return slow;
    }
    /// <summary>
    /// 合并
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static ListNode<T> MergeLinkedList(ListNode<T> left, ListNode<T> right)
    {
        //初始化实体泛型对象
        T val = default(T);
        //新建链表用于合并后排序
        ListNode<T> merge_node = new ListNode<T>(val);
        ListNode<T> temp = merge_node;
        while (left != null && right != null)
        {
            //比较两个链表的值，那边小就加入合并链表的下一指向
            //if (left.val <= right.val)
            if (Comparer<T>.Default.Compare(left.val, right.val) <= 0)
            {
                temp.next = left;
                left = left.next;
            }
            else
            {
                temp.next = right;
                right = right.next;
            }
            temp = temp.next;
        }
        //剩下的加到合并链表的最后
        temp.next = (left != null) ? left : right;
        return merge_node.next;
    }

}
