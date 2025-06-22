public class Solution
{
    public int MinimumDeletions(string word, int k)
    {
        int n = word.Length;
        int[] counts = new int[26];

        foreach (var ch in word)
        {
            counts[ch - 'a']++;
        }
        int ans = word.Length;
        foreach (int a in counts)
        {
            if (a == 0)
                continue;
            int deleted = 0;
            foreach (int b in counts)
            {
                if (b == 0)
                    continue;

                if (a > b)
                    deleted += b;
                else if (b > a + k)
                    deleted += b - a - k;
            }

            ans = Math.Min(ans, deleted);
        }
        return ans;
    }
}