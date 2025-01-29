public class Solution
{
    public int MaximalSquare(char[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int maxSide = 0;
        int[] prev = new int[n];

        for (int r = 0; r < m; r++)
        {
            int[] current = new int[n];
            current[0] = matrix[r][0] - '0';
            for (int c = 0; c < n; c++)
            {
                if (matrix[r][c] == '1')
                {
                    if (r == 0 || c == 0)
                    {
                        current[c] = 1;
                    }
                    else
                    {
                        current[c] = Math.Min(Math.Min(prev[c - 1], prev[c]), current[c - 1]) + 1;
                    }
                    maxSide = Math.Max(maxSide, current[c]);
                }
            }
            prev = current;
        }
        return maxSide * maxSide;

    }
}