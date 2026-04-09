public class Solution
{
    private const int MOD = 1_000_000_007;
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        foreach (var query in queries)
        {
            int l = query[0];
            int r = query[1];
            int k = query[2];
            int v = query[3];

            for (int i = l; i <= r; i += k)
            {
                long val = nums[i];
                val *= v;
                val %= MOD;
                nums[i] = (int)val;
            }
        }

        int ans = 0;
        foreach (var num in nums)
        {
            ans ^= num;
        }

        return ans;
    }
}