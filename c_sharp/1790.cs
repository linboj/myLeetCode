public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;
        int[] charCount1 = new int[26];
        int[] charCount2 = new int[26];
        int diff = 0;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                charCount1[s1[i] - 'a']++;
                charCount2[s2[i] - 'a']++;
                diff++;
            }

            if (diff > 2) return false;
        }
        for (int i = 0; i < charCount1.Length; i++)
        {
            if (charCount1[i] != charCount2[i]) return false;
        }
        return true;
    }
}