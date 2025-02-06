public class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        Dictionary<int, int> productCounts = new();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                int product = nums[i] * nums[j];
                if (productCounts.ContainsKey(product))
                    productCounts[product]++;
                else
                    productCounts[product] = 1;
            }
        }

        int ans = 0;
        foreach (var (_, count) in productCounts)
        {
            ans += 8 * count * (count - 1) / 2;
        }
        return ans;
    }
}