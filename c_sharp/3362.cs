public class Solution
{
    public int MaxRemoval(int[] nums, int[][] queries)
    {
        int n = nums.Length, m = queries.Length;
        Array.Sort(queries, (a, b) => a[0] - b[0]);
        PriorityQueue<int, int> pq = new();

        int[] diffArray = new int[n + 1];
        int ops = 0;

        for (int i = 0, j = 0; i < n; i++)
        {
            ops += diffArray[i];
            while (j < m && queries[j][0] == i)
            {
                int end = queries[j++][1];
                pq.Enqueue(end, -end);
            }

            while (ops < nums[i] && pq.Count > 0 && pq.Peek() >= i)
            {
                ops++;
                diffArray[pq.Dequeue() + 1]--;
            }

            if (ops < nums[i])
                return -1;
        }

        return pq.Count;
    }
}