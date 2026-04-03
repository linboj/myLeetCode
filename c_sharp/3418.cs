using System.Runtime.Intrinsics.Arm;

public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        int n = coins.Length, m = coins[0].Length;
        int[,] dp = new int[m + 1, 3];

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                dp[i, j] = int.MinValue / 2;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            dp[1, i] = 0;
        }

        foreach (var row in coins)
        {
            for (int i = 1; i <= m; i++)
            {
                int x = row[i - 1];

                dp[i, 2] = Math.Max(Math.Max(dp[i - 1, 2] + x, dp[i, 2] + x),
                                    Math.Max(dp[i - 1, 1], dp[i, 1]));
                dp[i, 1] = Math.Max(Math.Max(dp[i - 1, 1] + x, dp[i, 1] + x),
                                    Math.Max(dp[i - 1, 0], dp[i, 0]));
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i, 0]) + x;
            }
        }

        return Math.Max(dp[m, 2], Math.Max(dp[m, 1], dp[m, 0]));
    }
}