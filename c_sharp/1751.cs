public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        int n = events.Length;
        int[][] dp = new int[k + 1][];
        for (int i = 0; i <= k; i++)
        {
            dp[i] = new int[n + 1];
        }
        Array.Sort(events, (a, b) => a[0] - b[0]);

        for (int currIdx = n - 1; currIdx >= 0; currIdx--)
        {
            int nextIdx = FindNextIdx(events, events[currIdx][1]);
            for (int count = 1; count <= k; count++)
            {
                dp[count][currIdx] = Math.Max(dp[count][currIdx + 1], events[currIdx][2] + dp[count - 1][nextIdx]);
            }
        }
        return dp[k][0];

    }

    private int FindNextIdx(int[][] events, int target)
    {
        int left = 0, right = events.Length;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (events[mid][0] <= target)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}