public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        long n = grid.Length;
        long nSquare = n * n;

        long expectSum = nSquare * (nSquare + 1) / 2;
        long expectSqrSum = nSquare * (nSquare + 1) * (2 * nSquare + 1) / 6;

        foreach (var row in grid)
        {
            foreach (var value in row)
            {
                expectSqrSum -= value * value;
                expectSum -= value;
            }
        }

        int missPlusRepeat = (int)(expectSqrSum / expectSum);
        int missMinusRepeat = (int)expectSum;

        return [(missPlusRepeat - missMinusRepeat) / 2, (missPlusRepeat + missMinusRepeat) / 2];
    }
}