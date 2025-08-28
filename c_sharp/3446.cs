public class Solution
{
    public int[][] SortMatrix(int[][] grid)
    {
        int n = grid.Length;

        for (int i = 0; i < n; i++)
        {
            List<int> tmp = new();
            for (int j = 0; i + j < n; j++)
            {
                tmp.Add(grid[i + j][j]);
            }
            tmp.Sort((x, y) => y.CompareTo(x));
            for (int j = 0; j + i < n; j++)
            {
                grid[i + j][j] = tmp[j];
            }
        }

        for (int j = 1; j < n; j++)
        {
            List<int> tmp = new();
            for (int i = 0; i + j < n; i++)
            {
                tmp.Add(grid[i][i + j]);
            }
            tmp.Sort();
            for (int i = 0; i + j < n; i++)
            {
                grid[i][i + j] = tmp[i];
            }
        }
        return grid;
    }
}