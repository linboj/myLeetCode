public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        if (query_row == 0)
            return Math.Min(poured, 1);

        query_glass = Math.Min(query_glass, query_row - query_glass);

        double[] dp = new double[query_glass + 2];
        dp[0] = poured;

        for (int r = 0; r < query_row; r++)
        {
            int end = Math.Min(r, query_glass);
            dp[end + 1] = 0.0;

            int nextLow = int.MaxValue, nextHigh = -1;
            bool pouring = false;

            for (int c = end; c >= 0; c--)
            {
                double x = dp[c];
                if (x > 1.0)
                {
                    pouring = true;
                    double overflow = (x - 1.0) * 0.5;
                    dp[c] = overflow;
                    dp[c + 1] += overflow;

                    if (c < nextLow) nextLow = c;
                    if (c > nextHigh) nextHigh = c;
                    if (c + 1 <= query_glass && c + 1 > nextHigh) nextHigh = c + 1;
                }
                else
                {
                    dp[c] = 0.0;
                }
            }

            if (!pouring)
                return 0.0;

            int left = query_row - (r + 1);
            if (query_glass < nextLow - left || query_glass > nextHigh + left)
                return 0.0;
        }

        return Math.Min(1.0, dp[query_glass]);
    }
}

public class Solution2
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        double[] prev = new double[] { poured };

        for (int r = 1; r <= query_row; r++)
        {
            double[] cur = new double[r + 1];
            for (int i = 0; i < r; i++)
            {
                double extra = prev[i] - 1.0;
                if (extra > 0)
                {
                    cur[i] += extra / 2;
                    cur[i + 1] += extra / 2;
                }
            }
            prev = cur;
        }

        return Math.Min(1.0, prev[query_glass]);
    }
}