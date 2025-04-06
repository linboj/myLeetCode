public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int n = nums.Length;
        if (n == 0)
            return new List<int>();

        Array.Sort(nums);
        int[] dp = new int[n];
        int[] prev = new int[n];
        int maxIdx = -1, maxSize = 0;

        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            prev[i] = -1;

            for (int j = 0; j < i; j++)
            {
                if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }

            if (dp[i] > maxSize)
            {
                maxSize = dp[i];
                maxIdx = i;
            }
        }

        List<int> result = new List<int>();
        while (maxIdx != -1)
        {
            result.Add(nums[maxIdx]);
            maxIdx = prev[maxIdx];
        }

        result.Reverse();
        return result;
    }
}