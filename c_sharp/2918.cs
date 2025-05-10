public class Solution
{
    public long MinSum(int[] nums1, int[] nums2)
    {
        long sum1 = 0, sum2 = 0;
        int zeros1 = 0, zeros2 = 0;

        foreach (var num in nums1)
        {
            sum1 += num;
            if (num == 0)
            {
                zeros1++;
                sum1++;
            }
        }

        foreach (var num in nums2)
        {
            sum2 += num;
            if (num == 0)
            {
                zeros2++;
                sum2++;
            }
        }

        if (zeros1 + zeros2 == 0 && sum1 != sum2)
            return -1;

        if ((zeros1 == 0 && sum1 < sum2) || (zeros2 == 0 && sum1 > sum2))
            return -1;

        return Math.Max(sum1, sum2);
    }
}