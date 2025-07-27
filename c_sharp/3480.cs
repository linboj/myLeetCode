public class Solution
{
    public long MaxSubarrays(int n, int[][] conflictingPairs)
    {
        int[] minB1 = new int[n + 1];
        int[] minB2 = new int[n + 1];
        Array.Fill(minB1, int.MaxValue);
        Array.Fill(minB2, int.MaxValue);

        foreach (var conflictingPair in conflictingPairs)
        {
            int a = Math.Min(conflictingPair[0], conflictingPair[1]);
            int b = Math.Max(conflictingPair[0], conflictingPair[1]);

            if (minB1[a] > b)
            {
                minB2[a] = minB1[a];
                minB1[a] = b;
            }
            else if (minB2[a] > b)
                minB2[a] = b;
        }

        long ans = 0;
        int idxB1 = n;
        int b2 = int.MaxValue;
        long[] delCount = new long[n + 1];

        for (int i = n; i >= 1; i--)
        {
            if (minB1[idxB1] > minB1[i])
            {
                b2 = Math.Min(b2, minB1[idxB1]);
                idxB1 = i;
            }
            else
                b2 = Math.Min(b2, minB1[i]);

            ans += Math.Min(minB1[idxB1], n + 1) - i;
            delCount[idxB1] += Math.Min(Math.Min(b2, minB2[idxB1]), n + 1) - Math.Min(minB1[idxB1], n + 1);
        }
        long max = 0;
        foreach (long val in delCount)
            max = Math.Max(max, val);
        return ans + max;
    }
}