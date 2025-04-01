public class Solution
{
    public long PutMarbles(int[] weights, int k)
    {
        int n = weights.Length;
        int[] pairSums = new int[n - 1];

        for (int i = 0; i < n - 1; ++i)
        {
            pairSums[i] = weights[i] + weights[i + 1];
        }

        Array.Sort(pairSums);

        long result = 0;
        for (int i = 0; i < k - 1; i++)
        {
            result += pairSums[n - i - 2] - pairSums[i];
        }
        return result;
    }
}