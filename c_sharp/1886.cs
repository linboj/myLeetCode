public class Solution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        int n = mat.Length;
        int cnt0 = 0, cnt90 = 0, cnt180 = 0, cnt270 = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                cnt0 += mat[r][c] ^ target[r][c];
                cnt90 += mat[c][n - r - 1] ^ target[r][c];
                cnt180 += mat[n - r - 1][n - c - 1] ^ target[r][c];
                cnt270 += mat[n - c - 1][r] ^ target[r][c];
            }
        }

        return cnt0 == 0 || cnt90 == 0 || cnt180 == 0 || cnt270 == 0;
    }
}