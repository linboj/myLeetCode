public class Solution
{
    public long[] Distance(int[] nums)
    {
        int n = nums.Length;
        long[] ans = new long[n];
        int[] prefixCnt = new int[n];

        Dictionary<int, long> totalSum = new();
        Dictionary<int, int> totalCnt = new();

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (!totalSum.ContainsKey(num))
            {
                totalSum[num] = 0;
                totalCnt[num] = 0;
            }

            ans[i] = totalSum[num];
            prefixCnt[i] = totalCnt[num];
            totalSum[num] += i;
            totalCnt[num]++;
        }

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            ans[i] = (long)prefixCnt[i] * i - ans[i] + (totalSum[num] - ans[i] - i) - ((long)totalCnt[num] - prefixCnt[i] - 1) * i;
        }

        return ans;
    }
}

public class Solution2
{
    public long[] Distance(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> groups = new();
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (!groups.ContainsKey(num))
                groups[num] = new();

            groups[num].Add(i);
        }

        long[] ans = new long[n];

        foreach (var group in groups.Values)
        {
            long total = 0;
            foreach (var idx in group)
            {
                total += idx;
            }

            long prefixSum = 0;
            int totalCnt = group.Count;
            for (int i = 0; i < totalCnt; i++)
            {
                int idx = group[i];
                ans[idx] = total - prefixSum * 2 + (long)idx * (2 * i - totalCnt);
                prefixSum += idx;
            }
        }

        return ans;
    }
}