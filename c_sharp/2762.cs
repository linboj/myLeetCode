public class Solution
{
    public long ContinuousSubarrays(int[] nums)
    {
        // Priority Queue
        /*
        int left = 0, right = 0;
        long count = 0L;

        var minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        while (right < nums.Length)
        {
            minHeap.Enqueue(right, nums[right]);
            maxHeap.Enqueue(right, nums[right]);

            while (left < right && nums[maxHeap.Peek()] - nums[minHeap.Peek()] > 2)
            {
                left++;
                while (maxHeap.Count > 0 && maxHeap.Peek() < left) maxHeap.Dequeue();
                while (minHeap.Count > 0 && minHeap.Peek() < left) minHeap.Dequeue();
            }

            count += right - left + 1;
            right++;
        }
        return count;
        */

        // Optimized Two Pointer
        int right = 0, left = 0;
        int curMin, curMax;
        long windowLen = 0, count = 0;

        curMax = curMin = nums[right];
        for (right = 0; right < nums.Length; right++)
        {
            curMin = Math.Min(curMin, nums[right]);
            curMax = Math.Max(curMax, nums[right]);

            if (curMax - curMin > 2)
            {
                windowLen = right - left;
                count += windowLen * (windowLen + 1) / 2;

                left = right;
                curMin = curMax = nums[right];

                while (left > 0 && Math.Abs(nums[right] - nums[left - 1]) <= 2)
                {
                    left--;
                    curMin = Math.Min(curMin, nums[left]);
                    curMax = Math.Max(curMax, nums[left]);
                }

                if (left < right)
                {
                    windowLen = right - left;
                    count -= windowLen * (windowLen + 1) / 2;
                }
            }
        }
        windowLen = right - left;
        count += windowLen * (windowLen + 1) / 2;

        return count;
    }
}