public class Solution
{
    public long DistributeCandies(int n, int limit)
    {
        long ans = 0;
        int end = Math.Min(n, limit);
        for (int i = 0; i <= end; i++)
        {
            if (n - i > 2 * limit)
                continue;

            ans += Math.Min(n - i, limit) - Math.Max(0, n - i - limit) + 1;
        }

        return ans;
    }
}

public class Solution2
{
    public long DistributeCandies(int n, int limit)
    {
        long ans = 0;

        ans = Combination(n + 2) - 3 * Combination(n - (limit + 1) + 2) + 3 * Combination(n - 2 * (limit + 1) + 2) - Combination(n - 3 * (limit + 1) + 2);

        return ans;
    }

    private long Combination(int n)
    {
        if (n < 0)
            return 0;
        return (long)n * (n - 1) / 2;
    }
}