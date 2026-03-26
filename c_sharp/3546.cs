public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        long[] rows = new long[n], cols = new long[m];
        long sum = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                sum += grid[r][c];
                rows[r] += grid[r][c];
                cols[c] += grid[r][c];
            }
        }

        if (sum % 2 == 1) return false;

        long half = sum / 2;

        long cur = 0;
        for (int i = 0; i < n; i++)
        {
            cur += rows[i];
            if (half == cur) return true;
        }

        cur = 0;
        for (int i = 0; i < m; i++)
        {
            cur += cols[i];
            if (half == cur) return true;
        }


        return false;
    }
}