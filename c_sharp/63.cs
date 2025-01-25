public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        int[] counts = new int[n];
        counts[0] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int col = 1; col < n; col++)
        {
            if (obstacleGrid[0][col] != 0)
                counts[col] = 0;
            else
                counts[col] = counts[col - 1];
        }
        for (int row = 1; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (obstacleGrid[row][col] != 0)
                    counts[col] = 0;
                else if (col - 1 >= 0)
                    counts[col] += counts[col - 1];
            }
        }
        return counts[n - 1];
    }
}