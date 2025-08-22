public class Solution
{
    public int NumSubmat(int[][] mat)
    {
        int n = mat[0].Length;
        int[] heights = new int[n];
        int ans = 0;

        foreach (var row in mat)
        {
            for (int i = 0; i < n; i++)
            {
                heights[i] = row[i] == 0 ? 0 : heights[i] + 1;
            }
            Stack<int[]> stack = new();
            stack.Push(new int[3] { -1, 0, -1 });
            for (int i = 0; i < n; i++)
            {
                int h = heights[i];
                while (stack.Peek()[2] >= h)
                {
                    stack.Pop();
                }
                var top = stack.Peek();
                int left = top[0];
                int prev = top[1];
                int cur = prev + (i - left) * h;
                stack.Push(new int[3] { i, cur, h });
                ans += cur;
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int NumSubmat(int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[m];
        }

        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (mat[i][j] == 1)
                {
                    dp[i][j] = 1 + (j == 0 ? 0 : dp[i][j - 1]);
                    int minWidth = dp[i][j];

                    for (int k = i; k >= 0 && dp[k][j] > 0; k--)
                    {
                        minWidth = Math.Min(minWidth, dp[k][j]);
                        ans += minWidth;
                    }
                }
            }
        }
        return ans;
    }
}