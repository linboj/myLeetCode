public class Solution
{
    public IList<string> GetLongestSubsequence(string[] words, int[] groups)
    {
        List<string> ans = new();
        ans.Add(words[0]);
        int last = groups[0];
        for (int i = 1; i < groups.Length; i++)
        {
            if (groups[i] != last)
            {
                ans.Add(words[i]);
                last = groups[i];
            }
        }
        return ans;
    }
}