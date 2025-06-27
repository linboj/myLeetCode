public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int n = s.Length;
        int total = 0;
        int count = 0;
        int bits = (int)Math.Log2(k) + 1;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == '1')
            {
                int pos = n - 1 - i;
                if (pos < bits && total + (1 << pos) <= k)
                {
                    total += 1 << pos;
                    count++;
                }
            }
            else
            {
                count++;
            }
        }
        return count;
    }
}