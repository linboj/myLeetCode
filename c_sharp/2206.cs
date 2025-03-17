public class Solution {
    public bool DivideArray(int[] nums) {
        int n = nums.Length / 2;
        int count = 0;
        Dictionary<int, int> dict = new ();
        foreach (var num in nums)
        {
            if (!dict.ContainsKey(num)) dict[num] = 0;
            dict[num]++;
            if (dict[num] % 2 == 0) count++;
        }
        return count == n;
    }
}