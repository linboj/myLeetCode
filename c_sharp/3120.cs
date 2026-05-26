public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        HashSet<char> hs = new(word);

        int ans = 0;

        for (char i = 'a'; i <= 'z'; i++)
        {
            if (hs.Contains(i) && hs.Contains((char)(i - 'a' + 'A')))
                ans++;
        }

        return ans;
    }
}