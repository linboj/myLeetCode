public class Solution
{
    public int ClosestTarget(string[] words, string target, int startIndex)
    {
        int n = words.Length;
        int ans = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            if (words[i] == target)
            {
                int dist = Math.Abs(startIndex - i);
                ans = Math.Min(ans, Math.Min(dist, n - dist));
            }
        }

        return ans == int.MaxValue ? -1 : ans;

    }
}