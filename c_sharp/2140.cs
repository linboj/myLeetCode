public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        if (n == 1) return questions[0][0];
        long[] dp = new long[n + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            int next = Math.Min(n, questions[i][1] + i + 1);
            dp[i] = Math.Max(dp[next] + questions[i][0], dp[i + 1]);
        }

        return dp[0];
    }
}