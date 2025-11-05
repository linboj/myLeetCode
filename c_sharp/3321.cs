public class Solution
{
    public long[] FindXSum(int[] nums, int k, int x)
    {
        int n = nums.Length;
        var helper = new Helper(x);
        long[] ans = new long[n - k + 1];

        for (int i = 0; i < n; i++)
        {
            helper.Insert(nums[i]);
            if (i >= k)
                helper.Remove(nums[i - k]);
            if (i >= k - 1)
                ans[i - k + 1] = helper.Ans();
        }
        return ans;
    }
}

class Helper
{
    private int x;
    private long ans;
    private SortedSet<(int cnt, int num)> topX;
    private SortedSet<(int cnt, int num)> outK;
    private Dictionary<int, int> occu;
    private HashSet<int> inTopX;

    public Helper(int x)
    {
        this.x = x;
        ans = 0;
        var cmp = Comparer<(int cnt, int num)>.Create((a, b) => a.cnt == b.cnt ? a.num.CompareTo(b.num) : a.cnt.CompareTo(b.cnt));
        topX = new SortedSet<(int cnt, int num)>(cmp);
        outK = new SortedSet<(int cnt, int num)>(cmp);
        occu = new();
        inTopX = new();
    }

    public void Insert(int num)
    {
        if (occu.TryGetValue(num, out var oldCnt) && oldCnt > 0)
            InternalRemove((oldCnt, num));

        int newCnt = oldCnt + 1;
        occu[num] = newCnt;
        InternalInsert((newCnt, num));
    }

    public void Remove(int num)
    {
        int cnt = occu[num];
        InternalRemove((cnt, num));
        cnt--;
        if (cnt == 0)
            occu.Remove(num);
        else
            occu[num] = cnt;

        if (cnt > 0)
        {
            InternalInsert((cnt, num));
        }
    }

    public long Ans() => ans;

    private void InternalInsert((int cnt, int num) p)
    {
        if (topX.Count < x)
        {
            topX.Add(p);
            inTopX.Add(p.num);
            ans += (long)p.num * p.cnt;
            return;
        }

        if (topX.Count > 0 && Compare(p, GetMin(topX)) > 0)
        {
            var minInTopX = GetMin(topX);
            topX.Remove(minInTopX);
            inTopX.Remove(minInTopX.num);
            ans -= (long)minInTopX.cnt * minInTopX.num;

            topX.Add(p);
            inTopX.Add(p.num);
            ans += (long)p.cnt * p.num;

            outK.Add(minInTopX);
        }
        else
        {
            outK.Add(p);
        }
    }

    private void InternalRemove((int cnt, int num) p)
    {
        if (inTopX.Contains(p.num))
        {
            if (topX.Remove(p))
            {
                inTopX.Remove(p.num);
                ans -= (long)p.num * p.cnt;
            }

            if (outK.Count > 0)
            {
                var maxInOutOfX = GetMax(outK);
                outK.Remove(maxInOutOfX);
                topX.Add(maxInOutOfX);
                inTopX.Add(maxInOutOfX.num);
                ans += (long)maxInOutOfX.num * maxInOutOfX.cnt;
            }
        }
        else
        {
            outK.Remove(p);
        }
    }

    private static (int cnt, int num) GetMin(SortedSet<(int cnt, int num)> s)
    {
        foreach (var v in s) return v;
        throw new InvalidOperationException();
    }

    private static (int cnt, int num) GetMax(SortedSet<(int cnt, int num)> s)
    {
        var it = s.Max;
        return it;
    }

    private static int Compare((int cnt, int num) a, (int cnt, int num) b) => a.cnt == b.cnt ? a.num.CompareTo(b.num) : a.cnt.CompareTo(b.cnt);
}