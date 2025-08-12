public class Solution
{
    public const int MOD = 1000000007;
    public int[] ProductQueries(int n, int[][] queries)
    {
        List<int> bins = new();
        int power = 1;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                bins.Add(power);
            }
            n >>= 1;
            power <<= 1;
        }

        int m = bins.Count;
        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
        {
            long product = 1;
            result[i] = new int[m];
            for (int j = i; j < m; j++)
            {
                product = product * bins[j] % MOD;
                result[i][j] = (int)product;
            }
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int start = queries[i][0];
            int end = queries[i][1];
            ans[i] = result[start][end];
        }

        return ans;
    }
}