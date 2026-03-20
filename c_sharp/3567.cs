public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][] ans = new int[n - k + 1][];

        for (int r = 0; r <= n - k; r++)
        {
            ans[r] = new int[m - k + 1];
            for (int c = 0; c <= m - k; c++)
            {
                List<int> window = new();

                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        window.Add(grid[r + i][c + j]);
                    }
                }

                window.Sort();

                int minDiff = int.MaxValue;
                for (int i = 1; i < window.Count; i++)
                {
                    int diff = window[i] - window[i - 1];
                    if (diff > 0)
                        minDiff = Math.Min(minDiff, diff);
                }

                if (minDiff != int.MaxValue)
                    ans[r][c] = minDiff;
            }
        }
        return ans;
    }
}