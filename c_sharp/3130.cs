public class Solution
{
    private const int MOD = 1_000_000_007;
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        long[][][] dp = new long[zero + 1][][];
        for (int i = 0; i <= zero; i++)
        {
            dp[i] = new long[one + 1][];
            for (int j = 0; j <= one; j++)
            {
                dp[i][j] = new long[2];
                for (int lastBit = 0; lastBit <= 1; lastBit++)
                {
                    if (i == 0)
                    {
                        if (lastBit == 1 && j <= limit)
                            dp[i][j][lastBit] = 1;
                    }
                    else if (j == 0)
                    {
                        if (lastBit == 0 && i <= limit)
                            dp[i][j][lastBit] = 1;
                    }
                    else if (lastBit == 0)
                    {
                        dp[i][j][lastBit] = dp[i - 1][j][0] + dp[i - 1][j][1];
                        if (i > limit)
                            dp[i][j][lastBit] -= dp[i - limit - 1][j][1];
                    }
                    else
                    {
                        dp[i][j][lastBit] = dp[i][j - 1][0] + dp[i][j - 1][1];
                        if (j > limit)
                            dp[i][j][lastBit] -= dp[i][j - limit - 1][0];
                    }
                    dp[i][j][lastBit] %= MOD;
                    if (dp[i][j][lastBit] < 0)
                        dp[i][j][lastBit] += MOD;
                }
            }
        }
        return (int)((dp[zero][one][0] + dp[zero][one][1]) % MOD);
    }
}