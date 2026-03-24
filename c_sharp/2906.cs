public class Solution
{
    private const int MOD = 12345;
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][] ans = new int[n][];

        for (int i = 0; i < n; i++)
        {
            ans[i] = new int[m];
        }

        long suffix = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                ans[i][j] = (int)suffix;
                suffix = suffix * grid[i][j] % MOD;
            }
        }

        long prefix = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ans[i][j] = (int)((long)ans[i][j] * prefix % MOD);
                prefix = prefix * grid[i][j] % MOD;
            }
        }

        return ans;
    }
}