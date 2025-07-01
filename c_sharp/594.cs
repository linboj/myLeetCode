using System.Collections;

public class Solution
{
    public int FindLHS(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> counts = new();
        foreach (var num in nums)
        {
            if (!counts.ContainsKey(num))
                counts[num] = 0;

            counts[num]++;
        }

        int ans = 0;

        foreach (var kv in counts)
        {
            if (counts.TryGetValue(kv.Key + 1, out int next))
                ans = Math.Max(ans, kv.Value + next);
        }
        return ans;
    }
}