public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        int n = s.Length;
        HashSet<string> shown = new();

        for (int i = 0; i <= n - k; i++)
        {
            var code = s.Substring(i, k);
            shown.Add(code);
        }

        return shown.Count == (1 << k);
    }
}

public class Solution2
{
    public bool HasAllCodes(string s, int k)
    {
        int target = 1 << k;
        bool[] seen = new bool[target];
        int mask = target - 1;
        int hash = 0;

        for (int i = 0; i < s.Length; i++)
        {
            hash = ((hash << 1) & mask) | (s[i] & 1);
            if (i >= k - 1 && !seen[hash])
            {
                seen[hash] = true;
                target--;
                if (target == 0) return true;
            }
        }
        return false;
    }
}