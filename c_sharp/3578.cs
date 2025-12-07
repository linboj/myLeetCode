public class Solution
{
    private const int MOD = 1_000_000_007;
    public int CountPartitions(int[] nums, int k)
    {
        int n = nums.Length;
        long[] dp = new long[n + 1];
        long[] prefix = new long[n + 1];
        LinkedList<int> minQueue = new();
        LinkedList<int> maxQueue = new();

        dp[0] = 1;
        prefix[0] = 1;
        for (int i = 0, j = 0; i < n; i++)
        {
            int num = nums[i];
            while (maxQueue.Count > 0 && nums[maxQueue.Last.Value] <= num)
            {
                maxQueue.RemoveLast();
            }
            maxQueue.AddLast(i);

            while (minQueue.Count > 0 && nums[minQueue.Last.Value] >= num)
            {
                minQueue.RemoveLast();
            }
            minQueue.AddLast(i);

            while (maxQueue.Count > 0 && minQueue.Count > 0 &&
                nums[maxQueue.First.Value] - nums[minQueue.First.Value] > k)
            {
                if (maxQueue.First.Value == j)
                    maxQueue.RemoveFirst();

                if (minQueue.First.Value == j)
                    minQueue.RemoveFirst();

                j++;
            }

            dp[i + 1] = (prefix[i] - (j > 0 ? prefix[j - 1] : 0) + MOD) % MOD;
            prefix[i + 1] = (prefix[i] + dp[i + 1]) % MOD;
        }
        return (int)dp[n];
    }
}