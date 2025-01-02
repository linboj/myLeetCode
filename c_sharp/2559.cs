public class Solution
{
    public int[] VowelStrings(string[] words, int[][] queries)
    {
        HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u' };

        int[] prefixSum = new int[words.Length + 1];
        for (int i = 0; i < words.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i];
            if (vowels.Contains(words[i][0]) && vowels.Contains(words[i][^1]))
            {
                prefixSum[i + 1] += 1;
            }
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            ans[i] = prefixSum[queries[i][1] + 1] - prefixSum[queries[i][0]];
        }

        return ans;
    }
}