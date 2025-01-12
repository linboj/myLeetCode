public class Solution
{
    public bool CanConstruct(string s, int k)
    {
        if (s.Length < k) return false;
        int[] charCount = new int[26];

        foreach (var c in s)
        {
            charCount[c - 'a'] += 1;
        }

        int oddCount = 0;
        for (int i = 0; i < charCount.Length; i++)
        {
            if (charCount[i] % 2 == 1 ) oddCount++;
        }

        return oddCount <= k;

    }
}