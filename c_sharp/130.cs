public class Solution
{
    public void Solve(char[][] board)
    {
        int r = board.Length;
        int c = board[0].Length;

        for (int i = 0; i < r; i++)
        {
            if (board[i][0] == 'O') DFS(board, i, 0);
            if (board[i][c - 1] == 'O') DFS(board, i, c - 1);
        }
        for (int i = 0; i < c; i++)
        {
            if (board[0][i] == 'O') DFS(board, 0, i);
            if (board[r - 1][i] == 'O') DFS(board, r - 1, i);
        }

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                board[i][j] = board[i][j] == 'A' ? 'O' : 'X';
            }
        }
    }

    private void DFS(char[][] board, int r, int c)
    {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] == 'X') return;

        board[r][c] = 'A';
        DFS(board, r - 1, c);
        DFS(board, r + 1, c);
        DFS(board, r, c - 1);
        DFS(board, r, c + 1);
    }
}