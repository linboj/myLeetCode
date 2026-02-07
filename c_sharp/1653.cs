public class Solution
{
    public int MinimumDeletions(string s)
    {
        int n = s.Length;
        int ans = n, aCnts = 0;

        foreach (var c in s)
        {
            aCnts += 'b' - c;
        }

        int bCnts = 0;
        foreach (var c in s)
        {
            aCnts -= 'b' - c;
            ans = Math.Min(ans, aCnts + bCnts);
            bCnts += c - 'a';
        }

        return ans;
    }
}

public class Solution2
{
    public int MinimumDeletions(string s)
    {
        int ans = 0;
        int bCnts = 0;

        foreach (var c in s)
        {
            if (c == 'b')
            {
                bCnts++;
            }
            else
            {
                ans = Math.Min(ans + 1, bCnts); // remove cur 'a' or all met 'b'
            }
        }

        return ans;
    }
}