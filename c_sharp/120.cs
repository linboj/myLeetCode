public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[] prev = new int[n + 1];
        Array.Fill(prev, int.MaxValue);
        prev[1] = triangle[0][0];

        for (int i = 1; i < n; i++)
        {
            int prevValue = prev[1];
            for (int j = 1; j <= i + 1; j++)
            {
                int temp = Math.Min(prevValue, prev[j]) + triangle[i][j-1];
                prevValue = prev[j];
                prev[j] = temp;
            }
        }

        int ans = int.MaxValue;
        for (int i = 1; i <= n; i++)
        {
            ans = Math.Min(ans, prev[i]);
        }
        return ans;
    }
}

public class Solution2
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        int[] result = new int[triangle[n-1].Count + 1];

        for (int i = n-1; i >= 0; i--)
        {
            int len = triangle[i].Count;
            for (int j = 0; j < len; j++)
            {
                result[j] = triangle[i][j] + Math.Min(result[j], result[j+1]);
            }
        }

        return result[0];
    }
}