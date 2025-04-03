public class Solution
{
    // prefix sum
    public long MaximumTripletValue(int[] nums)
    {
        int n = nums.Length;
        int[] leftMax = new int[n];
        int[] rightMax = new int[n];

        leftMax[0] = nums[0];
        rightMax[n - 1] = nums[n - 1];
        for (int i = 1; i < n; i++)
        {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i - 1]);
            rightMax[n - i - 1] = Math.Max(rightMax[n - i], nums[n - i]);
        }

        long ans = 0;
        for (int i = 1; i < n - 1; i++)
        {
            ans = Math.Max(ans, (long)(leftMax[i] - nums[i]) * rightMax[i]);
        }
        return ans;
    }
}

public class Solution2
{
    // greedy
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