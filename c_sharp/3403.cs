public class Solution
{
    public string AnswerString(string word, int numFriends)
    {
        if (numFriends == 1) return word;

        string last = lastString(word);
        int n = word.Length, m = last.Length;
        return last.Substring(0, Math.Min(m, n - numFriends + 1));
    }

    private string lastString(string word)
    {
        int i = 0, j = 1, n = word.Length;
        while (j < n)
        {
            int l = 0;
            while (j + l < n && word[i + l] == word[j + l])
                l++;
            if (j + l < n && word[i + l] < word[j + l])
            {
                int tmp = i;
                i = j;
                j = Math.Max(j + 1, tmp + l + 1);
            }
            else
            {
                j = j + l + 1;
            }
        }
        return word.Substring(i);
    }
}