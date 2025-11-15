public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        int[][] diff = new int[n + 1][];
        int[][] ans = new int[n][];

        for (int i = 0; i < n; i++)
        {
            diff[i] = new int[n + 1];
            ans[i] = new int[n];
        }
        diff[n] = new int[n + 1];

        foreach (var q in queries)
        {
            int r1 = q[0], c1 = q[1];
            int r2 = q[2], c2 = q[3];
            diff[r1][c1]++;
            diff[r2 + 1][c1]--;
            diff[r1][c2 + 1]--;
            diff[r2 + 1][c2 + 1]++;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int s1 = (i == 0) ? 0 : ans[i - 1][j];
                int s2 = (j == 0) ? 0 : ans[i][j - 1];
                int s3 = (i == 0 || j == 0) ? 0 : ans[i - 1][j - 1];
                ans[i][j] = diff[i][j] + s1 + s2 - s3;
            }
        }

        return ans;
    }
}