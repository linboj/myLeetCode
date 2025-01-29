public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        int maxFish = 0, m = grid.Length, n = grid[0].Length;

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int currentFish = DFS(grid, r, c);
                maxFish = Math.Max(currentFish, maxFish);
            }
        }

        return maxFish;
    }

    private int DFS(int[][] grid, int r, int c)
    {
        if (r < 0 || c < 0 || r >= grid.Length || c >= grid[0].Length) return 0;
        if (grid[r][c] == 0) return 0;
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        int currentFish = grid[r][c];
        grid[r][c] = 0;
        foreach (var dir in dirs)
        {
            int neighborRow = r + dir[0];
            int neighborCol = c + dir[1];

            currentFish += DFS(grid, neighborRow, neighborCol);
        }
        return currentFish;
    }
}