public class Solution
{
    private int[][] dirs = [[0, 1], [1, 0], [0, -1], [-1, 0],];
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {

        int n = heights.Length, m = heights[0].Length;

        bool[][] rP = new bool[n][];
        bool[][] rA = new bool[n][];

        for (int i = 0; i < n; i++)
        {
            rP[i] = new bool[m];
            rA[i] = new bool[m];
        }

        Queue<(int, int)> qP = new();
        Queue<(int, int)> qA = new();

        for (int i = 0; i < n; i++)
        {
            rP[i][0] = true;
            qP.Enqueue((i, 0));
            rA[i][m - 1] = true;
            qA.Enqueue((i, m - 1));
        }

        for (int i = 1; i < m; i++)
        {
            rP[0][i] = true;
            qP.Enqueue((0, i));
            rA[n - 1][i] = true;
            qA.Enqueue((n - 1, i));
        }

        BFS(heights, rP, qP);
        BFS(heights, rA, qA);

        List<IList<int>> ans = new();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (rA[i][j] && rP[i][j])
                {
                    ans.Add([i, j]);
                }
            }
        }
        return ans;
    }

    private void BFS(int[][] heights, bool[][] reactable, Queue<(int, int)> queue)
    {
        int n = heights.Length, m = heights[0].Length;

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            foreach (var dir in dirs)
            {
                int nR = r + dir[0];
                int nC = c + dir[1];

                if (nR < 0 || nR >= n || nC < 0 || nC >= m)
                    continue;

                if (!reactable[nR][nC] && heights[nR][nC] >= heights[r][c])
                {
                    reactable[nR][nC] = true;
                    queue.Enqueue((nR, nC));
                }
            }
        }
    }
}