public class Solution
{
    private const int MOD = 1_000_000_007;
    public int MaxProductPath(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        long[] prevMin = new long[m], prevMax = new long[m];

        prevMax[0] = prevMin[0] = grid[0][0];
        for (int c = 1; c < m; c++)
        {
            prevMax[c] = Math.Max(prevMax[c - 1] * grid[0][c], prevMin[c - 1] * grid[0][c]);
            prevMin[c] = Math.Min(prevMax[c - 1] * grid[0][c], prevMin[c - 1] * grid[0][c]);
        }

        for (int r = 1; r < n; r++)
        {
            long[] curMin = new long[m], curMax = new long[m];
            curMax[0] = Math.Max(prevMax[0] * grid[r][0], prevMin[0] * grid[r][0]);
            curMin[0] = Math.Min(prevMax[0] * grid[r][0], prevMin[0] * grid[r][0]);

            for (int c = 1; c < m; c++)
            {
                if (grid[r][c] >= 0)
                {
                    curMax[c] = Math.Max(curMax[c - 1], prevMax[c]) * grid[r][c];
                    curMin[c] = Math.Min(curMin[c - 1], prevMin[c]) * grid[r][c];
                }
                else
                {
                    curMax[c] = Math.Min(curMin[c - 1], prevMin[c]) * grid[r][c];
                    curMin[c] = Math.Max(curMax[c - 1], prevMax[c]) * grid[r][c];
                }
            }

            prevMax = curMax;
            prevMin = curMin;
        }

        return prevMax[m - 1] < 0 ? -1 : (int)(prevMax[m - 1] % MOD);
    }
}