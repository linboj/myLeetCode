public class Solution
{
    private int[] seg;
    public IList<bool> GetResults(int[][] queries)
    {
        int mx = 50_000;
        seg = new int[mx * 4];
        SortedSet<int> st = new SortedSet<int> { 0, mx };
        Update(mx, mx, 1, 0, mx);
        var ans = new List<bool>();

        foreach (var q in queries)
        {
            if (q[0] == 1)
            {
                int x = q[1];
                int r = st.GetViewBetween(x + 1, int.MaxValue).Min;
                int l = st.GetViewBetween(int.MinValue, x - 1).Max;
                Update(x, x - l, 1, 0, mx);
                Update(r, r - x, 1, 0, mx);
                st.Add(x);
            }
            else
            {
                int x = q[1];
                int sz = q[2];
                int pre = st.GetViewBetween(int.MinValue, x).Max;
                int maxSpace = Query(0, pre, 1, 0, mx);
                maxSpace = Math.Max(maxSpace, x - pre);
                ans.Add(maxSpace >= sz);
            }
        }

        return ans;
    }

    private void Update(int idx, int val, int p, int l, int r)
    {
        if (l == r)
        {
            seg[p] = val;
            return;
        }

        int mid = (l + r) / 2;
        if (idx <= mid)
        {
            Update(idx, val, p * 2, l, mid);
        }
        else
        {
            Update(idx, val, p * 2 + 1, mid + 1, r);
        }

        seg[p] = Math.Max(seg[p * 2], seg[p * 2 + 1]);
    }

    private int Query(int L, int R, int p, int l, int r)
    {
        if (l >= L && r <= R)
        {
            return seg[p];
        }

        int mid = (l + r) / 2;
        int ans = 0;
        if (L <= mid)
        {
            ans = Math.Max(ans, Query(L, R, p * 2, l, mid));
        }
        if (R > mid)
        {
            ans = Math.Max(ans, Query(L, R, p * 2 + 1, mid + 1, r));
        }
        return ans;
    }
}