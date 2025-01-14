public class Solution
{
    public int MinimumLength(string s)
    {
        int[] charCount = new int[26];
        foreach (var c in s)
        {
            charCount[c - 'a']++;
        }

        int ans = 0;
        for (int i = 0; i < charCount.Length; i++)
        {
            if (charCount[i] > 0)
            {
                if (charCount[i] % 2 == 0) ans += 2;
                else ans += 1;
            }
        }
        return ans;
    }
}
