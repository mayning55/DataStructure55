using System.Security.Cryptography.X509Certificates;

namespace Tree;

class Program
{
    static void Main(string[] args)
    {
        TreeNode treeNode = new TreeNode();
        treeNode.val = 5;
        treeNode.left = new TreeNode(3);
        treeNode.right = new TreeNode(8);
        treeNode.left.left = new TreeNode(2);
        treeNode.left.right = new TreeNode(7);
        treeNode.right.left = new TreeNode(1);
        treeNode.right.right = new TreeNode(4);
        // /*
        // 前序遍历二叉树
        // [5,3,2,7,8,1,4]
        // */
        // PreorderTraversal pt = new PreorderTraversal();
        // var listpt = pt.Preorder(treeNode);
        // var liststp = pt.StackPreorder(treeNode);
        // Console.WriteLine(string.Join(",", listpt));
        // Console.WriteLine(string.Join(",", liststp));

        // /*
        // 中序遍历二叉树
        // [2,3,7,5,1,8,4]
        // */
        // InorderTraversal it = new InorderTraversal();
        // var listit = it.Inorder(treeNode);
        // var listsit = it.StackInorder(treeNode);
        // System.Console.WriteLine(string.Join(",", listit));
        // System.Console.WriteLine(string.Join(",", listsit));
        // /*
        // 后序遍历二叉树
        // [2,7,3,1,4,8,5]
        // */
        // PostorderTraversal ptr = new PostorderTraversal();
        // var listptr = ptr.Postorder(treeNode);
        // var listsptr = ptr.StackPostorder(treeNode);
        // System.Console.WriteLine(string.Join(",", listptr));
        // System.Console.WriteLine(string.Join(",", listsptr));
        // /*
        // 层序遍历二叉树
        // [5,3,8,2,7,1,4]
        // */
        LevelorderTraversal lt = new LevelorderTraversal();
        // var listlt = lt.LevelOrder(treeNode);
        // System.Console.WriteLine(string.Join(",", listlt));

        // /*
        // 还原二叉树
        // */
        // List<int> preorder = new List<int> { 5, 3, 2, 7, 8, 1, 4 };
        // List<int> inorder = new List<int> { 2, 3, 7, 5, 1, 8, 4 };
        // List<int> postorder = new List<int> { 2, 7, 3, 1, 4, 8, 5 };
        // List<int> level = new List<int> { 5, 3, 8, 2, 7, 1, 4 };
        // BuildTree bt = new BuildTree();
        // //根据前序和中序还原二叉树
        // var piresult = bt.WithPreIno(preorder, inorder);
        // var pilist = lt.LevelOrder(piresult);
        // System.Console.WriteLine(string.Join(" ", pilist));
        // //根据中序和后序还原二叉树
        // var ipresult = bt.WithInPost(inorder, postorder);
        // var iplist = lt.LevelOrder(ipresult);
        // System.Console.WriteLine(string.Join(" ", iplist));
        // //根据中序和后序还原二叉树
        // var ilresult = bt.WithInLevel(inorder, level);
        // var illist = lt.LevelOrder(ilresult);
        // System.Console.WriteLine(string.Join(" | ", illist));
        // //根据前序和后序还原二叉树
        // var ppresutl = bt.WithPrePost(preorder, postorder);
        // var pplist = lt.LevelOrder(ppresutl);
        // System.Console.WriteLine(string.Join(" ! ", pplist));
        ///*
        //二叉搜索树
        //*/
        // SearchVal sv = new SearchVal();
        // //创建
        // var bunode = sv.BuildBST([5, 3, 8, 2, 7, 1, 4]);
        // var butList = lt.LevelOrder(bunode);
        // System.Console.WriteLine(string.Join(",", butList));

        // //查找
        // var snode = sv.SearchBST(treeNode, 8);
        // System.Console.WriteLine(snode.val);
        // //插入
        // var insertNode = sv.InserBST(bunode, 9);
        // var insertList = lt.LevelOrder(insertNode);
        // System.Console.WriteLine(string.Join(",", insertList));
        // //删除
        // var delNode = sv.DelNodeBST(insertNode, 2);
        // var delList = lt.LevelOrder(delNode);
        // System.Console.WriteLine(string.Join(",", delList));
        /*
        线段树
        */
        // int[] ints = { 1, 3, 5, 7, 9, 11 };
        // //函数：加法,0
        // //最大值：Math.Max ,int.MinValue
        // //最小值：Math.Min, int.MaxValue

        // SegmentTree st = new SegmentTree(ints, (a, b) => a + b, 0);
        // //区间求和
        // //1, 3, 5, 7, 9, 11
        // System.Console.WriteLine(st.Query(0, 3));//1, 3, 5, 7=16
        // System.Console.WriteLine(st.Query(1, 3));//3, 5, 7=15
        // System.Console.WriteLine(st.Query(1, 5));//3, 5, 7, 9, 11=35
        // System.Console.WriteLine(st.Query(2, 5));//32
        // //单点更新
        // // st.Update(1, 10);
        // // //1, 10, 5, 7, 9, 11
        // // System.Console.WriteLine("````````");
        // // System.Console.WriteLine(st.Query(1, 1));//10
        // // System.Console.WriteLine(st.Query(1, 3));//10, 5, 7=22
        // // System.Console.WriteLine(st.Query(1, 5));//10, 5, 7, 9, 11=42
        // // System.Console.WriteLine(st.Query(2, 2));//5
        // //区域更新
        // st.UpdateRange(1, 3, 10);
        // //1, 10, 10, 10, 9, 11
        // System.Console.WriteLine(string.Join(",", ints));
        // System.Console.WriteLine(st.Query(0, 0));//1
        // System.Console.WriteLine(st.Query(1, 1));//10
        // System.Console.WriteLine(st.Query(2, 2));//10
        // System.Console.WriteLine(st.Query(3, 3));//10
        // System.Console.WriteLine(st.Query(4, 4));//9
        // System.Console.WriteLine(st.Query(5, 5));//11
        // System.Console.WriteLine(st.Query(0, 3));//1,10, 10, 10=31
        // System.Console.WriteLine(st.Query(0, 5));//51
        // System.Console.WriteLine(st.Query(1, 4));//10, 10, 10, 9=39
        /*
        树状数组
        */
        int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        BinaryIndexedTree bi = new BinaryIndexedTree(ints.Length);
        for (int i = 0; i < ints.Length; i++)
        {
            bi.Update(i + 1, ints[i]);//下标从1开始
        }
        //前辍和
        System.Console.WriteLine(bi.Query(2));//1+2
        System.Console.WriteLine(bi.QueryRange(2, 5));//2+3+4+5
        System.Console.WriteLine(bi.Query(10));//55
        bi.Update(9, -9);
        System.Console.WriteLine(bi.QueryRange(9, 9));
        System.Console.WriteLine(bi.QueryRange(1, 10));//46
        bi.UpdateRange(1, 3, 1);
        System.Console.WriteLine(bi.QueryRange(1,1));//1+1
        System.Console.WriteLine(bi.QueryRange(2,2));//2+1
        System.Console.WriteLine(bi.QueryRange(3,3));//3+1
        System.Console.WriteLine(bi.QueryRange(1,3));//4








    }
}
