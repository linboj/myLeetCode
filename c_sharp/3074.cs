public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        int total = 0;
        foreach (var a in apple)
        {
            total += a;
        }

        Array.Sort(capacity, (a, b) => b.CompareTo(a));

        int ans = 0;
        while (total > 0)
        {
            total -= capacity[ans++];
        }
        return ans;
    }
}