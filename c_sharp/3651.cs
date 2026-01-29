public class Solution
{
    public int MinCost(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        List<(int x, int y, int cost)> points = new();
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                points.Add((r, c, grid[r][c]));
            }
        }

        points.Sort((a, b) => a.cost.CompareTo(b.cost));
        int[][] costs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            costs[i] = new int[m];
            Array.Fill(costs[i], int.MaxValue);
        }

        for (int t = 0; t <= k; t++)
        {
            int minCost = int.MaxValue;
            for (int i = 0, j = 0; i < points.Count; i++)
            {
                minCost = Math.Min(minCost, costs[points[i].x][points[i].y]);

                if (i + 1 < points.Count && points[i].cost == points[i + 1].cost)
                    continue;

                for (int r = j; r <= i; r++)
                {
                    costs[points[r].x][points[r].y] = minCost;
                }

                j = i + 1;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    if (i == n - 1 && j == m - 1)
                    {
                        costs[i][j] = 0;
                        continue;
                    }

                    if (i != n - 1)
                    {
                        costs[i][j] = Math.Min(costs[i][j], costs[i + 1][j] + grid[i + 1][j]);
                    }

                    if (j != m - 1)
                    {
                        costs[i][j] = Math.Min(costs[i][j], costs[i][j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }
        return costs[0][0];
    }
}

public class Solution2
{
    public int MinCost(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length, maxVal = 0;
        foreach (var row in grid)
        {
            foreach (var val in row)
            {
                maxVal = Math.Max(maxVal, val);
            }
        }

        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[m];
        }

        int[] temp = new int[maxVal + 1];
        int[] best = new int[maxVal + 1];

        Array.Fill(temp, int.MaxValue);

        temp[grid[n - 1][m - 1]] = 0;

        for (int r = n - 1; r >= 0; r--)
        {
            for (int c = m - 1; c >= 0; c--)
            {
                if (r == n - 1 && c == m - 1) continue;

                int down = (r + 1 < n) ? dp[r + 1][c] + grid[r + 1][c] : int.MaxValue;
                int right = (c + 1 < m) ? dp[r][c + 1] + grid[r][c + 1] : int.MaxValue;

                dp[r][c] = Math.Min(down, right);

                if (dp[r][c] != int.MaxValue)
                {
                    temp[grid[r][c]] = Math.Min(temp[grid[r][c]], dp[r][c]);
                }
            }
        }

        for (int t = 0; t < k; t++)
        {
            best[0] = temp[0];
            for (int v = 1; v <= maxVal; v++)
            {
                best[v] = Math.Min(best[v - 1], temp[v]);
            }

            for (int r = n - 1; r >= 0; r--)
            {
                for (int c = m - 1; c >= 0; c--)
                {
                    if (r == n - 1 && c == m - 1) continue;

                    int down = (r + 1 < n) ? dp[r + 1][c] + grid[r + 1][c] : int.MaxValue;
                    int right = (c + 1 < m) ? dp[r][c + 1] + grid[r][c + 1] : int.MaxValue;
                    int walkCost = Math.Min(down, right);

                    int teleportCost = best[grid[r][c]];

                    dp[r][c] = Math.Min(walkCost, teleportCost);

                    if (dp[r][c] != int.MaxValue)
                    {
                        temp[grid[r][c]] = Math.Min(temp[grid[r][c]], dp[r][c]);
                    }
                }
            }
        }
        return dp[0][0];
    }
}