public class Solution
{
    public int NumWays(string[] words, string target)
    {
        // Optimized Bottom-up Dynamic Programming
        int nWord = words[0].Length;
        int nTarget = target.Length;
        int[,] charFreq = new int[nWord, 26];
        const long mod = 1000000007;

        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                charFreq[i, word[i] - 'a'] += 1;
            }
        }

        long[] prevCount = new long[nTarget + 1];
        long[] currCount = new long[nTarget + 1];

        prevCount[0] = 1;

        for (int currWord = 1; currWord <= nWord; ++currWord)
        {
            currCount = (long[])prevCount.Clone();
            for (int currTarget = 1; currTarget <= nTarget; ++currTarget)
            {
                int curPos = target[currTarget - 1] - 'a';
                currCount[currTarget] += charFreq[currWord - 1, curPos] * prevCount[currTarget - 1] % mod;

                currCount[currTarget] %= mod;
            }
            prevCount = (long[])currCount.Clone();
        }

        return (int)prevCount[nTarget];


    }
}

public class Solution2
{
    public int NumWays(string[] words, string target)
    {
        // Bottom-up Dynamic Programming
        int nWord = words[0].Length;
        int nTarget = target.Length;
        int[,] charFreq = new int[nWord, 26];
        const long mod = 1000000007;

        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                charFreq[i, word[i] - 'a'] += 1;
            }
        }

        long[,] dp = new long[nWord + 1, nTarget + 1];

        for (int i = 0; i <= nWord; i++)
        {
            dp[i, 0] = 1;
        }

        for (int currWord = 1; currWord <= nWord; ++currWord)
        {
            for (int currTarget = 1; currTarget <= nTarget; ++currTarget)
            {
                dp[currWord, currTarget] = dp[currWord - 1, currTarget];

                int curPos = target[currTarget - 1] - 'a';
                dp[currWord, currTarget] += charFreq[currWord - 1, curPos] * dp[currWord - 1, currTarget - 1] % mod;

                dp[currWord, currTarget] %= mod;
            }
        }

        return (int)dp[nWord, nTarget];


    }
}