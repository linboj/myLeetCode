public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int ans = 0;
        int[] counts = new int[3];
        int left = 0;

        for (int right = 0; right < n; right++)
        {
            counts[s[right] - 'a']++;
            while (counts[0] > 0 && counts[1] > 0 && counts[2] > 0)
            {
                ans += n - right;
                counts[s[left] - 'a']--;
                left++;
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int ans = 0;
        int[] lastIndices = [-1, -1, -1];

        for (int idx = 0; idx < n; idx++)
        {
            lastIndices[s[idx] - 'a'] = idx;
            ans += Math.Min(lastIndices[0], Math.Min(lastIndices[1], lastIndices[2])) + 1;
        }
        return ans;
    }
}