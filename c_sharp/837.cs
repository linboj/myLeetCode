public class Solution
{
    public double New21Game(int n, int k, int maxPts)
    {
        if (k == 0 || n >= k + maxPts)
            return 1.0;

        double[] dp = new double[n + 1];
        dp[0] = 1.0;
        double current = 1.0;
        double ans = 0;

        for (int i = 1; i <= n; i++)
        {
            dp[i] = current / maxPts;
            if (i < k)
                current += dp[i];
            else
                ans += dp[i];

            if (i >= maxPts)
                current -= dp[i - maxPts];
        }
        return ans;

    }
}