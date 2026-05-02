public class Solution
{
    public int MaxRotateFunction(int[] nums)
    {
        int n = nums.Length;
        int f = 0;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            f += nums[i] * i;
        }

        int ans = f;
        for (int i = 1; i < n; i++)
        {
            f += sum - n * nums[n - i];
            ans = Math.Max(ans, f);
        }

        return ans;
    }
}