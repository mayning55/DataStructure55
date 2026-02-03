
namespace Tree;
/// <summary>
/// 还原二叉树
/// </summary>
public class BuildTree
{
    /// <summary>
    /// 根据前序遍历和中序遍历还原二叉树
    /// </summary>
    /// <param name="preorder">前序遍历</param>
    /// <param name="inorder">中序遍历</param>
    /// <returns></returns>
    public TreeNode WithPreIno(List<int> preorder, List<int> inorder)
    {
        return DFSWithPreIno(preorder, inorder, inorder.Count);
    }
    public TreeNode DFSWithPreIno(List<int> preorder, List<int> inorder, int m)
    {
        //当子树节点数为0时，退出递归。
        if (m == 0)
        {
            return null;
        }
        //[5, 3,2,7 ,8,1,4] preorder
        //[2,3,7, 5 ,1,8,4] inorder
        //preorder[0]首先前序首位为根节点，然后在中序中找出根节点。
        int inroot = 0;
        while (preorder[0] != inorder[inroot])
        {
            inroot++;
        }
        //建立根节点，
        TreeNode node = new TreeNode(inorder[inroot]);
        int pcnt = preorder.Count;
        int icnt = inorder.Count;
        //递归创建左子树和右子树；
        node.left = DFSWithPreIno(preorder.Skip(1).Take(inroot).ToList(), inorder.Take(inroot).ToList(), inroot);//pre:3,2,7 in:2,3,7
        node.right = DFSWithPreIno(preorder.Skip(inroot + 1).Take(pcnt - inroot - 1).ToList(), inorder.Skip(inroot + 1).Take(icnt - inroot - 1).ToList(), m - inroot - 1);//pre:8,1,4 in:1,8,4
        return node;
    }
    /// <summary>
    /// 根据中序遍历和后序遍历还原二叉树
    /// </summary>
    /// <param name="inorder">中序遍历</param>
    /// <param name="postorder">后序遍历</param>
    /// <returns></returns>
    public TreeNode WithInPost(List<int> inorder, List<int> postorder)
    {
        return DFSWithInPost(inorder, postorder, postorder.Count);
    }
    public TreeNode DFSWithInPost(List<int> inorder, List<int> postorder, int m)
    {
        //当子树节点数为0时，退出递归。
        if (m == 0)
        {
            return null;
        }
        int icnt = inorder.Count;
        int pcnt = postorder.Count;
        ////建立根节点，
        TreeNode node = new TreeNode(postorder[pcnt - 1]);
        //[2,3,7 ,5, 1,8,4] inorder
        //[2,7,3, 1,4,8, 5] postorder
        //postorder[pcnt-1] 首先前序首位为根节点，然后在中序中找出根节点。
        int postroot = 0;
        while (inorder[postroot] != postorder[pcnt - 1])
        {
            postroot++;
        }
        ////递归创建左子树和右子树；
        node.left = DFSWithInPost(inorder.Take(postroot).ToList(), postorder.Take(postroot).ToList(), postroot);//in:2,3,4 post:2,7,3
        node.right = DFSWithInPost(inorder.Skip(postroot + 1).Take(icnt - postroot - 1).ToList(), postorder.Skip(postroot).Take(pcnt - postroot - 1).ToList(), m - postroot - 1);//in:1,8,4 post:1,4,8
        return node;
    }
    /// <summary>
    /// 根据中序遍历和层序遍历还原二叉树
    /// </summary>
    /// <param name="inorder">中序遍历</param>
    /// <param name="level">层序遍历</param>
    /// <returns></returns>

    public TreeNode WithInLevel(List<int> inorder, List<int> level)
    {
        return DFSWithInLevel(inorder, level);

    }
    public TreeNode DFSWithInLevel(List<int> inorder, List<int> level)
    {
        if (inorder == null || inorder.Count == 0)
        {
            return null;
        }
        //[2,3,7 ,5, 1,8,4] inorder
        //[5, 3, 8, 2,7, 1,4] level
        //层序的首位是根节点
        TreeNode node = new TreeNode(level[0]);
        //在中序中找出根节点的位置。
        int inRoot = 0;
        while (inorder[inRoot] != level[0])
        {
            inRoot++;
        }
        //将中序按根节点分割左右
        List<int> leftInorder = inorder.GetRange(0, inRoot);
        List<int> rightInorder = inorder.GetRange(inRoot + 1, inorder.Count - inRoot - 1);
        //将层序按中序分割
        List<int> leftLevel = new List<int>();
        List<int> rightLevel = new List<int>();
        HashSet<int> leftset = new HashSet<int>(leftInorder);
        HashSet<int> rightset = new HashSet<int>(rightInorder);
        for (int i = 1; i < level.Count; i++)
        {
            if (leftset.Contains(level[i]))
            {
                leftLevel.Add(level[i]);
            }
            else if (rightset.Contains(level[i]))
            {
                rightLevel.Add(level[i]);
            }
        }
        //递归创建左子树和右子树
        node.left = DFSWithInLevel(leftInorder, leftLevel);
        node.right = DFSWithInLevel(rightInorder, rightLevel);
        return node;
    }
    /// <summary>
    /// 根据前序和后序还原二叉树
    /// </summary>
    /// <param name="preorder">前序</param>
    /// <param name="postorder">后序</param>
    /// <returns></returns>
    public TreeNode WithPrePost(List<int> preorder, List<int> postorder)
    {
        return DFSWithPrePost(preorder, postorder, postorder.Count);

    }
    public TreeNode DFSWithPrePost(List<int> preorder, List<int> postorder, int m)
    {
        if (m == 0)
        {
            return null;
        }
        TreeNode node = new TreeNode(preorder[0]);
        //只有一个节点时，
        if (m == 1)
        {
            return node;
        }
        //前序遍历的第二个元素为左子树的根节点，
        int leftNodeVal = preorder[1];
        //在后序遍历中找出左子树的根节点位置
        int postRoot = 0;
        while (postorder[postRoot] != leftNodeVal)
        {
            postRoot++;
        }
        // 左子树的大小
        int leftSize = postRoot + 1;
        // 右子树的大小
        int rightSize = m - leftSize - 1;
        ////递归创建左子树和右子树
        node.left = DFSWithPrePost(preorder.GetRange(1, leftSize), postorder.GetRange(0, leftSize), leftSize);
        node.right = DFSWithPrePost(preorder.GetRange(1 + leftSize, rightSize), postorder.GetRange(leftSize, rightSize), rightSize);
        return node;
    }
}
