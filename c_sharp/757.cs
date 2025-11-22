public class Solution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => a[1] == b[1] ? b[0].CompareTo(a[0]) : a[1].CompareTo(b[1]));

        int ans = 0;
        int x = -1, y = -1;

        foreach (int[] interval in intervals)
        {
            int left = interval[0], right = interval[1];

            if (left > y)
            {
                x = right - 1;
                y = right;
                ans += 2;
            }
            else if (left > x)
            {
                x = y;
                y = right;
                ans++;
            }
        }
        return ans;
    }
}