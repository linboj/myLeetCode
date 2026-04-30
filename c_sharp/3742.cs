public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;

        int[][] prev = new int[m][];

        for (int i = 0; i < m; i++)
        {
            prev[i] = new int[k + 1];
            Array.Fill(prev[i], -1);
        }

        for (int i = 0; i < n; i++)
        {
            int[][] cur = new int[m][];
            for (int j = 0; j < m; j++)
            {
                cur[j] = new int[k + 1];
                Array.Fill(cur[j], -1);
            }

            for (int j = 0; j < m; j++)
            {
                int gain = grid[i][j];
                int need = gain == 0 ? 0 : 1;

                int limit = Math.Min(k, i + j);

                if (i == 0 && j == 0)
                {
                    cur[i][j] = 0;
                    continue;
                }

                for (int c = need; c <= limit; c++)
                {
                    int best = -1;

                    if (i > 0 && prev[j][c - need] != -1)
                    {
                        best = Math.Max(best, prev[j][c - need] + gain);
                    }

                    if (j > 0 && cur[j - 1][c - need] != -1)
                    {
                        best = Math.Max(best, cur[j - 1][c - need] + gain);
                    }

                    cur[j][c] = best;
                }
            }
            prev = cur;
        }

        int ans = -1;
        for (int i = 0; i <= k; i++)
        {
            ans = Math.Max(ans, prev[m - 1][i]);
        }

        return ans;
    }
}