public class Solution
{
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups)
    {
        int n = words.Length;
        int[] dp = new int[n];
        int[] prev = new int[n];
        Array.Fill(dp, 1);
        Array.Fill(prev, -1);
        int maxIdx = 0;

        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (Check(words[i], words[j]) && groups[i] != groups[j] && dp[j] + 1 >= dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }
            if (dp[i] > dp[maxIdx])
                maxIdx = i;
        }

        List<string> result = new();
        for (int i = maxIdx; i >= 0; i = prev[i])
        {
            result.Add(words[i]);
        }

        result.Reverse();
        return result;
    }

    private bool Check(string x, string y)
    {
        if (x.Length != y.Length)
            return false;

        int diff = 0;
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i] != y[i])
            {
                if (++diff > 1)
                    return false;
            }
        }

        return diff == 1;
    }
}