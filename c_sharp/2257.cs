public class Solution
{
    private readonly int[][] DIRS = [[1, 0], [-1, 0], [0, 1], [0, -1]];
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        int[][] guarded = new int[m][];
        int ans = m * n - guards.Length - walls.Length;
        for (int i = 0; i < m; i++)
        {
            guarded[i] = new int[n];
        }

        foreach (var wall in walls)
        {
            guarded[wall[0]][wall[1]] = 2;
        }

        foreach (var guard in guards)
        {
            guarded[guard[0]][guard[1]] = 2;
        }

        foreach (var guard in guards)
        {
            int r = guard[0], c = guard[1];
            foreach (var dir in DIRS)
            {
                int nextR = r + dir[0], nextC = c + dir[1];
                while (nextR >= 0 && nextR < m && nextC >= 0 && nextC < n && guarded[nextR][nextC] < 2)
                {
                    if (guarded[nextR][nextC] == 0)
                    {
                        guarded[nextR][nextC] = 1;
                        ans--;
                    }
                    nextR += dir[0];
                    nextC += dir[1];
                }
            }
        }
        return ans;
    }
}