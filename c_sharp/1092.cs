using System.Text;

public class Solution
{
    // Bottom-Up DP
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;
        string[] prevRow = new string[m + 1];
        for (int col = 0; col <= m; col++) prevRow[col] = str2.Substring(0, col);

        for (int row = 1; row <= n; row++)
        {
            string[] currRow = new string[m + 1];
            currRow[0] = str1.Substring(0, row);

            for (int col = 1; col <= m; col++)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    currRow[col] = prevRow[col - 1] + str1[row - 1];
                }
                else
                {
                    var s1Pick = prevRow[col];
                    var s2Pick = currRow[col - 1];

                    currRow[col] = (s1Pick.Length < s2Pick.Length) ?
                        s1Pick + str1[row - 1] : s2Pick + str2[col - 1];
                }
            }
            prevRow = currRow;
        }
        return prevRow[m];
    }
}

public class Solution2
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;
        int[][] dp = new int[n + 1][];
        for (int row = 0; row <= n; row++)
        {
            dp[row] = new int[m + 1];
            dp[row][0] = row;
        }
        for (int col = 0; col <= m; col++) dp[0][col] = col;

        for (int row = 1; row <= n; row++)
        {
            for (int col = 1; col <= m; col++)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    dp[row][col] = dp[row - 1][col - 1] + 1;
                }
                else
                {
                    dp[row][col] = Math.Min(dp[row][col - 1], dp[row - 1][col]) + 1;
                }
            }
        }
        StringBuilder resultR = new();
        int curRow = n, curCol = m;

        while (curRow > 0 && curCol > 0)
        {
            if (str1[curRow - 1] == str2[curCol - 1])
            {
                resultR.Append(str1[curRow - 1]);
                curRow--;
                curCol--;
            }
            else if (dp[curRow - 1][curCol] < dp[curRow][curCol - 1])
            {
                resultR.Append(str1[curRow - 1]);
                curRow--;
            }
            else
            {
                resultR.Append(str2[curCol - 1]);
                curCol--;
            }
        }

        while (curRow > 0)
        {
            resultR.Append(str1[curRow - 1]);
            curRow--;
        }

        while (curCol > 0)
        {
            resultR.Append(str2[curCol - 1]);
            curCol--;
        }

        return new string(resultR.ToString().Reverse().ToArray());
    }
}