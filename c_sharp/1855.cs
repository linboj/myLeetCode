public class Solution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int n = nums1.Length, m = nums2.Length;
        int p1 = n - 1, p2 = m - 1;

        int ans = 0;
        while (p2 >= 0)
        {
            int num2 = nums2[p2];
            if (p1 > p2)
                p1 = p2;
            while (p1 >= 0 && num2 >= nums1[p1])
            {
                ans = Math.Max(ans, p2 - p1);
                p1--;
            }
            p2--;
        }
        return ans;
    }
}