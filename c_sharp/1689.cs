public class Solution
{
    public int MinPartitions(string n)
    {
        int ans = 0;

        foreach (var c in n)
        {
            ans = Math.Max(ans, c - '0');
        }

        return ans;
    }
}