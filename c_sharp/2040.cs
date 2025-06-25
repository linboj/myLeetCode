public class Solution
{
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        int pos1 = 0, pos2 = 0;
        while (pos1 < n1 && nums1[pos1] < 0)
        {
            pos1++;
        }
        while (pos2 < n2 && nums2[pos2] < 0)
        {
            pos2++;
        }

        long left = -10_000_000_000L, right = 10_000_000_000L;
        while (left <= right)
        {
            long mid = (left + right) / 2;
            long count = 0;
            // num1 (-) num2 (-)
            int i1 = 0, i2 = pos2 - 1;
            while (i1 < pos1 && i2 >= 0)
            {
                if ((long)nums1[i1] * nums2[i2] > mid)
                {
                    i1++;
                }
                else
                {
                    count += pos1 - i1;
                    i2--;
                }
            }
            // num1 (+) num2 (-)
            i1 = pos1;
            i2 = 0;
            while (i1 < n1 && i2 < pos2)
            {
                if ((long)nums1[i1] * nums2[i2] > mid)
                {
                    i1++;
                }
                else
                {
                    count += n1 - i1;
                    i2++;
                }
            }
            // num1 (-) num2 (+)
            i1 = 0;
            i2 = pos2;
            while (i1 < pos1 && i2 < n2)
            {
                if ((long)nums1[i1] * nums2[i2] > mid)
                {
                    i2++;
                }
                else
                {
                    count += n2 - i2;
                    i1++;
                }
            }
            // num1 (+) num2 (+)
            i1 = n1 - 1;
            i2 = pos2;
            while (i1 >= pos1 && i2 < n2)
            {
                if ((long)nums1[i1] * nums2[i2] > mid)
                {
                    i1--;
                }
                else
                {
                    count += i1 - pos1 + 1;
                    i2++;
                }
            }
            if (count < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return left;
    }
}