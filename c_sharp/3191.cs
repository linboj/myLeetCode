public class Solution {
    // use slide window
    public int MinOperations(int[] nums) {
        int count = 0;

        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i-2] == 0){
                count++;
                nums[i-2] ^= 1;
                nums[i-1] ^= 1;
                nums[i] ^= 1;
            }
        }

        int sum = 0;
        foreach (var num in nums)
            sum += num;
        if (sum == nums.Length) return count;
        return -1;
        
    }
}

public class Solution2 {
    // greedy and Bit Manipulation
    public int MinOperations(int[] nums) {
        int count = 0;
        int n = nums.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0){
                count++;
                nums[i+1] ^= 1;
                nums[i+2] ^= 1;
            }
        }

        return (nums[n-1] == 1 && nums[n-2] == 1) ? count : -1;
    }
}