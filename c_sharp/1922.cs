public class Solution
{
    long mod = 1000000007;
    public int CountGoodNumbers(long n)
    {
        int nPrime = 4, nEven = 5;
        long nEvenIndics = (n + 1) / 2, nOddIndics = n / 2;

        return (int)(FastMultiply(nEven, nEvenIndics) * FastMultiply(nPrime, nOddIndics) % mod);
    }

    private long FastMultiply(int x, long y)
    {
        long res = 1;
        long mul = x;
        while (y > 0)
        {
            if ((y & 1) == 1)
            {
                res = res * mul % mod;
            }
            mul = mul * mul % mod;
            y >>= 1;
        }
        return res;
    }
}