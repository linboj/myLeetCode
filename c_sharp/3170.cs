using System.Text;

public class Solution
{
    public string ClearStars(string s)
    {
        char minChar = 'z';
        Stack<int>[] counts = new Stack<int>[26];
        for (int i = 0; i < 26; i++)
        {
            counts[i] = new Stack<int>();
        }
        var sCharArray = s.ToCharArray();
        for (int i = 0; i < sCharArray.Length; i++)
        {
            char ch = sCharArray[i];
            if (ch == '*')
            {
                int minCharIdx = minChar - 'a';
                sCharArray[counts[minCharIdx].Pop()] = '*';
                if (counts[minCharIdx].Count == 0)
                {
                    for (int j = minCharIdx + 1; j < 26; j++)
                    {
                        minChar = (char)(j + 'a');
                        if (counts[j].Count > 0)
                            break;
                    }
                }
            }
            else
            {
                if (ch < minChar)
                    minChar = ch;
                counts[ch - 'a'].Push(i);
            }
        }

        StringBuilder sb = new();
        foreach (var ch in sCharArray)
        {
            if (ch != '*')
                sb.Append(ch);
        }
        return sb.ToString();
    }
}