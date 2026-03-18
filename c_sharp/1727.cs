public class Solution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length;
        List<(int h, int col)> prevHs = new();
        int ans = 0;

        for (int r = 0; r < n; r++)
        {
            List<(int h, int col)> hs = new();
            bool[] seen = new bool[m];

            foreach (var item in prevHs)
            {
                int h = item.h;
                int col = item.col;
                if (matrix[r][col] == 1)
                {
                    hs.Add((h + 1, col));
                    seen[col] = true;
                }
            }

            for (int c = 0; c < m; c++)
            {
                if (!seen[c] && matrix[r][c] == 1)
                {
                    hs.Add((1, c));
                }
            }

            for (int i = 0; i < hs.Count; i++)
            {
                ans = Math.Max(ans, hs[i].h * (i + 1));
            }

            prevHs = hs;
        }
        return ans;
    }
}