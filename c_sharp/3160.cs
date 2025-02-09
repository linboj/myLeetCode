public class Solution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        int[] ans = new int[queries.Length];
        Dictionary<int, int> ballColor = new();
        Dictionary<int, int> colorCount = new();

        for (int i = 0; i < queries.Length; i++)
        {
            int ball = queries[i][0];
            int color = queries[i][1];
            if (ballColor.ContainsKey(ball))
            {
                colorCount[ballColor[ball]]--;
                if (colorCount[ballColor[ball]] == 0) colorCount.Remove(ballColor[ball]);
            }
            ballColor[ball] = color;
            if (colorCount.ContainsKey(color))
                colorCount[color]++;
            else
                colorCount[color] = 1;
            ans[i] = colorCount.Count;
        }
        return ans;
    }
}