public class Solution
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        int dest = n * n;
        Queue<(int square, int moves)> queue = new();
        queue.Enqueue((1, 0));
        bool[] visited = new bool[dest + 1];  // Track visited positions
        while (queue.Count != 0)
        {
            var currItem = queue.Dequeue();
            for (int i = 1; i < 7; i++)
            {
                int next = i + currItem.square;
                int r = (dest - next) / n;
                int c = (n - r) % 2 == 1 ? (next - 1) % n : n - ((next - 1) % n) - 1;
                if (board[r][c] != -1)
                {
                    next = board[r][c];
                }
                if (next == dest) return currItem.moves + 1;

                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue((next, currItem.moves + 1));
                }
            }
        }
        return -1;
    }
}