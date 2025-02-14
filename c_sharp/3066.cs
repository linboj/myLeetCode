public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int ans = 0;
        PriorityQueue<int, int> pq = new();

        foreach (var num in nums)
        {
            // skip the larger than k
            if (num < k)
            {
                pq.Enqueue(num, num);
            }
        }

        while (pq.Count > 1)
        {
            int min1 = pq.Dequeue();
            int min2 = pq.Dequeue();
            // if add num larger than k, passing
            if (min1 * 2 < k - min2)
            {
                int newNum = min1 * 2 + min2;
                pq.Enqueue(newNum, newNum);
            }
            ans++;
        }
        return ans + pq.Count;
    }
}