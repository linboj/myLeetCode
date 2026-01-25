public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int left = 0, right = Math.Min(n - 1, k - 1);
        int ans = int.MaxValue;

        while (right < n)
        {
            int diff = nums[right++] - nums[left++];
            ans = Math.Min(diff, ans);
        }

        return ans;
    }
}