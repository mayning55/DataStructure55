namespace Tree;

public class SearchVal
{
    /// <summary>
    /// 二叉搜索树中查找值
    /// </summary>
    /// <param name="node"></param>二叉搜索树的根节点
    /// <param name="val"></param>查找的目标值
    /// <returns></returns>
    public TreeNode SearchBST(TreeNode node, int val)
    {
        if (node == null)
        {
            return null;
        }
        //返回找到的目标值
        if (val == node.val)
        {
            return node;
        }
        //如果小于当前节点值，递归左子树查找。
        else if (val < node.val)
        {
            return SearchBST(node.left, val);
        }
        //如果大于当前节点值，递归右子树查找。
        else // if (val > node.val)
        {
            return SearchBST(node.right, val);
        }
    }
    /// <summary>
    /// 二叉搜索树插入值
    /// </summary>
    /// <param name="node"></param>二叉搜索树的根节点
    /// <param name="val"></param>待插入的节点值
    /// <returns></returns>

    public TreeNode InserBST(TreeNode node, int val)
    {
        //如果树为空，直接将待插入的节点值作为根节点返回
        if (node == null)
        {
            return new TreeNode(val);
        }
        //如果小于当前值，递归插入到左子树
        if (val < node.val)
        {
            node.left = InserBST(node.left, val);
        }
        //如果大于当前值，递归插入到右子树
        else if (val > node.val)
        {
            node.right = InserBST(node.right, val);
        }
        //如果 val == root.val，不插入（不允许重复），直接返回原树。
        return node;
    }
    /// <summary>
    /// 二叉搜索树的创建
    /// </summary>
    /// <param name="nums"></param>待创建的数组元素
    /// <returns></returns>

    public TreeNode BuildBST(int[] nums)
    {
        TreeNode node = new TreeNode();
        node = null;
        //遍历数组元素，将其插入到新建的二叉搜索树。
        foreach (var item in nums)
        {
            node = InserBST(node, item);
        }
        return node;
    }
    /// <summary>
    /// 二叉搜索树删除节点
    /// </summary>
    /// <param name="node"></param>二叉搜索树的根节点
    /// <param name="val"></param>待删除的节点值
    /// <returns></returns>

    public TreeNode DelNodeBST(TreeNode node, int val)
    {
        //如果未找到值时，返回。
        if (node == null)
        {
            return null;
        }
        //小于当前节点，递归去左子树删除
        if (val < node.val)
        {
            node.left = DelNodeBST(node.left, val);
            return node;
        }
        //大于当前节点，递归去右子树删除
        else if (val > node.val)
        {
            node.right = DelNodeBST(node.right, val);
            return node;
        }
        //当找到目标值时：
        else
        {
            //如果左子树为空，则返回右子树。
            if (node.left == null)
            {
                return node.right;
            }
            //如果右子树为空，则返回左子树。
            else if (node.right == null)
            {
                return node.left;
            }
            //左右子树均不为空时，
            else
            {
                //找到在树最左节点。替换当前值。
                TreeNode temp = node.right;
                while (temp.left != null)
                {
                    temp = temp.left;
                }
                node.val = temp.val;
                //再在右子树中递归，删除目标值。
                node.right = DelNodeBST(node.right, temp.val);
                return node;
            }
        }
    }
}
