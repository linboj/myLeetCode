public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;
        int ans = 0;

        int i = 0;

        while (colors[i] == colors[n - 1])
            i++;

        ans = Math.Max(ans, n - 1 - i);

        i = n - 1;

        while (colors[0] == colors[i])
            i--;

        ans = Math.Max(ans, i);

        return ans;
    }
}