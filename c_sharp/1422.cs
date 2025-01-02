public class Solution
{
    public int MaxScore(string s)
    {
        int currentScore = 0;

        // add left score 
        currentScore += s[0] == '0' ? 1 : 0;
        // add right score
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == '1') currentScore += 1;
        }
        int maxScore = currentScore;
        for (int i = 1; i < s.Length - 1; i++)
        {
            currentScore += s[i] == '1' ? -1 : 1;
            if (currentScore > maxScore) maxScore = currentScore;
        }
        return maxScore;
    }
}