public class Solution
{
    public int MaxDifference(string s)
    {
        int[] counts = new int[26];
        foreach (var ch in s)
        {
            counts[ch - 'a']++;
        }

        int oddMax = int.MinValue, evenMin = int.MaxValue;
        foreach (var count in counts)
        {
            if (count == 0) continue;
            if (count % 2 == 1)
                oddMax = Math.Max(oddMax, count);
            else
                evenMin = Math.Min(evenMin, count);
        }

        return oddMax - evenMin;
    }
}