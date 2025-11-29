public class Solution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        long prefixSum = 0;
        long ans = long.MinValue;
        long[] kSum = new long[k];
        for (int i = 0; i < k; i++)
        {
            kSum[i] = long.MaxValue / 2;
        }

        kSum[k - 1] = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            int r = i % k;
            ans = Math.Max(ans, prefixSum - kSum[r]);
            kSum[r] = Math.Min(kSum[r], prefixSum);
        }
        return ans;
    }
}