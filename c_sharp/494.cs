// 2D Dynamic Programming
public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int totalSum = nums.Sum();
        int[,] dp = new int[nums.Length, 2 * totalSum + 1];

        dp[0, nums[0] + totalSum] = 1;
        dp[0, -nums[0] + totalSum] += 1;

        for (int idx = 1; idx < nums.Length; idx++)
        {
            for (int sum = -totalSum; sum <= totalSum; sum++)
            {
                if (dp[idx - 1, sum + totalSum] > 0)
                {
                    dp[idx, sum + nums[idx] + totalSum] += dp[idx - 1, sum + totalSum];
                    dp[idx, sum - nums[idx] + totalSum] += dp[idx - 1, sum + totalSum];
                }
            }
        }

        return Math.Abs(target) > totalSum ? 0 : dp[nums.Length - 1, target + totalSum];

    }
}

// Space Optimized
public class Solution2
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int totalSum = nums.Sum();
        int[] dp = new int[2 * totalSum + 1];


        dp[nums[0] + totalSum] = 1;
        dp[-nums[0] + totalSum] += 1;

        for (int idx = 1; idx < nums.Length; idx++)
        {
            int[] next = new int[2 * totalSum + 1];
            for (int sum = -totalSum; sum <= totalSum; sum++)
            {
                if (dp[sum + totalSum] > 0)
                {
                    next[sum + nums[idx] + totalSum] += dp[sum + totalSum];
                    next[sum - nums[idx] + totalSum] += dp[sum + totalSum];
                }
            }
            dp = next;
        }

        return Math.Abs(target) > totalSum ? 0 : dp[target + totalSum];

    }
}