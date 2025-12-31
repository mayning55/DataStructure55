using System;

namespace ConsoleApp1;

public class Arrays
{
    //while 循环 
    public int WhileLoop(int n)
    {
        int res = 0;
        int i = 1; // 初始化条件变量
                   // 循环求和 1, 2, ..., n-1, n
        while (i <= n)
        {
            res += i;
            i += 1; // 更新条件变量
        }
        return res;
    }

}
