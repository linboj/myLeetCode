public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        int[] rCnt = new int[n], cCnt = new int[m];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                rCnt[r] += mat[r][c];
                cCnt[c] += mat[r][c];
            }
        }

        int ans = 0;
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if (mat[r][c] == 1 && rCnt[r] == 1 && cCnt[c] == 1)
                    ans++;
            }
        }

        return ans;
    }
}