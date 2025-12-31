using System;

namespace LinkedList;

public class LinkedListTwoPointers
{
    /// <summary>
    /// 快慢指针（起点不一样）
    /// </summary>
    /// <param name="node"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public ListNode<int> FindNthFromEnd(ListNode<int> node, int n)
    {
        ListNode<int> slow = node;
        ListNode<int> fast = node;
        while (n > 0)
        {
            fast = fast.next;
            n--;
        }
        while (fast != null)
        {
            fast = fast.next;
            slow = slow.next;
        }
        return slow;

    }
    /// <summary>
    /// 快慢指针（步长不一样）
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>

    public ListNode<int> FastSlowPointer(ListNode<int> node)
    {
        ListNode<int> slow = node;
        ListNode<int> fast = node;
        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        return slow;
    }
    /// <summary>
    /// 分离双指针（合并链表）
    /// </summary>
    /// <param name="list1"></param>
    /// <param name="list2"></param>
    /// <returns></returns>
    public ListNode<int> MergeTwoLists(ListNode<int> list1, ListNode<int> list2)
    {
        ListNode<int> cur = new ListNode<int>(-1);
        ListNode<int> temp = cur;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                temp.next = list1;
                list1 = list1.next;
            }
            else
            {
                temp.next = list2;
                list2 = list2.next;
            }
            temp = temp.next;
        }
        temp.next = (list1 != null) ? list1 : list2;
        return cur.next;
    }


}
