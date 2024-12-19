using System.Text;

public class Solution
{
    public string Convert(string s, int numRows)
    {

        /*
        if (numRows <= 1) return s;

        int minLen = Math.Min(numRows, s.Length);
        List<StringBuilder> rows = new List<StringBuilder>(minLen);
        for (int i = 0; i < minLen; i++) rows.Add(new StringBuilder());
        bool seq = true;
        int curRow = 0;

        foreach (var item in s)
        {
            rows[curRow].Append(item);
            curRow += seq ? 1 : -1;

            if (curRow == 0 || curRow == minLen - 1) seq = !seq;
        }

        var ans = new StringBuilder();
        foreach (var str in rows)
        {
            ans.Append(str);
        }
        
        return ans.ToString();
        */

        if (numRows <= 1 || s.Length <= 1) return s;

        var output = new StringBuilder();

        for (int row = 0; row < numRows && row < s.Length; row++)
        {
            output.Append(s[row]);
            for (int c = 2; (c - 1) * (numRows - 1) < s.Length; c += 2)
            {
                if (c * (numRows - 1) - row < s.Length && row != 0 && row != numRows - 1)
                    output.Append(s[c * (numRows - 1) - row]);

                if (c * (numRows - 1) + row < s.Length)
                    output.Append(s[c * (numRows - 1) + row]);
            }
        }

        return output.ToString();
    }
}