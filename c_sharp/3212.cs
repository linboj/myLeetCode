public class Solution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        int[] cols = new int[m];
        int[] cnts = new int[m];

        for (int r = 0; r < n; r++)
        {
            int row = 0;
            int cnt = 0;
            for (int c = 0; c < m; c++)
            {
                if (grid[r][c] == 'X')
                {
                    row += 1;
                    cnt |= 1;
                }
                else if (grid[r][c] == 'Y')
                {
                    row -= 1;
                    cnt |= 2;
                }

                cols[c] += row;
                cnts[c] |= cnt;

                if (cols[c] == 0 && cnts[c] == 3)
                    ans++;
            }
        }
        return ans;
    }
}