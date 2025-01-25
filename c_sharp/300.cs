public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return n;
        int[] dp = new int[nums.Length];
        Array.Fill(dp, 1);

        int max = 1;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j] && dp[i] <= dp[j])
                {
                    dp[i] = dp[j]+1;
                    max = Math.Max(max, dp[i]);
                }
            }
        }
        return max;
    }
}

public class Solution2
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return n;

        List<int> list = new List<int>(n);
        foreach (var num in nums)
        {
            if (list.Count == 0 || list[list.Count-1] < num){
                list.Add(num);
            }else{
                var idx = list.BinarySearch(num);

                if (idx < 0) idx = ~idx;
                list[idx] = num;
            }
        }
        return list.Count;
    }
}