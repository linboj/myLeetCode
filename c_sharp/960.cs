public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int w = strs[0].Length;
        int[] dp = new int[w];
        int left = 1;

        for (int i = 0; i < w; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                bool isValid = true;
                foreach (var row in strs)
                {
                    if (row[i] < row[j])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
            }
            left = Math.Max(dp[i], left);
        }
        return w - left;
    }
}