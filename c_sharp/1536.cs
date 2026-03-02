public class Solution
{
    public int MinSwaps(int[][] grid)
    {
        int n = grid.Length;
        List<int> zeros = new();

        foreach (var row in grid)
        {
            int cnt = 0;
            for (int i = n - 1; i >= 0 && row[i] == 0; i--)
            {
                cnt++;
            }
            zeros.Add(cnt);
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int needed = n - i - 1;
            int j = i;
            while (j < n && zeros[j] < needed) j++;

            if (j == n) return -1;
            while (j > i)
            {
                int temp = zeros[j];
                zeros[j] = zeros[j - 1];
                zeros[j - 1] = temp;
                j--;
                ans++;
            }
        }

        return ans;
    }
}