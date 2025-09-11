using System.Text;

public class Solution
{
    public string SortVowels(string s)
    {
        int[] cnts = new int[68];
        foreach (var c in s)
        {
            if (IsVowel(c))
            {
                cnts[c - 'A']++;
            }
        }

        StringBuilder sb = new();
        int idx = 0;
        foreach (var c in s)
        {
            if (IsVowel(c))
            {
                while (cnts[idx] == 0)
                {
                    idx++;
                }
                sb.Append((char)('A' + idx));
                cnts[idx]--;
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }
}