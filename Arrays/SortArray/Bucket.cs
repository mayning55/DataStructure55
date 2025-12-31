namespace Arrays.SortArray;

public class Bucket
{
    /// <summary>
    /// 桶排序
    /// 是一种高效的分布式排序算法，适用于数据分布较为均匀的情况。它通过将数据分配到多个桶中，再对每个桶进行排序，最后合并所有桶中的数据来完成排序。
    /// </summary>
    /// <param name="array"></param>
    public static void BucketSort(int[] array)
    {
        int m = array.Length;
        if (m < 2)
        {
            return;
        }
        // 找到数组中的最大值和最小值
        int maxValue = array[0];
        int minValue = array[0];
        foreach (int num in array)
        {
            if (num > maxValue) maxValue = num;
            if (num < minValue) minValue = num;
        }
        // 确定桶的数量和创建相应的桶
        int bucketCount = (maxValue - minValue) / m + 1;
        List<List<int>> buckets = new List<List<int>>(bucketCount);
        for (int i = 0; i < bucketCount; i++)
        {
            buckets.Add(new List<int>());
        }

        // 将数据分配到对应的桶中
        foreach (int num in array)
        {
            int bucketIndex = (num - minValue) / array.Length;
            buckets[bucketIndex].Add(num);
        }

        // 对每个非空桶进行排序并合并结果
        int index = 0;
        foreach (var bucket in buckets)
        {
            if (bucket.Count > 0)
            {
                bucket.Sort(); // 使用内置排序
                foreach (int num in bucket)
                {
                    array[index] = num;
                    index++;
                }
            }
        }
    }

}
