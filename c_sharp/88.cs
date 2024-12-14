public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int totalLen = m + n - 1;
        int l1 = m - 1, l2 = n - 1;

        while (l1 >= 0 && l2 >= 0)
        {
            if (nums1[l1] > nums2[l2])
            {
                nums1[totalLen] = nums1[l1];
                nums1[l1] = 0;
                l1--;
            }
            else
            {
                nums1[totalLen] = nums2[l2];
                l2--;
            }
            totalLen--;
        }

        while (l2 >= 0)
        {
            nums1[totalLen--] = nums2[l2--];
        }
    }
}