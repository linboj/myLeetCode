public class Solution
{
    public int MinCost(int[][] grid)
    {
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        int numsRows = grid.Length;
        int numsCols = grid[0].Length;
        int[,] costs = new int[numsRows, numsCols];
        for (int i = 0; i < numsRows; i++)
        {
            for (int j = 0; j < numsCols; j++)
            {
                costs[i, j] = int.MaxValue;
            }
        }
        costs[0, 0] = 0;
        PriorityQueue<Tuple<int, int, int>, int> queue = new();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 0), 0);

        while (queue.Count > 0)
        {
            var picked = queue.Dequeue();
            int row = picked.Item1, col = picked.Item2;
            if (row == numsRows - 1 && col == numsCols - 1) return picked.Item3;

            for (int dir = 0; dir < dirs.Length; dir++)
            {
                int newRow = row + dirs[dir][0];
                int newCol = col + dirs[dir][1];
                var nextCost = picked.Item3;
                if (grid[row][col] != (dir + 1)) nextCost++;

                if (newRow >= numsRows || newCol >= numsCols || newRow < 0 || newCol < 0) continue;

                if (nextCost < costs[newRow, newCol])
                {
                    costs[newRow, newCol] = nextCost;
                    queue.Enqueue(new Tuple<int, int, int>(newRow, newCol, nextCost), nextCost);
                }
            }
        }
        return -1;
    }

}