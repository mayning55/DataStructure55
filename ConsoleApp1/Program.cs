
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] ints = new int[] { 1, 2, 3 };
        string[] ss = new string[] { "a", "b", "c" };

        ListNodeImplementer<string> lniss = new ListNodeImplementer<string>();
        foreach (var item in ss)
        {
            lniss.CreateListNode(item);
        }
        lniss.InsertNode("d", 0);
        lniss.InsertNode("e", 6);
        lniss.DeleteNode("b");
        lniss.UpdateNode("a", 0);
        var index = lniss.GetNodeIndex("e");
        System.Console.WriteLine(index);

        int length = lniss.GetListNodeLength();
        System.Console.WriteLine(length);
        var curNode = lniss.GetListNode();
        while (curNode != null)
        {
            System.Console.WriteLine(curNode.Value);
            curNode = curNode.next;
        }

        // ListNodeImplementer<int> lniint = new ListNodeImplementer<int>();

        // foreach (var item in ints)
        // {
        //     lniint.CreateListNode(item);
        // }
        // lniint.InsertNode(4, 0);        //4,1,2,3
        // lniint.InsertNode(4, 0);        //4,4,1,2,3
        // lniint.InsertNode(5, 5);        //4,4,1,2,3,5
        // lniint.InsertNode(6, 3);        //4,4,1,6,2,3,5
        // lniint.InsertNode(4, 6);        //4,4,1,6,2,3,4,5
        // lniint.InsertNode(4, 8);        //4,4,1,6,2,3,4,5,4
        // lniint.DeleteNode(4);           //1,6,2,3,5
        // lniint.UpdateNode(9, 4);         //1,6,2,3,9
        // var index = lniint.GetNodeIndex(8);
        // System.Console.WriteLine(index);
        // try
        // {
        //     int i = 3;
        //     var x = lniint.GetNodeValueByIndex(i);
        //     System.Console.WriteLine("下标位置{0}的值是:{1}", i, x);
        // }
        // catch (ArgumentException e)
        // {
        //     System.Console.WriteLine(e.Message);
        // }
        // // try
        // // {
        // //     var x = lniint.DeleteNodeByIndex(-1);       //4,2,6,3,5
        // //     System.Console.WriteLine("删除的节点值是：{0}", x);
        // // }
        // // catch (ArgumentException e)
        // // {
        // //     System.Console.WriteLine(e.Message);
        // // }
        // int l = lniint.GetListNodeLength();
        // Console.WriteLine(l);

    }
}