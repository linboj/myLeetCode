public class Solution
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        int[] counts = new int[26];
        foreach (var c in brokenLetters)
        {
            counts[c - 'a']++;
        }

        int ans = 0;
        String[] words = text.Split(' ');
        foreach (var word in words)
        {
            bool isValid = true;
            foreach (var c in word)
            {
                if (counts[c - 'a'] > 0)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
                ans++;
        }
        return ans;
    }
}

public class Solution2
{
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        int unable = 0;
        foreach (var c in brokenLetters)
        {
            unable |= 1 << (c - 'a');
        }

        int ans = 0;
        String[] words = text.Split(' ');
        foreach (var word in words)
        {
            bool isValid = true;
            foreach (var c in word)
            {
                if ((unable & (1 << (c - 'a'))) > 0)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid)
                ans++;
        }
        return ans;
    }
}