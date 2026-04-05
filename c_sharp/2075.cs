using System.Text;

public class Solution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        int n = encodedText.Length;
        int nCol = n / rows;
        StringBuilder sb = new();

        for (int i = 0; i < nCol; i++)
        {
            for (int j = i; j < n; j += nCol + 1)
            {
                sb.Append(encodedText[j]);
            }
        }

        string ans = sb.ToString();
        int lastIdx = ans.Length - 1;
        while (lastIdx >= 0 && ans[lastIdx] == ' ')
        {
            lastIdx--;
        }

        return ans.Substring(0, lastIdx + 1);
    }
}