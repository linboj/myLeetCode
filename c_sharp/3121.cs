public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int n = word.Length;
        int[] lastLow = new int[26];
        int[] firstUp = new int[26];
        Array.Fill(lastLow, -1);
        Array.Fill(firstUp, n);

        for (int i = 0; i < n; i++)
        {
            char c = word[i];
            if (c >= 'a' && c <= 'z')
            {
                int idx = c - 'a';
                lastLow[idx] = Math.Max(lastLow[idx], i);
            }
            else
            {
                int idx = c - 'A';
                firstUp[idx] = Math.Min(firstUp[idx], i);
            }
        }

        int ans = 0;
        for (int i = 0; i < 26; i++)
        {
            if (lastLow[i] > -1 && firstUp[i] < n && lastLow[i] < firstUp[i])
                ans++;
        }

        return ans;
    }
}