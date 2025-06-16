public class Solution
{
    public int MaximumDifference(int[] nums)
    {
        int n = nums.Length;
        int minVal = nums[0];
        int ans = -1;

        for (int i = 1; i < n; i++)
        {
            ans = Math.Max(ans, nums[i] - minVal);
            minVal = Math.Min(minVal, nums[i]);
        }

        return ans <= 0 ? -1 : ans;
    }
}