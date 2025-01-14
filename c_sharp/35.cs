public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int startIdx = 0, endIdx = nums.Length - 1;
        while (startIdx <= endIdx)
        {
            int midIdx = (startIdx + endIdx) / 2;
            if (nums[midIdx] == target) return midIdx;
            else if (nums[midIdx] > target) endIdx = midIdx - 1;
            else startIdx = midIdx + 1;
        }
        return startIdx;
    }
}