public class Solution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;

        for (int r = 0; r < n - 2; r++)
        {
            for (int c = 0; c < m - 2; c++)
            {
                if (isMagicSquare(grid, r, c))
                    ans++;
            }
        }

        return ans;
    }

    private bool isMagicSquare(int[][] grid, int row, int col)
    {
        if (grid[row + 1][col + 1] != 5) return false;
        int sum = 0;
        int[] seen = new int[10];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int num = grid[row + i][col + j];
                if (num < 1 || num > 9 || seen[num] != 0) return false;
                seen[num]++;
                sum += num;
            }
        }

        sum /= 3;

        for (int i = 0; i < 3; i++)
        {
            if (grid[row + i][col] + grid[row + i][col + 1] + grid[row + i][col + 2] != sum)
                return false;

            if (grid[row][col + i] + grid[row + 1][col + i] + grid[row + 2][col + i] != sum)
                return false;
        }

        if (grid[row][col] + grid[row + 1][col + 1] + grid[row + 2][col + 2] != sum) return false;
        if (grid[row + 2][col] + grid[row + 1][col + 1] + grid[row][col + 2] != sum) return false;

        return true;
    }
}