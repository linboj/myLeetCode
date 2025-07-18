public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        int n3 = nums.Length;
        int n = n3 / 3;
        long[] part1 = new long[n + 1];
        long sum = 0;
        PriorityQueue<int, int> maxHeap = new(Comparer<int>.Create((a, b) => b - a));
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            sum += num;
            maxHeap.Enqueue(num, num);
        }

        part1[0] = sum;
        for (int i = n; i < 2 * n; i++)
        {
            int num = nums[i];
            sum += num;
            maxHeap.Enqueue(num, num);
            sum -= maxHeap.Dequeue();
            part1[i - (n - 1)] = sum;
        }

        long part2 = 0;
        PriorityQueue<int, int> minHeap = new();
        for (int i = 3 * n - 1; i >= 2 * n; i--)
        {
            int num = nums[i];
            part2 += num;
            minHeap.Enqueue(num, num);
        }

        long ans = part1[n] - part2;
        for (int i = 2 * n - 1; i >= n; i--)
        {
            int num = nums[i];
            part2 += num;
            minHeap.Enqueue(num, num);
            part2 -= minHeap.Dequeue();
            ans = Math.Min(ans, part1[i - n] - part2);
        }
        return ans;
    }
}