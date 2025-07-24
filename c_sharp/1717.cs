using System.Text;

public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        if (x < y)
        {
            (x, y) = (y, x);
            s = new string(s.Reverse().ToArray());
        }

        int aCount = 0, bCount = 0;
        int score = 0;

        foreach (var current in s)
        {
            if (current == 'a')
            {
                aCount++;
            }
            else if (current == 'b')
            {
                if (aCount > 0)
                {
                    aCount--;
                    score += x;
                }
                else
                {
                    bCount++;
                }
            }
            else
            {
                score += Math.Min(aCount, bCount) * y;
                aCount = 0;
                bCount = 0;
            }
        }
        score += Math.Min(aCount, bCount) * y;
        return score;
    }
}