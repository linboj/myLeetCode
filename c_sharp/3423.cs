public class Solution
{
    public int MaxAdjacentDistance(int[] nums)
    {
        int n = nums.Length;
        int maxDiff = Math.Abs(nums[0] - nums[n - 1]);
        for (int i = 1; i < n; i++)
        {
            maxDiff = Math.Max(maxDiff, Math.Abs(nums[i] - nums[i - 1]));
        }

        return maxDiff;
    }
}