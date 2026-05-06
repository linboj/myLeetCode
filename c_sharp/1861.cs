public class Solution
{
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        int n = boxGrid.Length, m = boxGrid[0].Length;
        char[][] ans = new char[m][];

        for (int i = 0; i < m; i++)
        {
            ans[i] = new char[n];
            for (int j = 0; j < n; j++)
            {
                ans[i][j] = '.';
            }
        }

        for (int i = 0; i < n; i++)
        {
            int lowest = m - 1;
            for (int j = m - 1; j >= 0; j--)
            {
                if (boxGrid[i][j] == '#')
                {
                    ans[lowest][n - 1 - i] = '#';
                    lowest--;
                }

                if (boxGrid[i][j] == '*')
                {
                    ans[j][n - 1 - i] = '*';
                    lowest = j - 1;
                }
            }
        }
        return ans;
    }
}