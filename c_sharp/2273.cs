public class Solution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        List<string> ans = new();
        ans.Add(words[0]);
        string prev = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            string current = words[i];
            if (!IsSame(prev, current))
            {
                ans.Add(current);
                prev = current;
            }
        }
        return ans;
    }

    private bool IsSame(string w1, string w2)
    {
        if (w1 == w2) return true;
        if (w1.Length != w2.Length) return false;

        int[] count = new int[26];
        foreach (var c in w1)
            count[c - 'a']++;

        foreach (var c in w2)
            if (--count[c - 'a'] < 0) return false;

        return true;
    }
}