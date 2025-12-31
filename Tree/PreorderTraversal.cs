namespace Tree;

/// <summary>
/// 前序遍历二叉树
/// </summary>
public class PreorderTraversal
{
    List<int> result = new List<int>();
    /// <summary>
    /// 遍历，从根节点开始，递归左子树，和递归右子树
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> Preorder(TreeNode root)
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
        result.Add(node.val);
        DFS(node.left);
        DFS(node.right);
    }
    /// <summary>
    /// 非递归实现
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public List<int> StackPreorder(TreeNode node)
    {
        List<int> result = new List<int>();
        if (node == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        //将根节点加入初始化后的栈
        stack.Push(node);
        //当栈不为空时，
        while (stack.Count > 0)
        {

            TreeNode curr = stack.Pop();
            //出栈，加入结果列表。
            result.Add(curr.val);
            //先右后左遍历。如果子树节点存在，入栈
            if (curr.right != null)
            {
                stack.Push(curr.right);
            }
            if (curr.left != null)
            {
                stack.Push(curr.left);
            }
        }
        return result;
    }
}