public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        SegmentTree tree = new SegmentTree(n);
        Dictionary<int, int> first = new();

        int ans = 0;
        for (int l = n - 1; l >= 0; l--)
        {
            int num = nums[l];

            if (first.ContainsKey(num))
            {
                tree.Update(first[num], 0);
            }

            first[num] = l;
            tree.Update(l, (num % 2 == 0) ? 1 : -1);

            int r = tree.FindMostRightPrefix(0);
            if (r >= l)
                ans = Math.Max(ans, r - l + 1);
        }

        return ans;
    }
}

public class SegmentTree
{
    public int n;
    public int size;
    public int[] sum;
    public int[] mins;
    public int[] maxs;

    public SegmentTree(int n_)
    {
        n = n_;
        size = n * 4;
        sum = new int[size];
        mins = new int[size];
        maxs = new int[size];
    }

    void Pull(int node)
    {
        int l = node * 2, r = node * 2 + 1;

        sum[node] = sum[l] + sum[r];
        mins[node] = Math.Min(mins[l], sum[l] + mins[r]);
        maxs[node] = Math.Max(maxs[l], sum[l] + maxs[r]);
    }

    public void Update(int idx, int val)
    {
        int node = 1, l = 0, r = n - 1;
        int[] path = new int[32];
        int p = 0;

        while (l != r)
        {
            path[p++] = node;
            int m = (l + r) / 2;
            if (idx <= m)
            {
                node *= 2;
                r = m;
            }
            else
            {
                node = node * 2 + 1;
                l = m + 1;
            }
        }

        sum[node] = val;
        mins[node] = val;
        maxs[node] = val;

        while (p > 0)
        {
            Pull(path[--p]);
        }
    }

    public int FindMostRightPrefix(int target)
    {
        int node = 1, l = 0, r = n - 1, sumBef = 0;

        if (mins[node] > target - sumBef || target - sumBef > maxs[node])
            return -1;

        while (l != r)
        {
            int m = (r + l) / 2;
            int lChild = node * 2, rChild = node * 2 + 1;

            int sumBefR = sum[lChild] + sumBef;
            int needR = target - sumBefR;

            if (mins[rChild] <= needR && needR <= maxs[rChild])
            {
                node = rChild;
                l = m + 1;
                sumBef = sumBefR;
            }
            else
            {
                node = lChild;
                r = m;
            }
        }

        return l;
    }
}