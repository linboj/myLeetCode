public class Solution
{
    public int[] ApplyOperations(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }
        }

        int nonZeroIdx = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != 0)
            {
                nums[nonZeroIdx] = nums[i];
                nonZeroIdx++;
            }
        }

        while (nonZeroIdx < n)
        {
            nums[nonZeroIdx] = 0;
            nonZeroIdx++;
        }

        return nums;
    }
}

public class Solution2
{
    public int[] ApplyOperations(int[] nums)
    {
        int n = nums.Length;
        int zeroIdx = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                nums[i] *= 2;
                nums[i + 1] = 0;
            }

            if (nums[i] != 0){
                nums[zeroIdx] = nums[i];
                if (zeroIdx != i){
                    nums[i] = 0;
                }
                zeroIdx++;
            }
        }

        if (nums[n-1] != 0 && zeroIdx != n-1){
            nums[zeroIdx] = nums[n-1];
            nums[n-1] = 0;
        }

        return nums;
    }
}