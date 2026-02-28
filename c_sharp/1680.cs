public class Solution
{
    private const int MOD = 1_000_000_007;
    public int ConcatenatedBinary(int n)
    {
        long ans = 0;
        int bitLen = 0, threshold = 1;

        for (int i = 1; i <= n; i++)
        {
            if (i == threshold)
            {
                bitLen++;
                threshold <<= 1;
            }

            ans = ((ans << bitLen) + i) % MOD;
        }

        return (int)ans;
    }
}