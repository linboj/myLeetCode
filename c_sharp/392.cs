public class Solution {
    public bool IsSubsequence(string s, string t) {
        int tIdx = 0;

        for (int sIdx = 0; sIdx < s.Length; sIdx++)
        {
            while (tIdx < t.Length && s[sIdx] != t[tIdx]) tIdx++;

            if (tIdx >= t.Length) return false;
            tIdx++;
        }

        return true;  
    }
}