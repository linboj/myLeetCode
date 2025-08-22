public class Solution
{
    public int MinimumArea(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int top = n, bottom = 0;
        int left = m, right = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if (grid[r][c] == 1)
                {
                    top = Math.Min(top, r);
                    bottom = Math.Max(bottom, r);
                    left = Math.Min(left, c);
                    right = Math.Max(right, c);
                }
            }
        }
        return (bottom - top + 1) * (right - left + 1);
    }
}