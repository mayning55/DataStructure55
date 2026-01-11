using System;

namespace DynamicProgramming;
/// <summary>
/// 矩阵线性DP
/// </summary>
public class MatrixLinearMinPath
{
    private int[][] grid;
    private int rows;
    private int columns;
    private int[][] dp;
    public MatrixLinearMinPath(int[][] grid)
    {
        this.grid = grid;
        this.rows = grid.Length;
        this.columns = grid[0].Length;
        MatrixPathSum();
    }
    public int MinPathSum()
    {
        if (grid == null || grid.Length == 0 || grid[0].Length == 0)
        {
            return 0;
        }
        return dp[rows - 1][columns - 1];
    }

    /// <summary>
    /// 最小路径和
    /// </summary>
    /// <param name="grid"></param>一个包含非负整数的m×n大小的网格
    /// <returns></returns>每次只能向下或者向右移动一步。找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
    private void MatrixPathSum()
    {
        //初始化矩阵
        dp = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            dp[i] = new int[columns];
        }
        //左上角出发
        dp[0][0] = grid[0][0];
        /*
        状态转移：
        当 i>0,j=0 时，只能从上方到达，dp[i][0]=dp[i−1][0]+grid[i][0]。
        当 i=0,j>0 时，只能从左侧到达，dp[0][j]=dp[0][j−1]+grid[0][j]。
        */
        //初始化第一列
        for (int i = 1; i < rows; i++)
        {
            dp[i][0] = dp[i - 1][0] + grid[i][0];
        }
        //初始化第一行
        for (int j = 1; j < columns; j++)
        {
            dp[0][j] = dp[0][j - 1] + grid[0][j];
        }
        //计算剩下的。
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < columns; j++)
            {
                dp[i][j] = Math.Min(dp[i][j - 1], dp[i - 1][j]) + grid[i][j];
            }
        }
    }
    public List<int> GetMinPath()
    {
        //MatrixPathSum();
        List<int> minPath = new List<int>();
        //从终点，往回走到起点。
        int x = rows - 1;
        int y = columns - 1;
        while (x > 0 || y > 0)
        {
            //添加当前元素
            minPath.Add(grid[x][y]);
            //是否走出边界，如果在第一行，只能往左。
            if (x == 0)
            {
                y--;
            }
            //如果在第一列，往上走。
            else if (y == 0)
            {
                x--;
            }
            //比较左边和上边两个值，取小的。
            else
            {
                if (dp[x - 1][y] < dp[x][y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
        }
        //添加起点
        minPath.Add(grid[0][0]);
        //倒置
        minPath.Reverse();
        return minPath;
    }
}
