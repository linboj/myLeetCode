public class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        int maxLeftScore = values[0];
        int maxScore = 0;

        for (int i = 1; i < values.Length; i++)
        {
            int rightScore = values[i] - i;
            maxScore = Math.Max(maxScore, rightScore + maxLeftScore);
            int leftScore = values[i] + i;

            maxLeftScore = Math.Max(maxLeftScore, leftScore);
        }
        return maxScore;
    }
}