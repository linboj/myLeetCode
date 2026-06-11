public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        int n = nums.Length;
        var seg = new SegTree(nums);
        var pq = new PriorityQueue<(int l, int r), int>();

        for (int l = 0; l < n; l++)
        {
            int val = seg.QueryMax(1, 0, n - 1, l, n - 1) - seg.QueryMin(1, 0, n - 1, l, n - 1);
            pq.Enqueue((l, n - 1), -val);
        }

        long ans = 0;
        while (k-- > 0)
        {
            pq.TryDequeue(out var top, out int negVal);
            ans -= negVal;
            int l = top.l, r = top.r;
            if (r > l)
            {
                int val = seg.QueryMax(1, 0, n - 1, l, r - 1) - seg.QueryMin(1, 0, n - 1, l, r - 1);
                pq.Enqueue((l, r - 1), -val);
            }
        }
        return ans;
    }
}

public class SegTree
{
    int[] maxVal, minVal;
    int n;

    public SegTree(int[] nums)
    {
        n = nums.Length;
        maxVal = new int[n * 4];
        minVal = new int[n * 4];
        Build(1, 0, n - 1, nums);
    }

    void Build(int node, int l, int r, int[] nums)
    {
        if (l == r)
        {
            maxVal[node] = minVal[node] = nums[l];
            return;
        }

        int mid = (l + r) / 2;
        Build(node * 2, l, mid, nums);
        Build(node * 2 + 1, mid + 1, r, nums);
        maxVal[node] = Math.Max(maxVal[node * 2], maxVal[node * 2 + 1]);
        minVal[node] = Math.Min(minVal[node * 2], minVal[node * 2 + 1]);
    }

    public int QueryMax(int node, int l, int r, int qL, int qR)
    {
        if (qL <= l && r <= qR)
        {
            return maxVal[node];
        }

        int mid = (l + r) / 2;
        int ans = int.MinValue;
        if (qL <= mid)
        {
            ans = Math.Max(ans, QueryMax(node * 2, l, mid, qL, qR));
        }

        if (qR > mid)
        {
            ans = Math.Max(ans, QueryMax(node * 2 + 1, mid + 1, r, qL, qR));
        }

        return ans;
    }

    public int QueryMin(int node, int l, int r, int qL, int qR)
    {
        if (qL <= l && r <= qR)
        {
            return minVal[node];
        }

        int mid = (l + r) / 2;
        int ans = int.MaxValue;

        if (qL <= mid)
        {
            ans = Math.Min(ans, QueryMin(node * 2, l, mid, qL, qR));
        }

        if (mid < qR)
        {
            ans = Math.Min(ans, QueryMin(node * 2 + 1, mid + 1, r, qL, qR));
        }

        return ans;
    }
}