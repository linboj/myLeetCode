public class Solution
{
    // Sorting Queries + Min-Heap
    public int[][] directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        int nRow = grid.Length, nCol = grid[0].Length;
        int[] result = new int[queries.Length];

        int[][] sortedQueries = new int[queries.Length][];
        for (int idx = 0; idx < queries.Length; idx++)
        {
            sortedQueries[idx] = new int[2];
            sortedQueries[idx][0] = idx;
            sortedQueries[idx][1] = queries[idx];
        }

        Array.Sort(sortedQueries, (a, b) => a[1].CompareTo(b[1]));

        PriorityQueue<(int row, int col, int val), int> minHeap = new();

        bool[][] visited = new bool[nRow][];
        for (int i = 0; i < nRow; i++)
        {
            visited[i] = new bool[nCol];
        }
        visited[0][0] = true;

        minHeap.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        int totalPoints = 0;

        foreach (var sortedQuery in sortedQueries)
        {
            var queryIdx = sortedQuery[0];
            var queryVal = sortedQuery[1];
            while (minHeap.Count > 0 && minHeap.Peek().val < queryVal)
            {
                var (row, col, _) = minHeap.Dequeue();
                totalPoints++;

                foreach (var dir in directions)
                {
                    int newRow = row + dir[0], newCol = col + dir[1];

                    if (newRow >= 0 && newCol >= 0 && newRow < nRow && newCol < nCol && !visited[newRow][newCol])
                    {
                        minHeap.Enqueue((newRow, newCol, grid[newRow][newCol]), grid[newRow][newCol]);
                        visited[newRow][newCol] = true;
                    }
                }
            }
            result[queryIdx] = totalPoints;
        }

        return result;
    }
}