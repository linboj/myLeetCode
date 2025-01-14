public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        int startIdx = 0, endIdx = nums.Length - 1;
        while (endIdx - startIdx > 1)
        {
            int midIdx = (startIdx + endIdx) / 2;
            if (nums[midIdx] > nums[midIdx + 1]) endIdx = midIdx;
            else startIdx = midIdx;
        }
        return nums[startIdx] > nums[endIdx] ? startIdx : endIdx;
    }
}