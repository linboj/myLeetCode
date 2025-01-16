public class Solution
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length;
        int n2 = nums2.Length;

        int nums1XOR = 0;
        int nums2XOR = 0;

        if (n2 % 2 == 1)
        {
            foreach (var item in nums1)
            {
                nums1XOR ^= item;
            }
        }

        if (n1 % 2 == 1)
        {
            foreach (var item in nums2)
            {
                nums2XOR ^= item;
            }
        }

        return nums1XOR ^ nums2XOR;
    }
}