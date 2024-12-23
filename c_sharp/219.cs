public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        HashSet<int> hashset = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int val = nums[i];
            if (hashset.Contains(val)) return true;
            hashset.Add(val);
            if (hashset.Count > k) hashset.Remove(nums[i - k]);
        }
        return false;
    }
}