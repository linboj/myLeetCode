using System.Text;

public class Solution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        List<string> result = new List<string>();
        List<string> curWords = new();
        int currentLen = 0;

        StringBuilder strB = new StringBuilder();
        foreach (var currentWord in words)
        {
            if (currentLen + currentWord.Length + curWords.Count > maxWidth)
            {
                int gaps = curWords.Count - 1, totalSpaces = maxWidth - currentLen;
                if (gaps == 0)
                {
                    strB.Append(curWords[0]);
                    strB.Append(' ', totalSpaces);
                }
                else
                {
                    int spacePerGap = totalSpaces / gaps;
                    int extraGaps = totalSpaces % gaps;
                    for (int i = 0; i < gaps; i++)
                    {
                        strB.Append(curWords[i]);                        
                        strB.Append(' ', spacePerGap);
                        if (i < extraGaps) strB.Append(' ');
                    }
                    strB.Append(curWords[gaps]);
                }
                result.Add(strB.ToString());
                strB.Clear();
                curWords.Clear();
                currentLen = 0;
            }
            currentLen += currentWord.Length;
            curWords.Add(currentWord);
        }
        var lastLine = string.Join(" ", curWords).PadRight(maxWidth, ' ');
        result.Add(lastLine);

        return result;
    }
}