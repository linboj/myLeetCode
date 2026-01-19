public class Solution
{
    public int LargestMagicSquare(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int l = Math.Min(n, m);

        int[][] rowSum = new int[n][];
        int[][] colSum = new int[m][];

        for (int r = 0; r < n; r++)
        {
            rowSum[r] = new int[m + 1];
            for (int c = 0; c < m; c++)
            {
                rowSum[r][c + 1] = rowSum[r][c] + grid[r][c];
            }
        }

        for (int c = 0; c < m; c++)
        {
            colSum[c] = new int[n + 1];
            for (int r = 0; r < n; r++)
            {
                colSum[c][r + 1] = colSum[c][r] + grid[r][c];
            }
        }

        for (int edge = l; edge >= 2; edge--)
        {
            for (int r = 0; r <= n - edge; r++)
            {
                for (int c = 0; c <= m - edge; c++)
                {
                    int target = rowSum[r][c + edge] - rowSum[r][c];
                    bool valid = true;

                    for (int i = r + 1; i < r + edge; i++)
                    {
                        int cur = rowSum[i][c + edge] - rowSum[i][c];
                        if (cur != target)
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (!valid) continue;

                    for (int i = c; i < c + edge; i++)
                    {
                        int cur = colSum[i][r + edge] - colSum[i][r];
                        if (cur != target)
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (!valid) continue;

                    int d1 = 0;
                    int d2 = 0;
                    for (int i = 0; i < edge; i++)
                    {
                        d1 += grid[r + i][c + i];
                        d2 += grid[r + i][c + edge - 1 - i];
                    }

                    if (d1 == target && d2 == target)
                        return edge;
                }
            }
        }

        return 1;
    }
}