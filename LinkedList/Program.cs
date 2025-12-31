namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        string[] strings = new string[] { "b", "dc", "h", "d" };
        //int[] ints = new int[] { 4, 2, 5, 3, 1, 6, 3, 6, 2 };
        //创建链表
        //var lnt = new ListNodeImplementer<int>();
        var lns = new ListNodeImplementer<string>();
        foreach (var item in strings)
        {
            //lnt.CreateListNode(item);
            lns.CreateListNode(item);
        }
        //var curNode = lnt.GetListNode();
        var curNode = lns.GetListNode();




        /*
        链表冒泡排序，
        通过相邻节点比较和交换，将最大值逐步「冒泡」到链表末尾。
        */
        //LinkedListBubbleSort<int> llbs = new LinkedListBubbleSort<int>();
        LinkedListBubbleSort<string> llbs = new LinkedListBubbleSort<string>();
        // // //倒序
        //llbs.BubbleSortDesc(curNode);
        // // //正序
        //llbs.BubbleSort(curNode);
        // List<int> ints1 = new List<int>();
        // while (curNode != null)
        // {
        //     ints1.Add(curNode.Value);
        //     curNode = curNode.next;
        // }
        //System.Console.WriteLine(string.Join(" ", ints1));

        /*
        归并排序
        采用分治策略，将链表递归分割为更小的子链表，然后两两归并得到有序链表。
        */
        //LinkedListMergeSort<int> llms = new LinkedListMergeSort<int>();
        LinkedListMergeSort<string> llms = new LinkedListMergeSort<string>();
        curNode = llms.MergeSort(curNode);
        //llbs.BubbleSortDesc(curNode);

        // //返回结果
        // List<int> ints1 = new List<int>();
        // while (curNode != null)
        // {
        //     ints1.Add(curNode.Value);
        //     curNode = curNode.next;
        // }
        // System.Console.WriteLine(string.Join(" ", ints1));
        List<string> ints1 = new List<string>();
        while (curNode != null)
        {
            ints1.Add(curNode.Value);
            curNode = curNode.next;
        }
        System.Console.WriteLine(string.Join(" ", ints1));

    }
}
