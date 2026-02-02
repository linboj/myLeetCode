public class Solution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        int n = nums.Length;
        Solver cnt = new Solver(k - 2);
        for (int i = 1; i < k - 1; i++)
        {
            cnt.Add(nums[i]);
        }

        long ans = cnt.Sum() + nums[k - 1];
        for (int i = k; i < n; i++)
        {
            int j = i - dist - 1;
            if (j > 0)
            {
                cnt.Erase(nums[j]);
            }
            cnt.Add(nums[i - 1]);
            ans = Math.Min(ans, cnt.Sum() + nums[i]);
        }

        return ans + nums[0];
    }
}

public class Solver
{
    private int k;
    private PriorityQueue<int, int> st1 = new();
    private PriorityQueue<int, int> st2 = new();
    private Dictionary<int, int> cnt1 = new();
    private Dictionary<int, int> cnt2 = new();
    private Dictionary<int, int> del1 = new();
    private Dictionary<int, int> del2 = new();
    private int st1Size;
    private int st2Size;
    private long sm;

    public Solver(int k)
    {
        this.k = k;
        this.st1Size = 0;
        this.st2Size = 0;
        this.sm = 0;
    }

    private static void Increase(Dictionary<int, int> dict, int key)
    {
        if (dict.TryGetValue(key, out int v))
            dict[key] = v + 1;
        else
            dict[key] = 1;
    }

    private static void Decrease(Dictionary<int, int> dict, int key)
    {
        int v = dict[key] - 1;
        if (v == 0)
            dict.Remove(key);
        else
            dict[key] = v;
    }

    private void Prune1()
    {
        while (st1.Count > 0)
        {
            int x = st1.Peek();
            if (del1.TryGetValue(x, out int d) && d > 0)
            {
                st1.Dequeue();
                if (d == 1)
                    del1.Remove(x);
                else
                    del1[x] = d - 1;
            }
            else
            {
                break;
            }
        }
    }

    private void Prune2()
    {
        while (st2.Count > 0)
        {
            int x = st2.Peek();
            if (del2.TryGetValue(x, out int d) && d > 0)
            {
                st2.Dequeue();
                if (d == 1)
                    del2.Remove(x);
                else
                    del2[x] = d - 1;
            }
            else
            {
                break;
            }
        }
    }

    private int ExtractMax1()
    {
        Prune1();
        int x = st1.Dequeue();
        Decrease(cnt1, x);
        st1Size--;
        sm -= x;
        return x;
    }

    private int ExtractMin2()
    {
        Prune2();
        int x = st2.Dequeue();
        Decrease(cnt2, x);
        st2Size--;
        return x;
    }

    private int Min2()
    {
        Prune2();
        return st2.Peek();
    }

    private void Insert1(int x)
    {
        st1.Enqueue(x, -x);
        Increase(cnt1, x);
        st1Size++;
        sm += x;
    }

    private void Insert2(int x)
    {
        st2.Enqueue(x, x);
        Increase(cnt2, x);
        st2Size++;
    }

    private void Adjust()
    {
        while (st1Size < k && st2Size > 0)
        {
            int x = ExtractMin2();
            Insert1(x);
        }
        while (st1Size > k)
        {
            int x = ExtractMax1();
            Insert2(x);
        }
    }

    public void Add(int x)
    {
        if (st2Size > 0)
        {
            int mn = Min2();
            if (x >= mn)
                Insert2(x);
            else
                Insert1(x);
        }
        else
        {
            Insert1(x);
        }
        Adjust();
    }

    public void Erase(int x)
    {
        if (cnt1.TryGetValue(x, out int c1) && c1 > 0)
        {
            Decrease(cnt1, x);
            st1Size--;
            sm -= x;
            Increase(del1, x);
        }
        else
        {
            Decrease(cnt2, x);
            st2Size--;
            Increase(del2, x);
        }
        Adjust();
    }

    public long Sum()
    {
        return sm;
    }
}