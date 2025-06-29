public class Solution
{
    private int MOD = 1_000_000_007;
    public int NumSubseq(int[] nums, int target)
    {
        int n = nums.Length;
        Array.Sort(nums);
        long ans = 0;
        int left = 0, right = n - 1;
        long[] pow = new long[n];
        pow[0] = 1;

        for (int i = 1; i < n; i++)
        {
            pow[i] = pow[i - 1] * 2 % MOD;
        }

        while (left <= right)
        {
            if (nums[left] + nums[right] <= target)
            {
                ans = (ans + pow[right - left]) % MOD;
                left++;
            }
            else
            {
                right--;
            }
        }
        return (int)ans;
    }
}