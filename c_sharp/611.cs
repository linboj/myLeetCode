public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int ans = 0;

        for (int i = 0; i < n - 2; i++)
        {
            int k = i + 2;
            for (int j = i + 1; j < n - 1 && nums[i] > 0; j++)
            {
                while (k < n && nums[i] + nums[j] > nums[k])
                    k++;

                ans += k - j - 1;
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int TriangleNumber(int[] nums)
    {
        int ans = 0;
        if (nums.Length < 3) return ans;
        Array.Sort(nums);
        int n = nums.Length;

        for (int k = n - 1; k > 1; k--)
        {
            int left = 0, right = k - 1;
            while (left < right)
            {
                if (nums[k] < nums[left] + nums[right])
                {
                    ans += right - left;
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }
        return ans;
    }
}