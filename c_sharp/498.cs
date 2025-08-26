public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat == null || mat.Length == 0)
            return [];

        int n = mat.Length, m = mat[0].Length;
        int row = 0, col = 0;

        int direction = 1;

        int[] ans = new int[n * m];
        int currentIdx = 0;

        while (row < n && col < m)
        {
            ans[currentIdx++] = mat[row][col];

            int newRow = row + (direction == 1 ? -1 : 1);
            int newCol = col + (direction == 1 ? 1 : -1);

            if (newRow < 0 || newRow == n || newCol < 0 || newCol == m)
            {
                if (direction == 1)
                {
                    row += col == m - 1 ? 1 : 0;
                    col += col < m - 1 ? 1 : 0;
                }
                else
                {
                    col += row == n - 1 ? 1 : 0;
                    row += row < n - 1 ? 1 : 0;
                }
                direction = 1 - direction;
            }
            else
            {
                row = newRow;
                col = newCol;
            }
        }
        return ans;
    }
}