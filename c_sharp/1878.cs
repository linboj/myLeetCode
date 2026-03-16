public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[,] sum1 = new int[n + 1, m + 2];
        int[,] sum2 = new int[n + 1, m + 2];

        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= m; c++)
            {
                sum1[r, c] = sum1[r - 1, c - 1] + grid[r - 1][c - 1];
                sum2[r, c] = sum2[r - 1, c + 1] + grid[r - 1][c - 1];
            }
        }

        int[] tmp = new int[3];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                UpdateAns(tmp, grid[r][c]);
                for (int k = r + 2; k < n; k += 2)
                {
                    int ux = r, uy = c;
                    int dx = k, dy = c;
                    int lx = (r + k) / 2, ly = c - (k - r) / 2;
                    int rx = (r + k) / 2, ry = c + (k - r) / 2;
                    if (ly < 0 || ry >= m)
                    {
                        break;
                    }

                    int sum = sum2[lx + 1, ly + 1] - sum2[ux, uy + 2] +
                              (sum1[rx + 1, ry + 1] - sum1[ux, uy]) +
                              (sum1[dx + 1, dy + 1] - sum1[lx, ly]) +
                              (sum2[dx + 1, dy + 1] - sum2[rx, ry + 2]) -
                              (grid[ux][uy] + grid[dx][dy] + grid[lx][ly] +
                               grid[rx][ry]);

                    UpdateAns(tmp, sum);
                }
            }
        }

        List<int> ans = new();
        foreach (var v in tmp)
        {
            if (v > 0)
                ans.Add(v);
        }

        return ans.ToArray();
    }

    private void UpdateAns(int[] ans, int val)
    {
        if (ans[0] < val)
        {
            ans[2] = ans[1];
            ans[1] = ans[0];
            ans[0] = val;
        }
        else if (val != ans[0] && val > ans[1])
        {
            ans[2] = ans[1];
            ans[1] = val;
        }
        else if (val != ans[0] && val != ans[1] && val > ans[2])
        {
            ans[2] = val;
        }
    }
}