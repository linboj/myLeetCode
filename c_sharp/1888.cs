public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        int[,] pre = new int[n, 2];

        for (int i = 0; i < n; i++)
        {
            pre[i, 0] = (i == 0 ? 0 : pre[i - 1, 1]) + (s[i] - '0');
            pre[i, 1] = (i == 0 ? 0 : pre[i - 1, 0]) + ('1' - s[i]);
        }

        int ans = Math.Min(pre[n - 1, 0], pre[n - 1, 1]);
        if (n % 2 == 1)
        {
            int[,] suf = new int[n, 2];

            for (int i = n - 1; i >= 0; i--)
            {
                suf[i, 0] = (i == n - 1 ? 0 : suf[i + 1, 1]) + (s[i] - '0');
                suf[i, 1] = (i == n - 1 ? 0 : suf[i + 1, 0]) + ('1' - s[i]);
            }

            for (int i = 0; i < n - 1; i++)
            {
                ans = Math.Min(ans, pre[i, 0] + suf[i + 1, 0]);
                ans = Math.Min(ans, pre[i, 1] + suf[i + 1, 1]);
            }
        }

        return ans;
    }
}

public class Solution2
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        int ans = n;
        int[] ops = [0, 0];

        for (int i = 0; i < n; i++)
        {
            ops[(s[i] ^ i) & 1]++;
        }

        for (int i = 0; i < n; i++)
        {
            ops[(s[i] ^ i) & 1]--;
            ops[(s[i] ^ (n + i)) & 1]++;
            ans = Math.Min(ans, Math.Min(ops[0], ops[1]));
        }

        return ans;
    }
}