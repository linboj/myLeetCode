public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        int ans = 0;
        int nPalindromeWord = 0;
        Dictionary<string, int> counts = new();

        foreach (var word in words)
        {
            if (!counts.ContainsKey(word))
                counts[word] = 0;

            counts[word]++;
        }

        foreach (var (key, value) in counts)
        {
            if (isPalindrome(key))
            {
                ans += value / 2 * 4;
                nPalindromeWord += value % 2;
                continue;
            }

            string mapWord = new string(key.Reverse().ToArray());

            if (!counts.ContainsKey(mapWord))
            {
                counts[key] = 0;
                continue;
            }

            int mapValue = counts[mapWord];
            ans += Math.Min(value, mapValue) * 4;

            counts[key] = 0;
        }

        ans += Math.Min(1, nPalindromeWord) * 2;

        return ans;

    }

    public bool isPalindrome(string word)
    {
        return word[0] == word[1];
    }

    public bool isPalindrome(string word1, string word2)
    {
        return word1[0] == word2[1] && word1[1] == word1[0];
    }
}

public class Solution2
{
    public int LongestPalindrome(string[] words)
    {
        int[,] visited = new int[26, 26];
        int ans = 0;

        foreach (var word in words)
        {
            int digit1 = word[0] - 'a';
            int digit2 = word[1] - 'a';
            if (visited[digit2, digit1] != 0)
            {
                ans += 4;
                visited[digit2, digit1]--;
            }
            else
            {
                visited[digit1, digit2]++;
            }
        }

        for (int i = 0; i < 26; i++)
        {
            if (visited[i, i] >= 1)
            {
                ans += 2;
                break;
            }
        }
        return ans;
    }
}