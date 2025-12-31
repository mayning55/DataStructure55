using System;

namespace Tree;
/// <summary>
/// 中序遍历二叉树
/// </summary>
public class InorderTraversal
{
    List<int> result = new List<int>();
    /// <summary>
    /// 遍历，先递归左子树，再访问当前节点，然后递归右子树
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> Inorder(TreeNode root)
    {
        result = new List<int>();
        DFS(root);
        return result;
    }
    /// <summary>
    /// 递归过程
    /// </summary>
    /// <param name="node"></param>
    public void DFS(TreeNode node)
    {
        //节点为空，返回（递归终止的条件）
        if (node == null)
        {
            return;
        }
        DFS(node.left);
        result.Add(node.val);
        DFS(node.right);
    }
    /// <summary>
    /// 非递归实现
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public List<int> StackInorder(TreeNode node)
    {
        List<int> result = new List<int>();
        if (node == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = node;//当前遍历的节点
        //只要当前节点不为空或栈不为空就继续
        while (cur != null || stack.Count > 0)
        {
            //左子树节点全部入栈
            while (cur != null)
            {
                //入栈
                stack.Push(cur);
                //继续遍历左子树
                cur = cur.left;
            }
            TreeNode temp = stack.Pop();
            //将弹出的最左节点的根加入结果
            result.Add(temp.val);
            //转右子树继续。
            cur = temp.right;
        }
        return result;
    }
}
