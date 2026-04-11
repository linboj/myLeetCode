public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int ans = int.MaxValue;
        Dictionary<int, int> firsts = new(), seconds = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            if (firsts.ContainsKey(num) && seconds.ContainsKey(num))
            {
                ans = Math.Min(ans, (i - firsts[num]) * 2);
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

public class Solution2
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        int[] nexts = new int[n];
        Array.Fill(nexts, -1);
        Dictionary<int, int> occur = new();

        for (int i = n - 1; i >= 0; i--)
        {
            int num = nums[i];
            if (occur.ContainsKey(num))
            {
                nexts[i] = occur[num];
            }

            occur[num] = i;
        }

        int ans = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            int second = nexts[i];
            if (second != -1)
            {
                int third = nexts[second];
                if (third != -1)
                {
                    ans = Math.Min(ans, (third - i) * 2);
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}