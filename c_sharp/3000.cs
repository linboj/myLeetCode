public class Solution
{
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int maxArea = dimensions[0][0] * dimensions[0][1];
        int maxDiagonal = dimensions[0][0] * dimensions[0][0] + dimensions[0][1] * dimensions[0][1];

        foreach (var dimension in dimensions)
        {
            int diagonal = dimension[0] * dimension[0] + dimension[1] * dimension[1];
            if (diagonal > maxDiagonal)
            {
                maxDiagonal = diagonal;
                maxArea = dimension[0] * dimension[1];
            }
            else if (diagonal == maxDiagonal)
            {
                maxArea = Math.Max(maxArea, dimension[0] * dimension[1]);
            }
        }
        return maxArea;
    }
}