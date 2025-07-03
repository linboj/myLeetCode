public class Solution
{
    private int MOD = 1_000_000_007;
    public int PossibleStringCount(string word, int k)
    {
        int n = word.Length;
        int cnt = 1;
        List<int> freq = new();
        for (int i = 1; i < n; i++)
        {
            if (word[i - 1] == word[i])
            {
                cnt++;
            }
            else
            {
                freq.Add(cnt);
                cnt = 1;
            }
        }
        freq.Add(cnt);
        long ans = 1;
        foreach (var num in freq)
        {
            ans = ans * num % MOD;
        }

        if (freq.Count >= k)
        {
            return (int)ans;
        }

        int[] f = new int[k];
        int[] g = new int[k];
        f[0] = 1;
        Array.Fill(g, 1);

        for (int i = 0; i < freq.Count; i++)
        {
            int[] f_new = new int[k];
            for (int j = 1; j < k; j++)
            {
                f_new[j] = g[j - 1];
                if (j - freq[i] - 1 >= 0)
                {
                    f_new[j] = (f_new[j] - g[j - freq[i] - 1] + MOD) % MOD;
                }
            }
            int[] g_new = new int[k];
            g_new[0] = f_new[0];
            for (int j = 1; j < k; j++)
            {
                g_new[j] = (g_new[j - 1] + f_new[j]) % MOD;
            }
            f = f_new;
            g = g_new;
        }
        return (int)((ans - g[k - 1] + MOD) % MOD);
    }
}