public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        bool y0 = false;
        // check [r,0]
        for (int r = 0; r < matrix.Length; r++)
        {
            if (matrix[r][0] == 0)
            {
                y0 = true;
                break;
            }
        }
        // check [0,c]
        for (int c = 0; c < matrix[0].Length; c++)
        {
            if (matrix[0][c] == 0)
            {
                matrix[0][0] = 0;
            }
        }
        // check [1,1] ~ [r,c]
        for (int r = 1; r < matrix.Length; r++)
        {
            for (int c = 1; c < matrix[0].Length; c++)
            {
                if (matrix[r][c] == 0)
                {
                    matrix[0][c] = 0;
                    matrix[r][0] = 0;
                }
            }
        }
        // set zero
        for (int c = 1; c < matrix[0].Length; c++)
        {
            for (int r = 1; r < matrix.Length; r++)
            {
                if (matrix[0][c] == 0 || matrix[r][0] == 0)
                {
                    matrix[r][c] = 0;
                }
            }
        }
        // set [0, c] to zero
        if (matrix[0][0] == 0)
        {
            for (int c = 1; c < matrix[0].Length; c++)
            {
                matrix[0][c] = 0;
            }
        }
        // set [r, 0] to zero
        if (y0)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r][0] = 0;
            }
        }
    }
}