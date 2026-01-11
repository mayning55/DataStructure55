using System;
using System.Threading.Tasks.Dataflow;

namespace DynamicProgramming;
/// <summary>
/// 矩阵线性DP
/// </summary>
public class MatrixLinearDP
{
    /// <summary>
    /// 最大正方形
    /// </summary>
    /// <param name="grid"></param>一个由 0 和 1 组成的二维矩阵
    /// <returns></returns>包含 '1' 的最大正方形的面积
    public int MaximalSquare(int[][] matrix)
    {

        //最大边长
        int maxSide = 0;
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        {
            return maxSide;
        }
        int rows = matrix.Length;
        int columns = matrix[0].Length;
        //初始化矩阵
        int[][] dp = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            dp[i] = new int[columns];
        }
        //遍历所有元素
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //如果当前元素为1.根据其位置判断边长。
                if (matrix[i][j] == 1)
                {
                    //边界
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    //上方，左上，左最小值+1.
                    else
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;
                    }
                    //更新边长。
                    maxSide = Math.Max(maxSide, dp[i][j]);
                }
            }
        }
        return maxSide * maxSide;
    }
    /// <summary>
    /// 为 1 的正方形子矩阵数目
    /// </summary>
    /// <param name="matrix"></param>由 '0' 和 '1' 组成的二维矩阵
    /// <returns></returns>统计并返回其中完全由 1 组成的 正方形 子矩阵的个数
    public int CountSquares(int[][] matrix)
    {
        int result = 0;
        int rows = matrix.Length;
        int columns = matrix[0].Length;
        int[][] dp = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            dp[i] = new int[columns];
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //如果元素靠边，等于原矩阵
                if (i == 0 || j == 0)
                {
                    dp[i][j] = matrix[i][j];
                }
                //如果原位置元素为0，
                else if (matrix[i][j] == 0)
                {
                    dp[i][j] = 0;
                }
                //上方，左上，左最小值+1
                else
                {
                    dp[i][j] = Math.Min(Math.Min(dp[i][j - 1], dp[i-1][j]), dp[i - 1][j - 1]) + 1;
                }
                //累加结果
                result += dp[i][j];
            }
        }
        return result;
    }

}
