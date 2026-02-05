public class Solution
{
    public long MaxSumTrionic(int[] nums)
    {
        int n = nums.Length;
        long ans = long.MinValue;

        for (int i = 0; i < n; i++)
        {
            int j = i + 1;
            long sum = 0;

            while (j < n && nums[j - 1] < nums[j]) // increasing
                j++;

            int a = j - 1;

            if (a == i)
                continue;

            sum += nums[a] + nums[a - 1];

            while (j < n && nums[j - 1] > nums[j])  // decrease
            {
                sum += nums[j++];
            }

            int b = j - 1;

            if (a == b || b == n - 1 || (j < n && nums[j] == nums[b]))
            {
                i = b;
                continue;
            }

            sum += nums[b + 1];

            long maxSum = 0;
            long curSum = 0;

            for (int c = b + 2; c < n && nums[c] > nums[c - 1]; c++)  // increase
            {
                curSum += nums[c];
                maxSum = Math.Max(maxSum, curSum);
            }
            sum += maxSum;

            maxSum = 0;
            curSum = 0;
            for (int c = a - 2; c >= i; c--)
            {
                curSum += nums[c];
                maxSum = Math.Max(maxSum, curSum);
            }
            sum += maxSum;

            ans = Math.Max(ans, sum);
            i = b - 1;
        }

        return ans;
    }
}