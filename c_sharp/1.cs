public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> hashmap = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            if (hashmap.ContainsKey(diff))
            {
                return [hashmap[diff], i];
            }
            else
            {
                if (!hashmap.ContainsKey(nums[i]))
                {
                    hashmap.Add(nums[i], i);
                }
            }
        }

        return [];
    }
}