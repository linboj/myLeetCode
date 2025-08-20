public class Solution
{
    public int CountSquares(int[][] matrix)
    {
        int nRow = matrix.Length, nCol = matrix[0].Length;
        int ans = 0, prev = 0;
        int[] dp = new int[nCol + 1];

        for (int r = 1; r <= nRow; r++)
        {
            for (int c = 1; c <= nCol; c++)
            {
                if (matrix[r - 1][c - 1] == 1)
                {
                    int tmp = dp[c];
                    dp[c] = Math.Min(prev, Math.Min(dp[c - 1], dp[c])) + 1;
                    prev = tmp;
                    ans += dp[c];
                }
                else
                {
                    dp[c] = 0;
                }
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int CountSquares(int[][] matrix)
    {
        int nRow = matrix.Length, nCol = matrix[0].Length;
        int ans = 0;

        for (int r = 0; r < nRow; r++)
        {
            for (int c = 0; c < nCol; c++)
            {
                if (matrix[r][c] == 1)
                {
                    if (r != 0 && c != 0)
                        matrix[r][c] = Math.Min(matrix[r - 1][c - 1], Math.Min(matrix[r - 1][c], matrix[r][c - 1])) + 1;
                    ans += matrix[r][c];
                }
            }
        }
        return ans;
    }
}