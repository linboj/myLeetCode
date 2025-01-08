public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        List<char> found = new();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (Solve(board, word, i, j, 0)) return true;
            }
        }
        return false;
    }

    private bool Solve(char[][] board, string word, int row, int col, int wordIdx)
    {
        if (wordIdx == word.Length) return true;
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length) return false;
        if (board[row][col] != word[wordIdx]) return false;

        char tmp = board[row][col];
        board[row][col] = '\0';
        bool result = Solve(board, word, row - 1, col, wordIdx + 1) ||
                      Solve(board, word, row + 1, col, wordIdx + 1) ||
                      Solve(board, word, row, col - 1, wordIdx + 1) ||
                      Solve(board, word, row, col + 1, wordIdx + 1);

        board[row][col] = tmp;
        return result;
    }
}