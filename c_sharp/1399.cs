public class Solution
{
    public int CountLargestGroup(int n)
    {
        int max = 0;
        Dictionary<int, int> counts = new();

        for (int i = 1; i <= n; i++)
        {
            int current = i;
            int sum = 0;
            while (current > 0)
            {
                sum += current % 10;
                current /= 10;
            }
            if (!counts.ContainsKey(sum))
                counts[sum] = 0;
            counts[sum]++;
            max = Math.Max(max, counts[sum]);
        }

        int ans = 0;
        foreach (var (k, v) in counts)
        {
            if (v == max)
                ans++;
        }
        return ans;
    }
}