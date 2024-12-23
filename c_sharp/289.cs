public class Solution
{
    public void GameOfLife(int[][] board)
    {
        int nRow = board.Length, nCol = board[0].Length;

        for (int r = 0; r < nRow; r++)
        {
            for (int c = 0; c < nCol; c++)
            {
                int nLive = 0;
                if (r - 1 >= 0)
                {
                    nLive += board[r - 1][c] % 10;
                    if (c - 1 >= 0) nLive += board[r - 1][c - 1] % 10;
                    if (c + 1 < nCol) nLive += board[r - 1][c + 1] % 10;
                }
                if (c - 1 >= 0) nLive += board[r][c - 1] % 10;
                if (c + 1 < nCol) nLive += board[r][c + 1] % 10;

                if (r + 1 < nRow)
                {
                    nLive += board[r + 1][c] % 10;
                    if (c - 1 >= 0) nLive += board[r + 1][c - 1] % 10;
                    if (c + 1 < nCol) nLive += board[r + 1][c + 1] % 10;
                }

                if (board[r][c] == 1 && 2 <= nLive && nLive <= 3)
                {
                    board[r][c] += 10;
                }

                if (board[r][c] == 0 && nLive == 3)
                {
                    board[r][c] += 10;
                }
            }
        }

        for (int r = 0; r < nRow; r++)
        {
            for (int c = 0; c < nCol; c++)
            {
                board[r][c] /= 10;
            }
        }
    }
}