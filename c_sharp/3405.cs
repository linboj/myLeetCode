public class Solution
{
    const int MOD = 1_000_000_007;
    const int MAXVALUE = 100000;
    static long[] fact = new long[MAXVALUE];
    static long[] invFact = new long[MAXVALUE];

    long qpow(long x, int n)
    {
        long res = 1;
        while (n > 0)
        {
            if ((n & 1) == 1)
                res = res * x % MOD;

            x = x * x % MOD;
            n >>= 1;
        }
        return res;
    }

    void init()
    {
        if (fact[0] != 0)
            return;

        fact[0] = 1;
        for (int i = 1; i < MAXVALUE; i++)
        {
            fact[i] = fact[i - 1] * i % MOD;
        }

        invFact[MAXVALUE - 1] = qpow(fact[MAXVALUE - 1], MOD - 2);
        for (int i = MAXVALUE - 1; i > 0; i--)
        {
            invFact[i - 1] = invFact[i] * i % MOD;
        }
    }

    long comb(int n, int m)
    {
        return fact[n] * invFact[m] % MOD * invFact[n - m] % MOD;
    }

    public int CountGoodArrays(int n, int m, int k)
    {
        init();
        return (int)(comb(n - 1, k) * m % MOD * qpow(m - 1, n - k - 1) % MOD);

    }
}