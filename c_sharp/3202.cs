public class Solution
{
    public int MaximumLength(int[] nums, int k)
    {
        int[][] dp = new int[k][];
        for (int i = 0; i < k; i++)
        {
            dp[i] = new int[k];
        }

        int ans = 0;
        foreach (var num in nums)
        {
            int mod = num % k;
            for (int prev = 0; prev < k; prev++)
            {
                dp[prev][mod] = dp[mod][prev] + 1;
                ans = Math.Max(ans, dp[prev][mod]);
            }
        }
        return ans;
    }
}