public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        int kh = k / 2;

        for (int i = 0; i < kh; i++)
        {
            for (int j = 0; j < k; j++)
            {
                int tmp = grid[x + i][y + j];
                grid[x + i][y + j] = grid[x + k - 1 - i][y + j];
                grid[x + k - 1 - i][y + j] = tmp;
            }
        }
        return grid;
    }
}