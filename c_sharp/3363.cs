public class Solution
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        int n = fruits.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
            ans += fruits[i][i];

        ans += dp(fruits);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                var temp = fruits[j][i];
                fruits[j][i] = fruits[i][j];
                fruits[i][j] = temp;
            }
        }
        ans += dp(fruits);
        return ans;
    }

    private int dp(int[][] fruits)
    {
        int n = fruits.Length;
        int[] previous = new int[n];
        int[] current = new int[n];
        Array.Fill(previous, int.MinValue);
        previous[n - 1] = fruits[0][n - 1];
        for (int i = 1; i < n - 1; i++)
        {
            Array.Fill(current, int.MinValue);
            for (int j = Math.Max(n - 1 - i, i + 1); j < n; j++)
            {
                int best = previous[j];
                if (j - 1 >= 0)
                    best = Math.Max(best, previous[j - 1]);

                if (j + 1 < n)
                    best = Math.Max(best, previous[j + 1]);

                current[j] = best + fruits[i][j];
            }

            var temp = previous;
            previous = current;
            current = temp;
        }

        return previous[n - 1];
    }
}