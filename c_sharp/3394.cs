public class Solution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        // check x and y axis
        for (int axis = 0; axis <= 1; axis++)
        {
            int gapCount = 0;
            Array.Sort(rectangles, (a, b) => a[axis].CompareTo(b[axis]));
            int furthestEnd = rectangles[0][axis + 2];
            for (int i = 1; i < rectangles.Length; i++)
            {
                if (rectangles[i][axis] >= furthestEnd)
                {
                    gapCount++;
                }
                furthestEnd = Math.Max(furthestEnd, rectangles[i][axis + 2]);
            }
            if (gapCount >= 2) return true;
        }
        return false;
    }
}