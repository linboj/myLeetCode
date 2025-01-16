public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        // heap
        PriorityQueue<int, int> heap = new();
        int ans = 0;
        foreach (var num in nums)
        {
            heap.Enqueue(num, -num);
        }
        for (int i = 0; i < k; i++)
        {
            var pop = heap.Dequeue();
            ans = pop;
        }
        return ans;
    }
}

public class Solution2 {
    public int FindKthLargest(int[] nums, int k) {
        // count sort
        int min = nums[0], max = nums[0];

        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }

        int[] freq = new int[max-min+1];
        foreach (var num in nums)
        {
            freq[max - num]++;
        }

        for (int i = 0; i < freq.Length;i++){
            k -= freq[i];
            if (k <= 0){
                return max - i;
            }
        }

        return -1;
    }
}
