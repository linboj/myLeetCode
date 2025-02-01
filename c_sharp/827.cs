public class Solution
{
    private int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    public int LargestIsland(int[][] grid)
    {
        int n = grid.Length;
        int maxArea = 0, islandId = 2;
        List<int> islands = new List<int>();
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                int area = exploreIsland(grid, row, col, islandId);
                if (area > 0)
                {
                    islands.Add(area);
                    islandId++;
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }
        if (islands.Count == 0) return 1;
        maxArea = Math.Min(maxArea + 1, n*n);
        if (islands.Count == 1) return maxArea;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == 0)
                {
                    HashSet<int> adjIsland = new();
                    foreach (var dir in dirs)
                    {
                        int neighborRow = row + dir[0];
                        int neighborCol = col + dir[1];
                        if (neighborRow < 0 || neighborCol < 0 || neighborCol >= n || neighborRow >= n || grid[neighborRow][neighborCol] <= 1) continue;
                        adjIsland.Add(grid[neighborRow][neighborCol]);
                    }
                    int area = 1;
                    foreach (var island in adjIsland)
                    {
                        area += islands[island - 2];
                    }
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }
        return maxArea;
    }

    private int exploreIsland(int[][] grid, int currentRow, int currentCol, int islandId)
    {
        int n = grid.Length;
        if (currentRow < 0 || currentCol < 0 || currentCol >= n || currentRow >= n || grid[currentRow][currentCol] != 1) return 0;

        grid[currentRow][currentCol] = islandId;
        int area = 1;

        foreach (var dir in dirs)
        {
            int neighborRow = currentRow + dir[0];
            int neighborCol = currentCol + dir[1];

            area += exploreIsland(grid, neighborRow, neighborCol, islandId);
        }
        return area;
    }
}