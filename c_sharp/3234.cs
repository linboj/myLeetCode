public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int[] pre0 = new int[n + 1];
        pre0[0] = -1;
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || (i > 0 && s[i - 1] == '0'))
                pre0[i + 1] = i;
            else
                pre0[i + 1] = pre0[i];
        }

        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            int zeros = s[i - 1] == '0' ? 1 : 0;
            int j = i;
            while (j > 0 && zeros * zeros <= n)
            {
                int ones = i - pre0[j] - zeros;
                if (ones >= zeros * zeros)
                {
                    ans += Math.Min(j - pre0[j], ones - zeros * zeros + 1);
                }
                j = pre0[j];
                zeros++;
            }
        }
        return ans;
    }
}