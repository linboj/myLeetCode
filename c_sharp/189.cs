public class Solution
{
    public void Rotate(int[] nums, int k)
    {

        // used additional memory
        /*
        if (k == 0) return;
        if (k > nums.Length) k %= nums.Length;
        int[] temp = nums[^k..];
        for (int i = nums.Length - 1; i >= k; i--)
        {
            nums[i] = nums[i-k];
        }
        for (int i = 0; i < temp.Length; i++)
        {
            nums[i] = temp[i];     
        }
        */

        // use reverse
        k = k % nums.Length;
        reverse(nums, 0, nums.Length - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, nums.Length - 1);


    }
    private void reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            (nums[start], nums[end]) = (nums[end], nums[start]);
            start++;
            end--;
        }
    }
}