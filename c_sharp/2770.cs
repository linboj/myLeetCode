public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        dp[0] = 1;

        for (int i = 1; i < n; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (dp[j] >= 1 && Math.Abs(nums[i] - nums[j]) <= target)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp[n - 1] <= 1 ? -1 : dp[n - 1] - 1;
    }
}