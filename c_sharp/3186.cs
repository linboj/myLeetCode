public class Solution
{
    public long MaximumTotalDamage(int[] power)
    {
        var counts = new Dictionary<int, int>();
        foreach (var item in power)
        {
            if (!counts.ContainsKey(item))
                counts[item] = 0;
            counts[item]++;
        }

        int[] p = new int[counts.Count];
        int idx = 0;
        foreach (var key in counts.Keys)
            p[idx++] = key;

        Array.Sort(p);
        long[] dp = new long[idx];
        dp[0] = (long)p[0] * counts[p[0]];
        long ans = dp[0];

        for (int i = 1; i < idx; i++)
        {
            dp[i] = (long)p[i] * counts[p[i]];
            long current = dp[i];
            for (int j = i - 1; j >= Math.Max(0, i - 5); j--)
            {
                if (p[j] + 2 < p[i])
                    dp[i] = Math.Max(dp[i], dp[j] + current);
            }
            ans = Math.Max(ans, dp[i]);
        }

        return ans;
    }
}