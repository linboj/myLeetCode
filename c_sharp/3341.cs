public class Solution
{
    private int[][] dirs = { [1, 0], [0, 1], [-1, 0], [0, -1] };
    public int MinTimeToReach(int[][] moveTime)
    {
        int n = moveTime.Length, m = moveTime[0].Length;
        int[][] distance = new int[n][];
        bool[][] visited = new bool[n][];
        for (int row = 0; row < n; row++)
        {
            distance[row] = new int[m];
            visited[row] = new bool[m];
            Array.Fill(distance[row], int.MaxValue);
        }

        distance[0][0] = 0;
        PriorityQueue<(int r, int c), int> pq = new();
        pq.Enqueue((0, 0), distance[0][0]);

        while (pq.Count > 0)
        {
            var (row, col) = pq.Dequeue();
            if (visited[row][col])
                continue;

            visited[row][col] = true;
            foreach (var dir in dirs)
            {
                int nextRow = row + dir[0];
                int nextCol = col + dir[1];

                if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m)
                    continue;

                int nextDis = Math.Max(distance[row][col], moveTime[nextRow][nextCol]) + 1;
                if (distance[nextRow][nextCol] > nextDis)
                {
                    distance[nextRow][nextCol] = nextDis;
                    pq.Enqueue((nextRow, nextCol), nextDis);
                }
            }
        }
        return distance[n - 1][m - 1];
    }
}