using System.Text;

public class Solution
{
    public string MakeFancyString(string s)
    {
        StringBuilder sb = new StringBuilder();
        char current = '-';
        int count = 1;

        foreach (var ch in s)
        {
            if (current != ch)
            {
                count = 1;
                sb.Append(ch);
            }
            else
            {
                count++;
                if (count < 3)
                    sb.Append(ch);
            }
            current = ch;
        }
        return sb.ToString();
    }
}