public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        long ans = 0, lMax = 0, diffMax = 0;

        for (int i = 0; i < n; i++)
        {
            ans = Math.Max(ans, diffMax * nums[i]);
            diffMax = Math.Max(diffMax, lMax - nums[i]);
            lMax = Math.Max(lMax, nums[i]);
        }

        return ans;
    }
}