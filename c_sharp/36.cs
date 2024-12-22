public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        // Hashset
        /*
        int n = board.Length;
        HashSet<char>[] subBoxes = new HashSet<char>[n];
        HashSet<char>[] cols = new HashSet<char>[n];
        for (int i = 0; i < n; i++)
        {
            subBoxes[i] = new HashSet<char>();
            cols[i] = new HashSet<char>();
        }
        for (int i = 0; i < n; i++)
        {
            HashSet<char> localSet = new();
            for (int j = 0; j < board[i].Length; j++)
            {
                char currentChar = board[i][j];
                if (currentChar == '.')
                    continue;
                if (localSet.Contains(currentChar))
                    return false;
                else
                    localSet.Add(currentChar);
                if (cols[j].Contains(currentChar))
                    return false;
                else
                    cols[j].Add(currentChar);
                int subBoxIdx = i / 3 * 3 + j / 3;
                if (subBoxes[subBoxIdx].Contains(currentChar))
                    return false;
                else
                    subBoxes[subBoxIdx].Add(currentChar);
            }
        }
        return true;
        */

        // bit
        int n = board.Length;
        int[] rows = new int[n];
        int[] cols = new int[n];
        int[] boxs = new int[n];
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (board[row][col] == '.') continue;

                int num = board[row][col] - '1';
                int pos = 1 << num;

                if ((rows[row] & pos) > 0) return false;
                rows[row] |= pos;

                if ((cols[col] & pos) > 0) return false;
                cols[col] |= pos;

                int boxIdx = row / 3 * 3 + col / 3;
                if ((boxs[boxIdx] & pos) > 0 ) return false;
                boxs[boxIdx] |= pos;
            }
        }
        return true;
    }
}