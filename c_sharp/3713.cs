public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            int[] freq = new int[26];
            int dist = 0;
            int maxFreq = 0;
            for (int j = i; j < n; j++)
            {
                int idx = s[j] - 'a';
                freq[idx]++;
                maxFreq = Math.Max(maxFreq, freq[idx]);
                if (freq[idx] == 1)
                    dist++;

                int l = j - i + 1;
                if (l == maxFreq * dist)
                    ans = Math.Max(ans, l);
            }
        }
        return ans;
    }
}