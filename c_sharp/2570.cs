public class Solution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        List<int[]> ans = new();
        int idx1 = 0, idx2 = 0;

        while (idx1 < n1 && idx2 < n2)
        {
            if (nums1[idx1][0] == nums2[idx2][0])
                ans.Add([nums1[idx1][0], nums1[idx1++][1] + nums2[idx2++][1]]);
            else if (nums1[idx1][0] > nums2[idx2][0])
                ans.Add(nums2[idx2++]);
            else
                ans.Add(nums1[idx1++]);
        }

        while (idx1 < n1)
        {
            ans.Add(nums1[idx1++]);
        }

        while (idx2 < n2)
        {
            ans.Add(nums2[idx2++]);
        }

        return ans.ToArray();
    }
}