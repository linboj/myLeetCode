public class Solution
{
    public double SoupServings(int n)
    {
        if (n >= 4800) return 1.0;
        int m = (int)Math.Ceiling(n / 25.0);
        double[][] dp = new double[m + 1][];
        for (int i = 1; i <= m; i++)
        {
            dp[i] = new double[m + 1];
            Array.Fill(dp[i], -1.0);
        }
        dp[0] = new double[m + 1];
        Array.Fill(dp[0], 1.0);

        for (int i = 1; i <= m; i++)
        {
            if (calDp(i, i, dp) >= 1 - 1e-5)
                return 1.0;
        }

        return calDp(m, m, dp);
    }

    private double calDp(int i, int j, double[][] dp)
    {
        if (i <= 0 && j <= 0)
            return 0.5;

        if (i <= 0)
            return 1.0;

        if (j <= 0)
            return 0.0;

        if (dp[i][j] >= 0.0)
            return dp[i][j];

        double prob = (calDp(i - 4, j, dp) + calDp(i - 3, j - 1, dp) + calDp(i - 2, j - 2, dp) + calDp(i - 1, j - 3, dp)) / 4;
        dp[i][j] = prob;
        return prob;
    }
}

public class Solution2
{
    public double SoupServings(int n)
    {
        if (n >= 4800) return 1.0;
        int m = (int)Math.Ceiling(n / 25.0);
        double?[,] dp = new double?[m + 1, m + 1];
        for (int i = 0; i <= m; i++)
        {
            dp[0, i] = 1.0;
        }

        for (int i = 1; i <= m; i++)
        {
            if (calDp(i, i, dp) >= 1 - 1e-5)
                return 1.0;
        }

        return calDp(m, m, dp);
    }

    private double calDp(int i, int j, double?[,] dp)
    {
        if (i <= 0 && j <= 0)
            return 0.5;

        if (i <= 0)
            return 1.0;

        if (j <= 0)
            return 0.0;

        if (dp[i, j].HasValue)
            return dp[i, j].Value;

        double prob = (calDp(i - 4, j, dp) + calDp(i - 3, j - 1, dp) + calDp(i - 2, j - 2, dp) + calDp(i - 1, j - 3, dp)) / 4;
        dp[i, j] = prob;
        return prob;
    }
}