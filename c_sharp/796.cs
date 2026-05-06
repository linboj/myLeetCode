public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length) return false;

        string dS = s + s;

        return KMPSearch(dS, goal);
    }

    private bool KMPSearch(string text, string pattern)
    {
        var lps = ComputeLPS(pattern);
        int tIdx = 0, pIdx = 0;
        int tLen = text.Length, pLen = pattern.Length;

        while (tIdx < tLen)
        {
            if (text[tIdx] == pattern[pIdx])
            {
                tIdx++;
                pIdx++;
                if (pIdx == pLen) return true;
            }
            else if (pIdx > 0)
            {
                pIdx = lps[pIdx - 1];
            }
            else
            {
                tIdx++;
            }
        }
        return false;
    }

    private int[] ComputeLPS(string pattern)
    {
        int n = pattern.Length;
        int[] lps = new int[n];
        int len = 0, idx = 1;

        while (idx < n)
        {
            if (pattern[idx] == pattern[len])
            {
                len++;
                lps[idx++] = len;
            }
            else if (len > 0)
            {
                len = lps[len - 1];
            }
            else
            {
                lps[idx++] = 0;
            }
        }

        return lps;
    }
}