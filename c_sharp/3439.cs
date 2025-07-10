public class Solution
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            sum[i + 1] = sum[i] + endTime[i] - startTime[i];
        }
        int ans = 0;
        for (int i = k - 1; i < n; i++)
        {
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i == k - 1 ? 0 : endTime[i - k];
            ans = Math.Max(ans, right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        return ans;
    }
}

public class Solution2
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        int n = startTime.Length;
        int sum = 0, ans = 0;
        for (int i = 0; i < n; i++)
        {
            sum += endTime[i] - startTime[i];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i <= k - 1 ? 0 : endTime[i - k];
            ans = Math.Max(ans, right - left - sum);
            if (i >= k - 1)
            {
                sum -= endTime[i - k + 1] - startTime[i - k + 1];
            }
        }
        return ans;
    }
}