public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int n = mat.Length, m = mat[0].Length;
        int[][] prefixSum = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            prefixSum[i] = new int[m + 1];
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                prefixSum[i][j] = prefixSum[i - 1][j]
                    + prefixSum[i][j - 1]
                    + mat[i - 1][j - 1]
                    - prefixSum[i - 1][j - 1];
            }
        }

        int l = Math.Min(n, m);
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                for (int c = ans + 1; c <= l; c++)
                {
                    if (i + c - 1 > n || j + c - 1 > m) break;
                    int sum = prefixSum[i + c - 1][j + c - 1]
                        - prefixSum[i - 1][j + c - 1]
                        - prefixSum[i + c - 1][j - 1]
                        + prefixSum[i - 1][j - 1];
                    if (sum <= threshold)
                        ans++;
                    else
                        break;
                }
            }
        }
        return ans;
    }
}