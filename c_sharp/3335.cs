public class Solution
{
    private const int MOD = 1000000007;
    public int LengthAfterTransformations(string s, int t)
    {
        int[] counts = new int[26];
        foreach (var ch in s)
        {
            counts[ch - 'a']++;
        }

        for (int time = 0; time < t; time++)
        {
            int[] next = new int[26];
            next[1] = (counts[0] + counts[25]) % MOD;
            next[0] = counts[25];
            for (int i = 2; i < 26; i++)
            {
                next[i] = counts[i - 1];
            }
            counts = next;
        }

        int ans = 0;
        foreach (var num in counts)
        {
            ans = (ans + num) % MOD;
        }

        return ans;
    }
}