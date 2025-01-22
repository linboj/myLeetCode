public class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        int nRow = isWater.Length, nCol = isWater[0].Length;
        int[][] result = new int[nRow][];
        Queue<(int r, int c)> queue = new();
        for (int r = 0; r < nRow; r++)
        {
            result[r] = new int[nCol];
            for (int c = 0; c < nCol; c++)
            {
                if (isWater[r][c] == 1)
                {
                    queue.Enqueue((r, c));
                    result[r][c] = 0;
                }
                else{
                    result[r][c] = -1;
                }
            }
        }
        while (queue.Count > 0)
        {
            int queueSize = queue.Count;
            for (int i = 0; i < queueSize; i++)
            {
                var (curRow, curCol) = queue.Dequeue();
                foreach (var dir in dirs)
                {
                    int nextRow = curRow + dir[0];
                    int nextCol = curCol + dir[1];
                    if (nextRow >= nRow || nextCol >= nCol || nextRow < 0 || nextCol < 0 || result[nextRow][nextCol] != -1) continue;
                    result[nextRow][nextCol] = result[curRow][curCol] + 1;
                    queue.Enqueue((nextRow, nextCol));
                }
            }
        }
        return result;
    }
}