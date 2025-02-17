public class Solution
{
    public string MinWindow(string s, string t)
    {
        int n = s.Length, m = t.Length;

        if (n < m) return "";
        int totalOfLettersInASCII = 'z' - 'A' + 1;
        int[] tCharCount = new int[totalOfLettersInASCII];
        foreach (char c in t)
        {
            tCharCount[c - 'A']++;
        }
        int minLen = int.MaxValue;
        var minWindow = (0, 0);
        int left = 0, right = 0;

        while (right < s.Length)
        {
            while (right < s.Length && m != 0)
            {
                int idx = s[right] - 'A';
                if (tCharCount[idx] > 0) m--;
                tCharCount[idx]--;
                right++;
            }

            while (left < s.Length)
            {
                int idx = s[left] - 'A';
                if (tCharCount[idx] < 0)
                    tCharCount[idx]++;
                else
                    break;
                left++;
            }
            int length = right - left;
            if (m == 0)
            {
                if (length < minLen)
                {
                    minLen = length;
                    minWindow = (left, length);
                }

                tCharCount[s[left] - 'A']++;
                m++;
                left++;
            }
        }

        return s.Substring(minWindow.Item1, minWindow.Item2);
    }
}