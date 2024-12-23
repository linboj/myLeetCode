public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;
        int[] charCounts = new int[26];

        foreach (var ch in s)
        {
            charCounts[ch-'a']++;
        }

        foreach (var ch in t)
        {
            int idx = ch - 'a';
            if (charCounts[idx] == 0) return false;
            charCounts[idx]--;
        }
        return true;
    }
}