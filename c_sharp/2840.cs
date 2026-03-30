public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        int n = s1.Length;
        int[] odd = new int[26], even = new int[26];

        for (int i = 0; i < n; i += 2)
        {
            even[s1[i] - 'a']++;
            even[s2[i] - 'a']--;
        }

        for (int i = 1; i < n; i += 2)
        {
            odd[s1[i] - 'a']++;
            odd[s2[i] - 'a']--;
        }

        for (int i = 0; i < 26; i++)
        {
            if (even[i] != 0 || odd[i] != 0)
                return false;
        }

        return true;
    }
}