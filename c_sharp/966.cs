using System.Text;

public class Solution
{
    private HashSet<string> fullMatches;
    private Dictionary<string, int> lowCaps;
    private Dictionary<string, int> devowels;
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        fullMatches = new();
        lowCaps = new();
        devowels = new();

        for (int i = 0; i < wordlist.Length; i++)
        {
            string word = wordlist[i];
            fullMatches.Add(word);
            string wordLow = word.ToLowerInvariant();
            lowCaps.TryAdd(wordLow, i);
            devowels.TryAdd(DeVowel(wordLow), i);
        }

        int n = queries.Length;
        string[] ans = new string[n];
        for (int i = 0; i < n; i++)
        {
            string word = queries[i];
            if (fullMatches.Contains(word))
            {
                ans[i] = word;
                continue;
            }
            int idx;
            string wordLow = word.ToLowerInvariant();
            if (lowCaps.TryGetValue(wordLow, out idx))
            {
                ans[i] = wordlist[idx];
                continue;
            }
            string wordLowDevowel = DeVowel(wordLow);
            if (devowels.TryGetValue(wordLowDevowel, out idx))
            {
                ans[i] = wordlist[idx];
                continue;
            }
            ans[i] = "";
        }
        return ans;
    }

    private string DeVowel(string word)
    {
        StringBuilder sb = new();
        foreach (var c in word)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                sb.Append('*');
            else
                sb.Append(c);
        }
        return sb.ToString();
    }
}