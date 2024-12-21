public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> ans = new List<IList<int>>();
        Array.Sort(nums);
        for (int s = 0; s < nums.Length - 2; s++)
        {
            if (nums[s] > 0) break;

            if (s > 0 && nums[s - 1] == nums[s]) continue;

            int left = s + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int current = nums[left] + nums[right] + nums[s];
                if (current < 0)
                    left++;
                else if (current > 0)
                    right--;
                else
                {
                    ans.Add(new List<int> { nums[s], nums[left++], nums[right--] });

                    while (left < right && nums[left - 1] == nums[left]) left++;
                }
            }
        }

        return ans;
    }
}