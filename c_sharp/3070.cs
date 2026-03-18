public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        int[] cols = new int[m];
        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            int rows = 0;
            for (int j = 0; j < m; j++)
            {
                cols[j] += grid[i][j];
                rows += cols[j];
                if (rows <= k)
                    ans++;
            }
        }
        return ans;
    }
}