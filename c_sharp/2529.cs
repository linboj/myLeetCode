public class Solution
{
    public int MaximumCount(int[] nums)
    {
        int posCount = 0, negCount = 0;

        foreach (int num in nums)
        {
            if (num > 0)
                posCount++;
            else if (num < 0)
                negCount++;
        }
        return Math.Max(posCount, negCount);
    }
}

public class Solution2
{
    public int MaximumCount(int[] nums)
    {
        int n = nums.Length;
        if (nums[0] > 0 || nums[^1] < 0) return n;

        int negL = 0, negR = n - 1, negIdx = n;
        while (negL <= negR)
        {
            int mid = (negR + negL) / 2;
            if (nums[mid] < 0)
                negL = mid + 1;
            else if (nums[mid] >= 0)
            {
                negR = mid - 1;
                negIdx = mid;
            }
        }
        int posL = 0, posR = n - 1, posIdx = n;
        while (posL <= posR)
        {
            int mid = (posR + posL) / 2;
            if (nums[mid] <= 0)
                posL = mid + 1;
            else if (nums[mid] >= 0)
            {
                posR = mid - 1;
                posIdx = mid;
            }
        }
        return Math.Max(negIdx, n - posIdx);
    }
}