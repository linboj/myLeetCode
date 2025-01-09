public class Solution
{
    public int PrefixCount(string[] words, string pref)
    {
        int ans = 0;

        foreach (var word in words)
        {
            if (word.Length < pref.Length) continue;
            bool notPrefix = false;
            for (int i = 0; i < pref.Length; i++)
            {
                if (pref[i] != word[i])
                {
                    notPrefix = true;
                    break;
                }
            }
            if (!notPrefix) ans++;
        }
        return ans;
    }
}

public class Solution2
{
    public int PrefixCount(string[] words, string pref)
    {
        int ans = 0;

        foreach (var word in words)
        {
            if (word.Length >= pref.Length && pref == word.Substring(0, pref.Length))
            {
                ans++;
            }
        }
        return ans;
    }
}