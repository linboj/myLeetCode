public class Solution
{
    public int CountServers(int[][] grid)
    {
        int nRow = grid.Length, nCol = grid[0].Length;
        var countInRow = new HashSet<int>[nRow];
        var countInCol = new HashSet<int>[nCol];
        for (int i = 0; i < nRow; i++)
        {
            countInRow[i] = new HashSet<int>();
        }
        for (int i = 0; i < nCol; i++)
        {
            countInCol[i] = new HashSet<int>();
        }
        for (int r = 0; r < nRow; r++)
        {
            for (int c = 0; c < nCol; c++)
            {
                if (grid[r][c] == 1)
                {
                    int idx = r * nCol + c;
                    countInRow[r].Add(idx);
                    countInCol[c].Add(idx);
                }
            }
        }
        var cellSet = new HashSet<int>();
        foreach (var count in countInRow)
        {
            if (count.Count >= 2)
            {
                cellSet.UnionWith(count);
            }
        }
        foreach (var count in countInCol)
        {
            if (count.Count >= 2)
            {
                cellSet.UnionWith(count);
            }
        }
        return cellSet.Count;
    }
}

public class Solution2
{
    public int CountServers(int[][] grid)
    {
        int nRow = grid.Length, nCol = grid[0].Length;
        int ans = 0;
        int[] countInCol = new int[nCol], lastServerInCol = new int[nRow];
        Array.Fill(lastServerInCol, -1);
        
        for (int row = 0; row < nRow; row++)
        {
            int countInRow = 0;
            for (int col = 0; col < nCol; col++)
            {
                if (grid[row][col] == 1)
                {
                    countInRow++;
                    countInCol[col]++;
                    lastServerInCol[row] = col;
                }
            }
            if (countInRow > 1)
            {
                ans += countInRow;
                lastServerInCol[row] = -1;
            }
        }

        for (int row = 0; row < nRow; row++)
        {
            if (lastServerInCol[row] != -1 && countInCol[lastServerInCol[row]] > 1){
                ans++;
            }
        }
        return ans;

    }
}