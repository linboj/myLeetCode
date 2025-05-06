public class Solution
{
    public const int MOD = 1000000007;
    public int NumTilings(int n)
    {
        if (n <= 2) return n;
        int[] result = new int[n + 1];

        result[0] = 1;
        result[1] = 1;
        result[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            result[i] = ((2 * result[i - 1] % MOD) + (result[i - 3] % MOD)) % MOD;
        }

        return result[n];
    }
}