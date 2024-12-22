using System.Text;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        // Sliding window
        /*
        Dictionary<char, int> map = new();
        int left = 0, maxLen = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            if (map.ContainsKey(c))
            {
                left = Math.Max(left, map[c] + 1) ;
            }
            map[c] = right;
            maxLen = Math.Max(maxLen, right - left + 1);
        }
        return maxLen;
        */

        // use list
        List<char> letters = new();
        int maxLen = 0;
        foreach (var ch in s)
        {
            if (!letters.Contains(ch)){
                letters.Add(ch);
            }
            else
            {
                maxLen = Math.Max(maxLen, letters.Count);
                int cIdx = letters.IndexOf(ch);
                letters.RemoveRange(0, cIdx+1);
                letters.Add(ch);
            }
        }
        return Math.Max(maxLen, letters.Count);
    }
}