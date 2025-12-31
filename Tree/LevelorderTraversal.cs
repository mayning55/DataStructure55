using System;

namespace Tree;
/// <summary>
/// 层序遍历二叉树
/// </summary>
public class LevelorderTraversal
{
    /// <summary>
    /// 层序遍历，（广度优先搜索，BFS）
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public List<int> LevelOrder(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root == null)
        {
            return result;
        }
        Queue<TreeNode> queue = new Queue<TreeNode>();
        //将根节点加入初始化后的队列。
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            //用来保存当前层的节点值
            List<int> curlevel = new List<int>();
            //遍历当前层节点。
            for (int i = 0; i < queue.Count; i++)
            {
                //将队列的首节点加入当前层
                TreeNode curnode = queue.Dequeue();
                curlevel.Add(curnode.val);
                //如果左节点存在，将其加入队列。
                if (curnode.left != null)
                {
                    queue.Enqueue(curnode.left);
                }
                //如果右节点存在，将其加入队列。
                if (curnode.right != null)
                {
                    queue.Enqueue(curnode.right);
                }
            }
            //将当前层节点值加入结果中。
            if (curlevel != null)
            {
                result.AddRange(curlevel);
                //curlevel = new List<int>();
            }
        }
        return result;
    }

}
