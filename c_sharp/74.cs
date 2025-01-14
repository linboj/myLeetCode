public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (target < matrix[0][0]) return false;
        if (target > matrix[^1][^1]) return false;
        int startIdx = 0, endIdx = matrix.Length - 1;
        // find target would in which row
        while (startIdx <= endIdx)
        {
            int midIdx = (endIdx + startIdx) / 2;
            if (matrix[midIdx][0] == target) return true;
            else if (matrix[midIdx][0] < target) startIdx = midIdx + 1;
            else endIdx = midIdx - 1;
        }
        int row = startIdx == 0 ? 0 : startIdx - 1;
        // find each col
        startIdx = 0;
        endIdx = matrix[row].Length - 1;
        while (startIdx <= endIdx)
        {
            int midIdx = (endIdx + startIdx) / 2;
            if (matrix[row][midIdx] == target) return true;
            else if (matrix[row][midIdx] < target) startIdx = midIdx + 1;
            else endIdx = midIdx - 1;
        }
        return false;
    }
}