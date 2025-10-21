public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        int maxVal = nums[0];
        foreach (var num in nums)
        {
            maxVal = Math.Max(maxVal, num);
        }
        maxVal += 2;
        int[] count = new int[maxVal];

        foreach (var num in nums)
        {
            count[num]++;
        }

        for (int i = 1; i < maxVal; i++)
        {
            count[i] += count[i - 1];
        }

        int ans = 0;

        for (int i = 0; i < maxVal; i++)
        {
            int left = Math.Max(0, i - k);
            int right = Math.Min(maxVal - 1, i + k);
            int total = count[right] - (left > 0 ? count[left - 1] : 0);
            int freq = count[i] - (i > 0 ? count[i - 1] : 0);
            ans = Math.Max(ans, freq + Math.Min(numOperations, total - freq));
        }
        return ans;
    }
}