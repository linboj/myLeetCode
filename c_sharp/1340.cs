public class Solution
{
    private int[] dp;
    public int MaxJumps(int[] arr, int d)
    {
        int n = arr.Length;
        dp = new int[n];
        Array.Fill(dp, -1);

        for (int i = 0; i < n; i++)
        {
            Dfs(arr, i, d);
        }

        int ans = 0;
        foreach (var v in dp)
        {
            ans = Math.Max(ans, v);
        }

        return ans;
    }

    private void Dfs(int[] arr, int idx, int d)
    {
        if (dp[idx] != -1) return;

        dp[idx] = 1;

        for (int i = idx - 1; i >= 0 && i >= idx - d && arr[i] < arr[idx]; i--)
        {
            Dfs(arr, i, d);
            dp[idx] = Math.Max(dp[idx], dp[i] + 1);
        }

        int n = arr.Length;

        for (int i = idx + 1; i < n && i <= idx + d && arr[i] < arr[idx]; i++)
        {
            Dfs(arr, i, d);
            dp[idx] = Math.Max(dp[idx], dp[i] + 1);
        }
    }
}