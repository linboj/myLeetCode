public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int len = arr.Length;
        HashSet<int> nums = new(arr);
        int max = 0;

        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j < len - 1; j++)
            {
                int current = arr[j];
                int target = arr[i] + current;
                int count = 0;
                if (target > arr[len - 1]) break;
                while (nums.Contains(target))
                {
                    count++;
                    (current, target) = (target, current + target);
                }
                if (count > 0)
                    max = Math.Max(max, count + 2);
            }
        }
        return max;
    }
}

public class Solution2
{
    public int LenLongestFibSubseq(int[] arr)
    {
        int len = arr.Length;
        int[,] dp = new int[len, len];
        int max = 0;

        for (int curr = 2; curr < len; curr++)
        {
            int start = 0;
            int end = curr - 1;

            while (start < end)
            {
                int sum = arr[start] + arr[end];

                if (sum > arr[curr])
                {
                    end--;
                }
                else if (sum < arr[curr])
                {
                    start++;
                }
                else
                {
                    dp[end, curr] = dp[start, end] + 1;
                    max = Math.Max(max, dp[end, curr]);
                    end--;
                    start++;
                }
            }
        }
        return max == 0 ? 0 : max + 2;
    }
}