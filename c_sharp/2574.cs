public class Solution
{
    public int[] LeftRightDifference(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int totalSum = 0, leftSum = 0;

        for (int i = 0; i < n; i++)
        {
            ans[i] = -leftSum * 2 - nums[i];
            leftSum += nums[i];
            totalSum += nums[i];
        }

        for (int i = 0; i < n; i++)
        {
            ans[i] = Math.Abs(ans[i] + totalSum);
        }

        return ans;
    }
}