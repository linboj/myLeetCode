public class Solution
{
    private const int MOD = 1_000_000_007;

    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int t = (int)Math.Sqrt(n);

        List<List<int[]>> groups = new(t);
        for (int i = 0; i < t; i++)
        {
            groups.Add(new List<int[]>());
        }

        foreach (var q in queries)
        {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            if (k < t)
            {
                groups[k].Add([l, r, v]);
            }
            else
            {
                for (int i = l; i <= r; i += k)
                {
                    nums[i] = (int)((long)nums[i] * v % MOD);
                }
            }
        }

        long[] diff = new long[n + t];
        for (int k = 1; k < t; k++)
        {
            if (groups[k].Count == 0)
                continue;

            Array.Fill(diff, 1);
            foreach (var q in groups[k])
            {
                int l = q[0], r = q[1], v = q[2];
                diff[l] = diff[l] * v % MOD;
                int right = ((r - l) / k + 1) * k + l;
                diff[right] = diff[right] * Pow(v, MOD - 2) % MOD;
            }

            for (int i = k; i < n; i++)
            {
                diff[i] = diff[i] * diff[i - k] % MOD;
            }

            for (int i = 0; i < n; i++)
            {
                nums[i] = (int)((long)nums[i] * diff[i] % MOD);
            }
        }

        int ans = 0;
        foreach (var num in nums)
        {
            ans ^= num;
        }

        return ans;
    }

    private int Pow(long x, long y)
    {
        long result = 1;
        while (y > 0)
        {
            if ((y & 1) == 1)
            {
                result = result * x % MOD;
            }

            x = x * x % MOD;
            y >>= 1;
        }

        return (int)result;
    }
}