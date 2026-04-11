using System.Collections;

public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        Dictionary<int, List<int>> cnts = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!cnts.ContainsKey(nums[i]))
                cnts[nums[i]] = new();

            cnts[nums[i]].Add(i);
        }

        int ans = int.MaxValue;
        foreach (var (key, values) in cnts)
        {
            if (values.Count >= 3)
            {
                for (int i = values.Count - 1; i >= 2; i--)
                {
                    int cur = Math.Abs(values[i] - values[i - 1]) +
                                Math.Abs(values[i] - values[i - 2]) +
                                    Math.Abs(values[i - 2] - values[i - 1]);
                    ans = Math.Min(cur, ans);
                }
            }
        }
        return ans == int.MaxValue ? -1 : ans;
    }
}

public class Solution2
{
    public int MinimumDistance(int[] nums)
    {
        Dictionary<int, int> firsts = new();
        Dictionary<int, int> seconds = new();

        int ans = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (firsts.ContainsKey(num) && seconds.ContainsKey(num))
            {
                int cur = i - firsts[num] + i - firsts[num];
                ans = Math.Min(cur, ans);
                firsts[num] = seconds[num];
                seconds[num] = i;
            }
            else if (firsts.ContainsKey(num))
            {
                seconds[num] = i;
            }
            else
            {
                firsts[num] = i;
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}