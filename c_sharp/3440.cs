public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int ans = 0;
        for (int i = 0, t1 = 0, t2 = 0; i < n; i++)
        {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (endTime[i] - startTime[i] <= t1)
                ans = Math.Max(ans, right - left);

            t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            ans = Math.Max(ans, right - left - (endTime[i] - startTime[i]));

            left = i == n - 1 ? 0 : endTime[n - i - 2];
            right = i == 0 ? eventTime : startTime[n - i];

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2)
                ans = Math.Max(ans, right - left);

            t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }
        return ans;
    }
}