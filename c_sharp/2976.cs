public class Solution
{
    public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
    {
        long[][] minCosts = new long[26][];

        for (int i = 0; i < 26; i++)
        {
            minCosts[i] = new long[26];
            Array.Fill(minCosts[i], int.MaxValue);
        }

        for (int i = 0; i < original.Length; i++)
        {
            int startChar = original[i] - 'a';
            int endChar = changed[i] - 'a';
            minCosts[startChar][endChar] = Math.Min(minCosts[startChar][endChar], cost[i]);
        }

        for (int k = 0; k < 26; k++)
        {
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    minCosts[i][j] = Math.Min(minCosts[i][j], minCosts[i][k] + minCosts[k][j]);
                }
            }
        }

        long totalCost = 0;
        for (int i = 0; i < source.Length; i++)
        {
            int startChar = source[i] - 'a';
            int endChar = target[i] - 'a';

            if (startChar == endChar) continue;

            long minCost = minCosts[startChar][endChar];
            if (minCost >= int.MaxValue) return -1;
            totalCost += minCost;
        }

        return totalCost;
    }
}