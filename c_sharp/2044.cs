public class Solution
{
    public int CountMaxOrSubsets(int[] nums)
    {
        int max = 0;
        int[] dp = new int[1 << 17];

        dp[0] = 1;

        foreach (var num in nums)
        {
            for (int i = max; i >= 0; i--)
            {
                dp[i | num] += dp[i];
            }

            max |= num;
        }

        return dp[max];
    }
}

public class Solution2
{
    public int CountMaxOrSubsets(int[] nums)
    {
        int maxOr = 0;
        int count = 0;

        foreach (var num in nums)
        {
            maxOr |= num;
        }

        countSubsets(nums, 0, 0, ref count, maxOr);

        return count;
    }

    private void countSubsets(int[] nums, int index, int currentOr, ref int count, int maxOr)
    {
        if (index == nums.Length)
        {
            if (currentOr == maxOr)
                count++;
            return;
        }

        countSubsets(nums, index + 1, currentOr, ref count, maxOr);
        countSubsets(nums, index + 1, currentOr | nums[index], ref count, maxOr);
    }
}