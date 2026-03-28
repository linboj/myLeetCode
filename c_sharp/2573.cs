public class Solution
{
    public string FindTheString(int[][] lcp)
    {
        int n = lcp.Length;
        char[] words = new char[n];
        char curChar = 'a';

        for (int i = 0; i < n; i++)
        {
            if (words[i] == '\0')
            {
                if (curChar > 'z')
                    return "";

                words[i] = curChar;
                for (int j = i + 1; j < n; j++)
                {
                    if (lcp[i][j] > 0)
                    {
                        words[j] = words[i];
                    }
                }
                curChar++;
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (words[i] != words[j])
                {
                    if (lcp[i][j] != 0)
                        return "";
                }
                else
                {
                    if (i == n - 1 || j == n - 1)
                    {
                        if (lcp[i][j] != 1)
                            return "";
                    }
                    else
                    {
                        if (lcp[i][j] != lcp[i + 1][j + 1] + 1)
                            return "";
                    }
                }
            }
        }
        return new string(words);
    }
}