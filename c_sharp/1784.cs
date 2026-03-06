public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        int changed = 0;
        char prev = '1';

        foreach (var cur in s)
        {
            if (prev != cur)
            {
                prev = cur;
                changed++;
            }
        }

        return changed <= 1;
    }
}