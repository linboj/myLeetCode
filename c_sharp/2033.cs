public class Solution
{
    // Two pointers
    public int MinOperations(int[][] grid, int x)
    {
        int n = grid.Length, m = grid[0].Length;
        int length = n * m;
        int result = 0;
        int[] nums = new int[length];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if ((grid[r][c] - grid[0][0]) % x != 0) return -1;
                nums[r * m + c] = grid[r][c];
            }
        }

        Array.Sort(nums);

        int prefixIdx = 0, suffixIdx = length - 1;

        while (prefixIdx < suffixIdx)
        {
            if (prefixIdx < length - suffixIdx - 1)
            {
                int prefixOps = (prefixIdx + 1) * (nums[prefixIdx + 1] - nums[prefixIdx]) / x;
                result += prefixOps;
                prefixIdx++;
            }
            else
            {
                int suffixOps = (length - suffixIdx) * (nums[suffixIdx] - nums[suffixIdx - 1]) / x;
                result += suffixOps;
                suffixIdx--;
            }
        }
        return result;
    }
}

public class Solution2
{
    // sort and median
    public int MinOperations(int[][] grid, int x)
    {
        int n = grid.Length, m = grid[0].Length;
        int length = n * m;
        int result = 0;
        int[] nums = new int[length];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if ((grid[r][c] - grid[0][0]) % x != 0) return -1;
                nums[r * m + c] = grid[r][c];
            }
        }

        Array.Sort(nums);

        int median = nums[length / 2];

        foreach (var num in nums)
        {
            result += Math.Abs(num - median) / x;
        }

        return result;
    }
}