public class Solution
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        int n = nums.Length;
        List<int> ans = new();
        int[] counts = new int[n];

        foreach (var num in nums)
        {
            counts[num]++;
            if (counts[num] > 1)
                ans.Add(num);

            if (ans.Count == 2)
                break;
        }
        return ans.ToArray();
    }
}

public class Solution2
{
    public int[] GetSneakyNumbers(int[] nums)
    {
        int n = nums.Length - 2;
        double sum = 0, sqSum = 0;

        foreach (var num in nums)
        {
            sum += num;
            sqSum += num * num;
        }

        double sum2 = sum - n * (n - 1) / 2.0;
        double sqSum2 = sqSum - n * (n - 1) * (2 * n - 1) / 6.0;
        int x1 = (int)((sum2 - Math.Sqrt(2 * sqSum2 - sum2 * sum2)) / 2);
        int x2 = (int)((sum2 + Math.Sqrt(2 * sqSum2 - sum2 * sum2)) / 2);
        return [x1, x2];
    }
}