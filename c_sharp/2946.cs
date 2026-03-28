public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        int n = mat.Length, m = mat[0].Length;
        k %= m;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if (mat[r][c] != mat[r][(c + k) % m])
                    return false;
            }
        }
        return true;
    }
}