public class Solution
{
    private const int MOD = 1000000007;

    public int NumberOfWays(int n, int x)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            int value = (int)Math.Pow(i, x);
            if (value > n)
                break;

            for (int j = n; j >= value; j--)
            {
                dp[j] = (dp[j] + dp[j - value]) % MOD;
            }
        }
        return dp[n];
    }
}