public class Solution
{
    public int MinRemoval(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        int l = 0;

        Array.Sort(nums);

        for (int r = 0; r < n; r++)
        {
            while (l <= r && !IsValid(nums[l], nums[r], k))
                l++;

            ans = Math.Min(ans, n - (r - l + 1));
        }

        return ans;
    }

    private bool IsValid(int l, int r, int k)
    {
        return (long)l * k >= r;
    }
}