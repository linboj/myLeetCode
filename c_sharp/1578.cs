public class Solution
{
    public int MinCost(string colors, int[] neededTime)
    {
        int n = neededTime.Length;
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            int maxVal = 0;
            while (i < n && colors[i] == colors[i - 1])
            {
                ans += neededTime[i - 1];
                maxVal = Math.Max(maxVal, neededTime[i - 1]);
                i++;
            }
            ans += neededTime[i - 1];
            maxVal = Math.Max(maxVal, neededTime[i - 1]);
            ans -= maxVal;
        }
        return ans;
    }
}

public class Solution2
{
    public int MinCost(string colors, int[] neededTime)
    {
        int n = neededTime.Length;
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            if (colors[i] == colors[i - 1])
            {
                ans += Math.Min(neededTime[i], neededTime[i - 1]);
                neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
            }
        }
        return ans;
    }
}