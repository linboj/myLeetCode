public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        List<int[]> events = new();
        SortedSet<int> xsSet = new();

        foreach (var square in squares)
        {
            int x = square[0];
            int y = square[1];
            int l = square[2];
            int xr = x + l;
            events.Add([y, 1, x, xr]);
            events.Add([y + l, -1, x, xr]);
            xsSet.Add(x);
            xsSet.Add(xr);
        }

        events.Sort((a, b) => a[0].CompareTo(b[0]));
        int[] xs = xsSet.ToArray();
        SegmentTree segmentTree = new(xs);

        List<long> pSum = new();
        List<int> widths = new();
        long totalArea = 0;
        int prev = events[0][0];

        foreach (var e in events)
        {
            int y = e[0], delta = e[1], xl = e[2], xr = e[3];
            int len = segmentTree.Query();
            totalArea += (long)len * (y - prev);
            segmentTree.Update(xl, xr, delta);
            pSum.Add(totalArea);
            widths.Add(segmentTree.Query());
            prev = y;
        }

        long targetArea = (totalArea + 1) / 2;

        int idx = BinarySearch(pSum, targetArea);

        double area = pSum[idx];
        int width = widths[idx], height = events[idx][0];

        return height + (totalArea - area * 2) / (width * 2.0);
    }

    private int BinarySearch(List<long> list, long target)
    {
        int left = 0;
        int right = list.Count - 1;
        int result = 0;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (list[mid] < target)
            {
                result = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }

    class SegmentTree
    {
        private int[] counts;
        private int[] covereds;
        private int[] xs;
        private int n;

        public SegmentTree(int[] xs_)
        {
            xs = xs_;
            n = xs_.Length - 1;
            counts = new int[4 * n];
            covereds = new int[4 * n];
        }

        private void Modify(int ql, int qr, int qv, int l, int r, int pos)
        {
            if (xs[r + 1] <= ql || xs[l] >= qr)
                return;

            if (ql <= xs[l] && xs[r + 1] <= qr)
            {
                counts[pos] += qv;
            }
            else
            {
                int mid = (l + r) / 2;
                Modify(ql, qr, qv, l, mid, pos * 2 + 1);
                Modify(ql, qr, qv, mid + 1, r, pos * 2 + 2);
            }

            if (counts[pos] > 0)
            {
                covereds[pos] = xs[r + 1] - xs[l];
            }
            else
            {
                if (l == r)
                    covereds[pos] = 0;
                else
                    covereds[pos] = covereds[pos * 2 + 1] + covereds[pos * 2 + 2];
            }
        }

        public void Update(int ql, int qr, int qv)
        {
            Modify(ql, qr, qv, 0, n - 1, 0);
        }

        public int Query()
        {
            return covereds[0];
        }
    }
}