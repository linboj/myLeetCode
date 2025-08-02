
public class Solution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        int m = int.MaxValue;
        Dictionary<int, int> freq = new();

        foreach (var num in basket1)
        {
            if (!freq.ContainsKey(num))
                freq[num] = 0;
            freq[num]++;
            m = Math.Min(m, num);
        }

        foreach (var num in basket2)
        {
            if (!freq.ContainsKey(num))
                freq[num] = 0;
            freq[num]--;
            m = Math.Min(m, num);
        }

        List<int> diff = new();

        foreach (var (key, val) in freq)
        {
            if (val % 2 != 0)
                return -1;

            for (int i = 0; i < Math.Abs(val) / 2; i++)
                diff.Add(key);
        }

        diff.Sort();
        long ans = 0;

        for (int i = 0; i < diff.Count / 2; i++)
        {
            ans += Math.Min(diff[i], m * 2);
        }
        return ans;
    }
}