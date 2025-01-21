public class Solution {
    public long GridGame(int[][] grid) {
        int n = grid[0].Length;
        long firstRowSum = 0, secondRowSum = 0;
        for (int i = 0; i < n; i++){
            firstRowSum += grid[0][i];
        }
        long minimumSum = long.MaxValue;

        for (int i = 0; i < n; i++) {
            firstRowSum -= grid[0][i];
            long maximumSum = Math.Max(firstRowSum, secondRowSum);
            minimumSum = Math.Min(minimumSum, maximumSum);
            secondRowSum += grid[1][i];
        }

        return minimumSum;

    }
}