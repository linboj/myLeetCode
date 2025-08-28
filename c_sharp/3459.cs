public class Solution
{
    private readonly int[][] DIRS = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
    private int[,,,] memo;
    private int[][] grid;
    private int n, m;
    public int LenOfVDiagonal(int[][] grid)
    {
        this.grid = grid;
        n = grid.Length;
        m = grid[0].Length;

        memo = new int[n, m, 4, 2];

        for (int r = 0; r < n; r++)
            for (int c = 0; c < m; c++)
                for (int d = 0; d < 4; d++)
                    for (int t = 0; t < 2; t++)
                        memo[r, c, d, t] = -1;

        int ans = 0;
        for (int r = 0; r < n; r++)
            for (int c = 0; c < m; c++)
            {
                if (grid[r][c] == 1)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        ans = Math.Max(ans, DFS(r, c, d, true, 2) + 1);
                    }
                }
            }

        return ans;
    }

    private int DFS(int r, int c, int direction, bool turn, int target)
    {
        int nR = r + DIRS[direction][0];
        int nC = c + DIRS[direction][1];

        if (nR < 0 || nC < 0 || nR >= n || nC >= m || grid[nR][nC] != target)
            return 0;

        int turnInt = turn ? 1 : 0;
        if (memo[nR, nC, direction, turnInt] != -1)
        {
            return memo[nR, nC, direction, turnInt];
        }

        int maxStep = DFS(nR, nC, direction, turn, 2 - target);
        if (turn)
        {
            maxStep = Math.Max(maxStep, DFS(nR, nC, (direction + 1) % 4, false, 2 - target));
        }
        memo[nR, nC, direction, turnInt] = maxStep + 1;
        return maxStep + 1;
    }
}