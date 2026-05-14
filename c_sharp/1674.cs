public class Solution
{
    public int MinMoves(int[] nums, int limit)
    {
        int n = nums.Length;
        int[] diff = new int[2 * limit + 2];

        for (int i = 0; i < n / 2; i++)
        {
            int a = Math.Min(nums[i], nums[n - 1 - i]);
            int b = Math.Max(nums[i], nums[n - 1 - i]);

            diff[2] += 2;
            diff[a + 1] -= 1;
            diff[a + b] -= 1;
            diff[a + b + 1] += 1;
            diff[b + limit + 1] += 1;
        }

        int ans = n;
        int cur = 0;

        for (int i = 2; i <= 2 * limit; i++)
        {
            cur += diff[i];
            ans = Math.Min(ans, cur);
        }

        return ans;
    }
}