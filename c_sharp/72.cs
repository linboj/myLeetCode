public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int n1 = word1.Length, n2 = word2.Length;
        int[] prev = new int[n2 + 1];
        for (int i = 0; i <= n2; i++)
        {
            prev[i] = i;
        }
        for (int i = 0; i < n1; i++)
        {
            int[] current = new int[n2 + 1];
            current[0] = i + 1;
            for (int j = 0; j < n2; j++)
            {
                if (word1[i] == word2[j])
                {
                    current[j+1] = Math.Min(Math.Min(current[j] + 1, prev[j+1] + 1), prev[j]);
                }
                else
                {
                    current[j+1] = Math.Min(Math.Min(current[j], prev[j+1]), prev[j]) + 1;
                }
            }
            prev = current;
        }
        return prev[n2];
    }
}