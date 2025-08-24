public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int n = nums.Length;
        int l = 0, nZero = 0;
        int ans = 0;

        for (int r = 0; r < n; r++)
        {
            nZero += nums[r] == 0 ? 1 : 0;

            while (nZero > 1)
            {
                nZero -= nums[l] == 0 ? 1 : 0;
                l++;
            }

            ans = Math.Max(ans, r - l);
        }
        return ans;
    }
}