public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        int idx1 = 0, idx2 = 0;

        while (idx1 < n1 && idx2 < n2)
        {
            if (nums1[idx1] == nums2[idx2])
                return nums1[idx1];
            else if (nums1[idx1] > nums2[idx2])
                idx2++;
            else
                idx1++;
        }

        return -1;
    }
}