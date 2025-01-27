public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length <= 1) return s;
        int[] longestPalindromeIndices = new int[2];

        for (int i = 0; i < s.Length; i++)
        {
            var oddIndices = expandAroundCenter(s, i, i);

            if (oddIndices[1] - oddIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])
            {
                longestPalindromeIndices = oddIndices;
            }
            if (i + 1 < s.Length && s[i] == s[i + 1])
            {
                var evenIndices = expandAroundCenter(s, i, i + 1);

                if (evenIndices[1] - evenIndices[0] > longestPalindromeIndices[1] - longestPalindromeIndices[0])
                {
                    longestPalindromeIndices = evenIndices;
                }
            }
        }
        return s.Substring(longestPalindromeIndices[0], longestPalindromeIndices[1] - longestPalindromeIndices[0] + 1);
    }

    private int[] expandAroundCenter(string s, int start, int end)
    {
        while (start >= 0 && end < s.Length && s[start] == s[end])
        {
            start--;
            end++;
        }
        return [start + 1, end - 1];
    }
}

public class Solution2
{
    // Manacher's algorithm
    public string LongestPalindrome(string s)
    {
        string modified = "^#" + string.Join("#", s.ToCharArray()) + "#$";
        int strLength = modified.Length;
        int[] palindromeLengths = new int[strLength];
        int center = 0;
        int rightEdge = 0;

        for (int i = 1; i < strLength - 1; i++)
        {
            palindromeLengths[i] = (rightEdge > i) ? Math.Min(rightEdge - i, palindromeLengths[2 * center - i]) : 0;
            while (modified[i + 1 + palindromeLengths[i]] == modified[i - 1 - palindromeLengths[i]])
            {
                palindromeLengths[i]++;
            }

            if ((i + palindromeLengths[i]) > rightEdge)
            {
                center = i;
                rightEdge = i + palindromeLengths[i];
            }
        }

        int maxLength = palindromeLengths.Max();
        int maxCenter = Array.IndexOf(palindromeLengths, maxLength);

        return s.Substring((maxCenter - maxLength) / 2, maxLength);
    }
}