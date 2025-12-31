namespace LinkedList;

public class LinkedListBubbleSort<T> where T : IComparable
{
    /*
    链表冒泡排序
    */
    /// <summary>
    /// 链表冒泡排序
    /// </summary>
    /// <param name="listNode"></param>
    public void BubbleSort(ListNode<T> node)
    {
        if (node == null || node.next == null)
        {
            return;
        }
        ListNode<T> cur = node;
        //用来存放已经排序的节点
        ListNode<T> right = null;
        //遍历链表
        while (cur.next != null)
        {
            //临时链表用于俩俩节点比较大小
            ListNode<T> temp = node;
            //遍历，根据大小判断是否交换位置，直到链表结束且下一节点是已经排序过的。
            while (temp != null && temp.next != right)
            {
                if (temp.next == null)
                {
                    break;
                }
                if (Comparer<T>.Default.Compare(temp.Value, temp.next.Value) > 0)
                {
                    (temp.val, temp.next.val) = (temp.next.val, temp.val);
                }
                temp = temp.next;
            }
            //已经排序好的。
            right = temp;
            cur = cur.next;
        }
    }
    /// <summary>
    /// 冒泡排序（倒序递减）
    /// </summary>
    /// <param name="listNode"></param>
    public void BubbleSortDesc(ListNode<T> node)
    {

        if (node == null || node.next == null)
        {
            return;
        }
        ListNode<T> cur = node;
        //用来存放已经排序的节点
        ListNode<T> right = null;
        //遍历链表
        while (cur.next != null)
        {
            //临时链表用于俩俩节点比较大小
            ListNode<T> temp = node;
            //遍历，根据大小判断是否交换位置，直到链表结束且下一节点是已经排序过的。
            while (temp != null && temp.next != right)
            {
                if (temp.next == null)
                {
                    break;
                }
                if (Comparer<T>.Default.Compare(temp.Value, temp.next.Value) < 0)
                //if (temp.val < temp.next.val)
                {
                    (temp.val, temp.next.val) = (temp.next.val, temp.val);
                }
                temp = temp.next;
            }
            //已经排序好的。
            right = temp;
            cur = cur.next;
        }
    }

}