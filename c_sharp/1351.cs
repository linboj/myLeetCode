public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int ans = 0;
        int n = grid.Length, m = grid[0].Length;
        int row = n - 1, col = 0;

        while (row >= 0 && col < m)
        {
            if (grid[row][col] < 0)
            {
                ans += m - col;
                row--;
            }
            else
            {
                col++;
            }
        }

        return ans;
    }
}