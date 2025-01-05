public class Solution
{
    public int CountPalindromicSubsequence(string s)
    {
        int ans = 0;
        int[] first = new int[26];
        int[] last = new int[26];
        Array.Fill(first, -1);

        for (int i = 0; i < s.Length; i++)
        {
            int code = s[i] - 'a';
            if (first[code] == -1)
            {
                first[code] = i;
            }
            last[code] = i;
        }

        HashSet<char> set = new();
        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] == -1) continue;
            int left = first[i], right = last[i];
            if (left + 1 >= right) continue;
            set.Clear();
            for (int j = left + 1; j < right; j++)
            {
                set.Add(s[j]);
            }
            ans += set.Count;
        }
        return ans;
    }
}