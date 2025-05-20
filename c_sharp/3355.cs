public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length, sum = 0, k = 0;
        int[] diffArray = new int[n + 1];

        for (int idx = 0; idx < n; idx++)
        {
            while (sum + diffArray[idx] < nums[idx])
            {
                k++;
                if (k > queries.Length) return false;
                int left = queries[k - 1][0], right = queries[k - 1][1];
                if (right >= idx)
                {
                    diffArray[Math.Max(left, idx)]++;
                    diffArray[right + 1]--;
                }
            }
            sum += diffArray[idx];
        }
        return true;
    }
}

public class Solution
{
    public bool IsZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length, sum = 0;
        int[] diffArray = new int[n + 1];

        foreach (var query in queries)
        {
            diffArray[query[0]]++;
            diffArray[query[1] + 1]--;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            sum += diffArray[i];
            if (sum < nums[i])
                return false;
        }
        return true;
    }
}