public class Solution
{
    public int MaxOperations(string s)
    {
        int ones = 0;
        int ans = 0;
        int idx = 0;

        while (idx < s.Length)
        {
            if (s[idx] == '0')
            {
                while (idx + 1 < s.Length && s[idx + 1] == '0')
                    idx++;

                ans += ones;
            }
            else
            {
                ones++;
            }
            idx++;
        }
        return ans;
    }
}