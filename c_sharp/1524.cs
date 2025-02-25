public class Solution
{
    public int NumOfSubarrays(int[] arr)
    {
        int mod = (int)Math.Pow(10, 9) + 7;
        int prefixSum = 0;
        int oddCounts = 0, evenCounts = 0, ans = 0;
        foreach (var num in arr)
        {
            prefixSum += num;
            if ((prefixSum & 1) == 1)
            {
                oddCounts++;
                ans += evenCounts + 1;
            }
            else
            {
                evenCounts++;
                ans += oddCounts;
            }
            ans %= mod;
        }
        return ans;

    }
}
