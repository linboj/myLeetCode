public class Solution
{
    public int MinimumDistance(string word)
    {
        int n = word.Length;
        int[][] dp = new int[n][];

        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[26];
            Array.Fill(dp[i], int.MaxValue / 2);
        }

        Array.Fill(dp[0], 0);

        for (int i = 1; i < n; i++)
        {
            int prev = word[i - 1] - 'A';
            int cur = word[i] - 'A';
            int dist = GetDistance(prev, cur);

            for (int j = 0; j < 26; j++)
            {
                dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j] + dist);
                if (prev == j)
                {
                    for (int k = 0; k < 26; k++)
                    {
                        int dist2 = GetDistance(k, cur);
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][k] + dist2);
                    }
                }
            }
        }

        int ans = int.MaxValue / 2;
        foreach (var v in dp[n - 1])
        {
            ans = Math.Min(ans, v);
        }

        return ans;
    }

    private int GetDistance(int a, int b)
    {
        int x1 = a / 6;
        int y1 = a % 6;
        int x2 = b / 6;
        int y2 = b % 6;

        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

    }
}