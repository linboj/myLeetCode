public class Solution
{
    public int MinimumCost(int[] cost)
    {
        int ans = 0, cnt = 0;

        Array.Sort(cost, (a, b) => b.CompareTo(a));

        foreach (var c in cost)
        {
            cnt++;
            if (cnt == 3)
            {
                cnt = 0;
                continue;
            }

            ans += c;
        }

        return ans;
    }
}