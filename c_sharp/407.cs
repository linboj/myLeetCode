public class Solution
{
    public int TrapRainWater(int[][] heightMap)
    {
        int nRows = heightMap.Length;
        int nCols = heightMap[0].Length;

        if (nRows < 3 || nCols < 3) return 0;

        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        bool[,] visited = new bool[nRows, nCols];
        PriorityQueue<(int r, int c, int heigh), int> boundary = new();
        int totalWaterVolume = 0;
        for (int i = 0; i < nCols; i++)
        {
            boundary.Enqueue((0, i, heightMap[0][i]), heightMap[0][i]);
            visited[0, i] = true;
            boundary.Enqueue((nRows - 1, i, heightMap[nRows - 1][i]), heightMap[nRows - 1][i]);
            visited[nRows - 1, i] = true;
        }

        for (int i = 1; i < nRows - 1; i++)
        {
            boundary.Enqueue((i, 0, heightMap[i][0]), heightMap[i][0]);
            visited[i, 0] = true;
            boundary.Enqueue((i, nCols - 1, heightMap[i][nCols - 1]), heightMap[i][nCols - 1]);
            visited[i, nCols - 1] = true;
        }

        while (boundary.Count > 0)
        {
            var (currentRow, currentCol, minBoundaryHeight) = boundary.Dequeue();

            for (int dir = 0; dir < dirs.Length; dir++)
            {
                int nextRow = currentRow + dirs[dir][0];
                int nextCol = currentCol + dirs[dir][1];

                if (nextRow >= nRows || nextCol >= nCols || nextRow < 0 || nextCol < 0 || visited[nextRow, nextCol]) continue;

                int nextHeight = heightMap[nextRow][nextCol];

                if (nextHeight < minBoundaryHeight) totalWaterVolume += minBoundaryHeight - nextHeight;
                int finalHeight = Math.Max(nextHeight, minBoundaryHeight);
                boundary.Enqueue((nextRow, nextCol, finalHeight), finalHeight);
                visited[nextRow, nextCol] = true;
            }
        }
        return totalWaterVolume;
    }
}