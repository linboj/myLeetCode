public class Solution
{
    public long GoodTriplets(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int[] pos2 = new int[n], idxMap2To1 = new int[n];

        for (int i = 0; i < n; i++)
        {
            pos2[nums2[i]] = i;
        }

        for (int i = 0; i < n; i++)
        {
            idxMap2To1[pos2[nums1[i]]] = i;
        }

        FenwickTree tree = new FenwickTree(n);
        long ans = 0;
        for (int idx2 = 0; idx2 < n; idx2++)
        {
            int idx1 = idxMap2To1[idx2];
            int left = tree.Query(idx1);
            tree.Update(idx1, 1);
            int right = n - 1 - idx1 - (idx2 - left);
            ans += (long)right * left;
        }

        return ans;
    }

    public class FenwickTree
    {
        private int[] tree;

        public FenwickTree(int size)
        {
            tree = new int[size + 1];
        }

        public void Update(int idx, int delta)
        {
            idx++;

            while (idx < tree.Length)
            {
                tree[idx] += delta;
                idx += idx & -idx;
            }
        }

        public int Query(int idx)
        {
            idx++;
            int res = 0;

            while (idx > 0)
            {
                res += tree[idx];
                idx -= idx & -idx;
            }
            return res;
        }
    }
}