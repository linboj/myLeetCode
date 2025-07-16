public class Solution
{
    public int MaximumLength(int[] nums)
    {
        int[][] patterns = [[0, 0], [1, 0], [1, 1], [0, 1]];
        int ans = 0;
        foreach (var pattern in patterns)
        {
            int count = 0;
            foreach (var num in nums)
            {
                if (num % 2 == pattern[count % 2])
                    count++;
            }

            ans = Math.Max(ans, count);
        }
        return ans;
    }
}

public class Solution2
{
    public int MaximumLength(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int oddNum = 0, evenNum = 0;
        int lastOddIdx = -1, lastEvenIdx = -1;
        int ans = 0;
        Array.Fill(dp, 1);
        if (nums[0] % 2 == 0)
        {
            evenNum++;
            lastEvenIdx = 0;
        }
        else
        {
            oddNum++;
            lastOddIdx = 0;
        }

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                evenNum++;
                if (lastOddIdx != -1)
                    dp[i] = dp[lastOddIdx] + 1;
                lastEvenIdx = i;
            }
            else
            {
                oddNum++;
                if (lastEvenIdx != -1)
                    dp[i] = dp[lastEvenIdx] + 1;
                lastOddIdx = i;
            }

            ans = Math.Max(dp[i], Math.Max(evenNum, oddNum));
        }
        return ans;
    }
}