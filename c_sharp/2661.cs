public class Solution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        Tuple<int, int>[] hashMap = new Tuple<int, int>[n * m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                hashMap[mat[i][j] - 1] = new Tuple<int, int>(i, j);
            }
        }
        int[] rowCount = new int[n];
        int[] colCount = new int[m];

        for (int i = 0; i < arr.Length; i++)
        {
            var (r, c) = hashMap[arr[i] - 1];
            rowCount[r]++;
            if (rowCount[r] == m) return i;
            colCount[c]++;
            if (colCount[c] == n) return i;
        }
        return n * m - 1;
    }
}

public class Solution2
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        int n = mat.Length, m = mat[0].Length;
        int[] hashMap = new int[n * m];
        for (int i = 0; i < arr.Length; i++)
        {
            hashMap[arr[i] - 1] = i;
        }
        int result = n * m;
        for (int i = 0; i < n; i++)
        {
            int lastElementIdx = -1;
            for (int j = 0;j < m; j++){
                lastElementIdx = Math.Max(lastElementIdx, hashMap[mat[i][j]-1]);
            }
            result = Math.Min(result, lastElementIdx);
        }
        for (int i = 0; i < n; i++)
        {
            int lastElementIdx = -1;
            for (int j = 0;j < m; j++){
                lastElementIdx = Math.Max(lastElementIdx, hashMap[mat[j][i]-1]);
            }
            result = Math.Min(result, lastElementIdx);
        }
        return result;
    }
}