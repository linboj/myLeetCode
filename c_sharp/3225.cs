public class Solution
{
    public long MaximumScore(int[][] grid)
    {
        int n = grid[0].Length;

        long[,,] dp = new long[n, n + 1, n + 1];
        long[,] prevMax = new long[n + 1, n + 1];
        long[,] prevSuffixMax = new long[n + 1, n + 1];
        long[,] colSum = new long[n, n + 1];

        for (int c = 0; c < n; c++)
        {
            for (int r = 1; r <= n; r++)
            {
                colSum[c, r] = colSum[c, r - 1] + grid[r - 1][c];
            }
        }

        for (int i = 1; i < n; i++)
        {
            for (int curH = 0; curH <= n; curH++)
            {
                for (int prevH = 0; prevH <= n; prevH++)
                {
                    if (curH <= prevH)
                    {
                        long extractScore = colSum[i, prevH] - colSum[i, curH];
                        dp[i, curH, prevH] = Math.Max(
                            dp[i, curH, prevH],
                            prevSuffixMax[prevH, 0] + extractScore
                            );
                    }
                    else
                    {
                        long extractScore = colSum[i - 1, curH] - colSum[i - 1, prevH];
                        dp[i, curH, prevH] = Math.Max(
                            dp[i, curH, prevH],
                            Math.Max(
                                prevSuffixMax[prevH, curH],
                                prevMax[prevH, curH] + extractScore));
                    }
                }
            }

            for (int curH = 0; curH <= n; curH++)
            {
                prevMax[curH, 0] = dp[i, curH, 0];
                for (int prevH = 1; prevH <= n; prevH++)
                {
                    long penalty = (prevH > curH) ? colSum[i, prevH] - colSum[i, curH] : 0;
                    prevMax[curH, prevH] = Math.Max(prevMax[curH, prevH - 1], dp[i, curH, prevH] - penalty);
                }

                prevSuffixMax[curH, n] = dp[i, curH, n];
                for (int prevH = n - 1; prevH >= 0; prevH--)
                {
                    prevSuffixMax[curH, prevH] = Math.Max(prevSuffixMax[curH, prevH + 1], dp[i, curH, prevH]);
                }
            }
        }

        long ans = 0;
        for (int i = 0; i <= n; i++)
        {
            ans = Math.Max(ans, Math.Max(dp[n - 1, n, i], dp[n - 1, 0, i]));
        }

        return ans;
    }
}