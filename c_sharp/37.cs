public class Solution
{
    private bool isValid = false;
    private readonly int[] rows = new int[9];
    private readonly int[] cols = new int[9];
    private readonly int[] boxs = new int[9];
    private int[][] emptyCellsArray;
    private int emptyCellsCount;
    public void SolveSudoku(char[][] board)
    {
        int n = board.Length;
        List<int[]> emptyCells = new();
        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (board[r][c] == '.')
                {
                    emptyCells.Add([r, c]);
                }
                else
                {
                    int boxIdx = r / 3 * 3 + c / 3;
                    int num = board[r][c] - '1';
                    int pos = 1 << num;
                    rows[r] |= pos;
                    cols[c] |= pos;
                    boxs[boxIdx] |= pos;
                }
            }
        }
        emptyCellsArray = emptyCells.ToArray();
        emptyCellsCount = emptyCells.Count;
        Backtracking(board, 0);
    }

    private void Backtracking(char[][] board, int emptyCellIdx)
    {
        if (emptyCellIdx == emptyCellsCount)
        {
            isValid = true;
            return;
        }
        int r = emptyCellsArray[emptyCellIdx][0];
        int c = emptyCellsArray[emptyCellIdx][1];
        if (board[r][c] != '.')
        {
            Backtracking(board, emptyCellIdx + 1);
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                int pos = 1 << i;
                int boxIdx = r / 3 * 3 + c / 3;
                if ((rows[r] & pos) == 0 && (cols[c] & pos) == 0 && (boxs[boxIdx] & pos) == 0)
                {
                    rows[r] |= pos;
                    cols[c] |= pos;
                    boxs[boxIdx] |= pos;

                    board[r][c] = (char)(i + '1');
                    Backtracking(board, emptyCellIdx + 1);

                    if (isValid) return;
                    rows[r] -= pos;
                    cols[c] -= pos;
                    boxs[boxIdx] -= pos;
                    board[r][c] = '.';
                }
            }
        }
    }
}