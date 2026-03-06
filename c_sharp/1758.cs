public class Solution
{
    public int MinOperations(string s)
    {
        int start0 = 0;

        for (int i = 0; i < s.Length; i++)
        {
            start0 += Math.Abs(i % 2 - (s[i] - '0'));
        }

        return Math.Min(start0, s.Length - start0);
    }
}