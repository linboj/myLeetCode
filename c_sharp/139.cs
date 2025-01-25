public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool[] dp = new bool[s.Length + 1];
        var wordSet = new HashSet<string>(wordDict);
        dp[0] = true;
        int maxLen = 0;
        foreach (var word in wordDict)
        {
            maxLen = Math.Max(maxLen, word.Length);
        }

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = i - 1; j >= Math.Max(i - maxLen - 1, 0); j--)
            {
                if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[s.Length];
    }
}