public class Solution
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        int n = nums.Length;
        PriorityQueue<int, int> pq = new();
        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(i, nums[i]);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }
        int[] ans = new int[k];
        int curr = 0;
        while (pq.Count > 0)
        {
            ans[curr++] = pq.Dequeue();
        }
        Array.Sort(ans);
        for (int i = 0; i < k; i++)
        {
            ans[i] = nums[ans[i]];
        }
        return ans;
    }
}

public class Solution2
{
    public int[] MaxSubsequence(int[] nums, int k)
    {
        int n = nums.Length;
        int[][] vals = new int[n][];
        for (int i = 0; i < n; i++)
        {
            vals[i] = new int[] { i, nums[i] };
        }
        Array.Sort(vals, (a, b) => b[1].CompareTo(a[1]));
        Array.Sort<int[]>(vals, 0, k, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));
        int[] ans = new int[k];
        for (int i = 0; i < k; i++)
        {
            ans[i] = vals[i][1];
        }


        return ans;
    }
}