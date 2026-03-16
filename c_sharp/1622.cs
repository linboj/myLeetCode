public class Fancy
{
    private const int MOD = 1_000_000_007;
    private List<int> v;
    private int a;
    private int b;

    public Fancy()
    {
        v = new();
        a = 1;
        b = 0;
    }

    private int QuickMul(int x, int y)
    {
        long res = 1;
        long cur = x;
        while (y != 0)
        {
            if ((y & 1) != 0)
            {
                res = res * cur % MOD;
            }

            cur = cur * cur % MOD;
            y /= 2;
        }
        return (int)res;
    }

    private int Inv(int x)
    {
        return QuickMul(x, MOD - 2);
    }

    public void Append(int val)
    {
        long adjustedVal = (long)(val - b + MOD) % MOD * Inv(a) % MOD;
        v.Add((int)adjustedVal);
    }

    public void AddAll(int inc)
    {
        b = (b + inc) % MOD;
    }

    public void MultAll(int m)
    {
        a = (int)((long)a * m % MOD);
        b = (int)((long)b * m % MOD);
    }

    public int GetIndex(int idx)
    {
        if (idx >= v.Count)
            return -1;

        int ans = (int)(((long)a * v[idx] % MOD + b) % MOD);
        return ans;
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.Append(val);
 * obj.AddAll(inc);
 * obj.MultAll(m);
 * int param_4 = obj.GetIndex(idx);
 */