
namespace Tree;
/// <summary>
/// 线段树
/// </summary>
public class SegmentTree
{
    private int[] tree;//线段树的数组
    private int[] data;//原始数组
    private int m;//数组的大小
    private int[] lazy;//懒惰标记数组
    private int lazy_tag;//标记，(e.g., 0 for sum, int.MinValue for max)
    private Func<int, int, int> merge;


    //初始化
    public SegmentTree(int[] arra, Func<int, int, int> merge, int lazy_tag)
    {
        this.data = new int[arra.Length];
        this.data = arra;
        this.m = data.Length;
        this.lazy_tag = lazy_tag;
        this.tree = new int[m * 4];
        this.merge = merge;
        this.lazy = new int[m * 4];
        // 初始化懒惰标记数组
        for (int i = 0; i < m; i++)
        {
            lazy[i] = lazy_tag;
        }
        BuildSegmentTree(1, 0, m - 1);
    }
    /// <summary>
    /// 创建线段对
    /// </summary>
    /// <param name="node"></param>当前节点在 _tree 数组中的索引
    /// <param name="start"></param>当前节点管理的区间左端点
    /// <param name="end"></param>当前节点管理的区间右端点
    public void BuildSegmentTree(int node, int start, int end)
    {
        //叶子节点，直接赋值为原数组对应元素
        if (start == end)
        {
            tree[node] = data[start];
            return;
        }
        //中间点
        int mid = start + (end - start) / 2;
        //左子节点下标
        int leftNode = node * 2;
        //右子节点下标
        int rightNode = node * 2 + 1;
        // 递归构建左子树
        BuildSegmentTree(leftNode, start, mid);
        // 递归构建右子树
        BuildSegmentTree(rightNode, mid + 1, end);
        //当前节点的值是两个子节点的值的和
        tree[node] = merge(tree[leftNode], tree[rightNode]);
    }
    /// <summary>
    /// 将懒惰标记从父节点下推到子节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    private void Push(int node, int start, int end)
    {
        if (lazy[node].Equals(lazy_tag))
        {
            return;
        }
        // 应用懒惰标记到当前节点
        // 注意：这里的逻辑是 "区间赋值"，所以直接覆盖
        // 如果是 "区间增加"，逻辑应该是 _tree[node] += _lazy[node] * (end - start + 1)
        tree[node] = lazy[node];
        //// 如果不是叶节点，将标记传递给子节点
        if (start != end)
        {
            lazy[2 * node] = lazy[node];
            lazy[2 * node + 1] = lazy[node];
        }

        // 清除当前节点的懒惰标记
        lazy[node] = lazy_tag;
    }
    /// <summary>
    /// 区间查询
    /// </summary>
    /// <param name="left"></param>左边界
    /// <param name="right"></param>右边界
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public int Query(int left, int right)
    {
        //抛出超出边界异常
        if (left < 0 || right >= m || left > right)
        {
            throw new ArgumentException("Invalid query range.");
        }
        //递时查询区间left和right的和。
        return QueryRange(1, 0, m - 1, left, right);
    }
    /// <summary>
    /// 递归查找区间
    /// </summary>
    /// <param name="node"></param>当前节点索引
    /// <param name="start"></param>当前节点区间左边界
    /// <param name="end"></param>当前节点区间右边界
    /// <param name="left"></param>查询区间左边界
    /// <param name="right"></param>查询区间右边界
    /// <returns></returns>
    public int QueryRange(int node, int start, int end, int left, int right)
    {
        //先处理懒惰标记
        Push(node, start, end);
        //当前节点代表的区间与查询区间无重叠
        if (right < start || end < left)
        {
            return lazy_tag;
        }
        //当前节点代表的区间完全在查询区间内
        if (left <= start && end <= right)
        {
            return tree[node];
        }
        //当前节点代表的区间与查询区间部分重叠,分别递归查找左右子树
        else
        {
            int mid = start + (end - start) / 2;
            int leftNode = 2 * node;
            int rightNode = 2 * node + 1;
            int leftSum = QueryRange(leftNode, start, mid, left, right);
            int rightSum = QueryRange(rightNode, mid + 1, end, left, right);
            return merge(leftSum, rightSum);
        }
    }
    /// <summary>
    /// 单点更新节点
    /// </summary>
    /// <param name="index"></param>待更新的数组下标
    /// <param name="val"></param>待更新的值。
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void Update(int index, int val)
    {
        if (index < 0 || index >= m)
        {
            throw new IndexOutOfRangeException();
        }
        //更新原始数组下标值。
        data[index] = val;
        UpdateSingle(1, 0, m - 1, index, val);
    }
    /// <summary>
    /// 递归更新
    /// </summary>
    /// <param name="node"></param>当前节点索引
    /// <param name="start"></param>当前节点区间左边界
    /// <param name="end"></param>当前节点区间右边界
    /// <param name="index"></param>待更新的元素索引
    /// <param name="val"></param>待更新的值
    public void UpdateSingle(int node, int start, int end, int index, int val)
    {
        //找到要更新的叶节点
        if (start == end)
        {
            tree[node] = val;
            return;
        }
        int mid = start + (end - start) / 2;
        int leftNode = 2 * node;
        int rightNode = 2 * node + 1;
        //递归更新左子树或者右子树
        if (index <= mid)
        {
            UpdateSingle(leftNode, start, mid, index, val);
        }
        else
        {
            UpdateSingle(rightNode, mid + 1, end, index, val);
        }
        //更新当前节点的区间值
        tree[node] = tree[leftNode] + tree[rightNode];
    }
    /// <summary>
    /// 区间更新节点
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="val"></param>
    /// <exception cref="ArgumentException"></exception>
    public void UpdateRange(int left, int right, int val)
    {
        if (left < 0 || right >= m || left > right)
            throw new ArgumentException("Invalid update range.");
        UpdateRangeAct(1, 0, m - 1, left, right, val);
    }
    /// <summary>
    /// 递归进行区间更新
    /// </summary>
    /// <param name="node"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="val"></param>
    public void UpdateRangeAct(int node, int start, int end, int left, int right, int val)
    {
        //先处理懒惰标记
        Push(node, start, end);
        //当前节点代表的区间与更新区间无重叠
        if (start > right || end < left)
        {
            return;
        }
        //当前节点代表的区间完全在更新区间内
        // 打上懒惰标记，不再向下递归
        if (start >= left && end <= right)
        {
            lazy[node] = val;
            Push(node, start, end);
            return;
        }
        //部分重叠，继续向下递归
        int mid = start + (end - start) / 2;
        int leftNode = 2 * node;
        int rightNode = 2 * node + 1;
        UpdateRangeAct(leftNode, start, mid, left, right, val);
        UpdateRangeAct(rightNode, mid + 1, end, left, right, val);
        tree[node] = merge(tree[leftNode], tree[rightNode]);

    }

}

// using System;

// public class LazySegmentTree
// {
//     private T[] _tree;    // 线段树数组
//     private T[] _lazy;    // 懒惰标记数组
//     private int _size;
//     private Func<T, T, T> _merge;
//     private T _identity; // 用于查询的合并单位元 (e.g., 0 for sum, int.MinValue for max)

//     public LazySegmentTree(T[] data, Func<T, T, T> merge, T identity)
//     {
//         _data = new T[data.Length];
//         Array.Copy(data, _data, data.Length);
//         _size = data.Length;
//         _merge = merge;
//         _identity = identity;
//         _tree = new T[4 * _size];
//         _lazy = new T[4 * _size];
//         // 初始化懒惰标记数组
//         for (int i = 0; i < _lazy.Length; i++)
//         {
//             _lazy[i] = identity; // 假设 identity 也可以作为懒惰标记的“无操作”值
//         }
//         Build(1, 0, _size - 1);
//     }

//     private T[] _data; // 保留原始数据，Build时用

//     // Build 方法保持不变
//     private void Build(int node, int start, int end)
//     {
//         if (start == end)
//         {
//             _tree[node] = _data[start];
//             return;
//         }
//         int mid = start + (end - start) / 2;
//         Build(2 * node, start, mid);
//         Build(2 * node + 1, mid + 1, end);
//         _tree[node] = _merge(_tree[2 * node], _tree[2 * node + 1]);
//     }

//     /// <summary>
//     /// 将懒惰标记从父节点下推到子节点
//     /// </summary>
//     private void Push(int node, int start, int end)
//     {
//         // 如果当前节点没有懒惰标记，则直接返回
//         if (_lazy[node].Equals(_identity)) return;

//         // 应用懒惰标记到当前节点
//         // 注意：这里的逻辑是 "区间赋值"，所以直接覆盖
//         // 如果是 "区间增加"，逻辑应该是 _tree[node] += _lazy[node] * (end - start + 1)
//         _tree[node] = _lazy[node];

//         // 如果不是叶节点，将标记传递给子节点
//         if (start != end)
//         {
//             _lazy[2 * node] = _lazy[node];
//             _lazy[2 * node + 1] = _lazy[node];
//         }

//         // 清除当前节点的懒惰标记
//         _lazy[node] = _identity;
//     }

//     /// <summary>
//     /// 区间更新公共接口
//     /// </summary>
//     public void UpdateRange(int l, int r, T val)
//     {
//         if (l < 0 || r >= _size || l > r)
//             throw new ArgumentException("Invalid update range.");
//         UpdateRange(1, 0, _size - 1, l, r, val);
//     }

//     /// <summary>
//     /// 递归进行区间更新
//     /// </summary>
//     private void UpdateRange(int node, int start, int end, int l, int r, T val)
//     {
//         // 在访问任何节点之前，先处理它的懒惰标记
//         Push(node, start, end);

//         // 情况1：当前节点代表的区间与更新区间无重叠
//         if (start > r || end < l)
//         {
//             return;
//         }

//         // 情况2：当前节点代表的区间完全在更新区间内
//         // 打上懒惰标记，不再向下递归
//         if (start >= l && end <= r)
//         {
//             _lazy[node] = val;
//             // 立即应用标记以更新当前节点的值，方便父节点计算
//             Push(node, start, end);
//             return;
//         }

//         // 情况3：部分重叠，继续向下递归
//         int mid = start + (end - start) / 2;
//         UpdateRange(2 * node, start, mid, l, r, val);
//         UpdateRange(2 * node + 1, mid + 1, end, l, r, val);

//         // 递归返回后，用子节点的值更新当前节点的值
//         _tree[node] = _merge(_tree[2 * node], _tree[2 * node + 1]);
//     }

//     /// <summary>
//     /// 区间查询公共接口
//     /// </summary>
//     public T Query(int l, int r)
//     {
//         if (l < 0 || r >= _size || l > r)
//             throw new ArgumentException("Invalid query range.");
//         return Query(1, 0, _size - 1, l, r);
//     }

//     /// <summary>
//     /// 递归进行区间查询
//     /// </summary>
//     private T Query(int node, int start, int end, int l, int r)
//     {
//         // 在访问任何节点之前，先处理它的懒惰标记
//         Push(node, start, end);

//         // 情况1：无重叠
//         if (start > r || end < l)
//         {
//             return _identity;
//         }

//         // 情况2：完全重叠
//         if (start >= l && end <= r)
//         {
//             return _tree[node];
//         }

//         // 情况3：部分重叠
//         int mid = start + (end - start) / 2;
//         T leftResult = Query(2 * node, start, mid, l, r);
//         T rightResult = Query(2 * node + 1, mid + 1, end, l, r);
//         return _merge(leftResult, rightResult);
//     }
// }

// // 使用示例
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         // --- 求和的懒惰线段树 ---
//         int[] arr = { 1, 2, 3, 4, 5 };
//         var lazySumSegTree = new LazySegmentTree<int>(
//             arr,
//             (a, b) => a + b, // 合并函数：加法
//             0                 // 单位元：0
//         );

//         Console.WriteLine($"Initial Sum [0, 4]: {lazySumSegTree.Query(0, 4)}"); // 1+2+3+4+5 = 15

//         Console.WriteLine("\nUpdating range [1, 3] to 10...");
//         // 将索引 1 到 3 的所有元素都设置为 10
//         // 数组变为 {1, 10, 10, 10, 5}
//         lazySumSegTree.UpdateRange(1, 3, 10);

//         Console.WriteLine($"Sum [0, 4] after update: {lazySumSegTree.Query(0, 4)}"); // 1+10+10+10+5 = 36
//         Console.WriteLine($"Sum [1, 2] after update: {lazySumSegTree.Query(1, 2)}"); // 10+10 = 20

//         Console.WriteLine("\nUpdating range [0, 1] to 5...");
//         // 数组变为 {5, 5, 10, 10, 5}
//         lazySumSegTree.UpdateRange(0, 1, 5);

//         Console.WriteLine($"Sum [0, 4] after second update: {lazySumSegTree.Query(0, 4)}"); // 5+5+10+10+5 = 35
//     }
// }
