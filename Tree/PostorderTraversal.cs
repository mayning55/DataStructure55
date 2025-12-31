using System;

namespace Tree;
/// <summary>
/// 后序遍历二叉树
/// </summary>
public class PostorderTraversal
{
    List<int> result = new List<int>();
    /// <summary>
    /// 遍历，递归左子树,再递归右子树。最后处理当前节点。
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> Postorder(TreeNode root)
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
        DFS(node.right);
        result.Add(node.val);
    }

    public List<int> StackPostorder(TreeNode node)
    {
        List<int> result = new List<int>();
        if (node == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        //记录上一个访问的节点，用于判断右子树是否已访问
        TreeNode prenode = new TreeNode();
        //只要当前节点不为空或栈不为空就继续遍历
        while (node != null || stack.Count > 0)
        {
            //左子树节点先全部入栈
            while (node != null)
            {
                //入栈
                stack.Push(node);
                //继续遍历左子树
                node = node.left;
            }
            //弹出栈顶节点，准备访问或遍历其右子树
            TreeNode temp = stack.Pop();
            //如果右子树为空或者右子树已经访问过
            if (temp.right == null || temp.right == prenode)
            {
                //添加当前节点。
                result.Add(temp.val);
                //更新上一次访问的节点
                prenode = temp;
                //重置，避免重复入栈。
                node = null;
            }
            //否则，右子树还未访问，当前节点重新入栈，转而遍历右子树
            else
            {
                stack.Push(temp);
                node = temp.right;
            }
        }
        return result;
    }
}
