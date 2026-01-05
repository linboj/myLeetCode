public class Solution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        long sum = 0;
        int negetive = 0, minAbs = int.MaxValue;

        foreach (var row in matrix)
        {
            foreach (var grid in row)
            {
                int abs = Math.Abs(grid);
                sum += abs;
                minAbs = Math.Min(minAbs, abs);
                if (grid < 0)
                    negetive++;

            }
        }

        if (negetive % 2 != 0)
            sum -= 2 * minAbs;

        return sum;
    }
}