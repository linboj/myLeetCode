public class Solution
{
    public int PossibleStringCount(string word)
    {
        int n = word.Length;
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            if (word[i - 1] == word[i])
                ans++;

        }
        return ans + 1;
    }
}