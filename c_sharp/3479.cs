public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        int sn = (int)Math.Sqrt(n);
        int nPart = (n + sn - 1) / sn;
        int ans = 0;
        int[] maxVal = new int[nPart];
        Array.Fill(maxVal, 0);

        for (int i = 0; i < n; i++)
        {
            maxVal[i / sn] = Math.Max(maxVal[i / sn], baskets[i]);
        }

        foreach (var fruit in fruits)
        {
            int part;
            int unplaced = 1;
            for (part = 0; part < nPart; part++)
            {
                if (maxVal[part] < fruit)
                    continue;

                int choose = 0;
                maxVal[part] = 0;
                for (int i = 0; i < sn; i++)
                {
                    int pos = part * sn + i;
                    if (pos < n && baskets[pos] >= fruit && choose == 0)
                    {
                        baskets[pos] = 0;
                        choose = 1;
                    }
                    if (pos < n)
                        maxVal[part] = Math.Max(maxVal[part], baskets[pos]);
                }
                unplaced = 0;
                break;
            }
            ans += unplaced;
        }
        return ans;
    }
}

public class Solution2
{
    private int[] segTree;
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        segTree = new int[4 * n];
        Build(baskets, 0, 0, n - 1);
        int ans = 0;
        foreach (int fruit in fruits)
        {
            if (!FindBasket(0, 0, n - 1, fruit))
                ++ans;
        }

        return ans;
    }

    private void Build(int[] baskets, int idx, int low, int high)
    {
        if (low == high)
        {
            segTree[idx] = baskets[low];
            return;
        }

        int mid = (low + high) / 2;

        Build(baskets, 2 * idx + 1, low, mid);
        Build(baskets, 2 * idx + 2, mid + 1, high);

        segTree[idx] = Math.Max(segTree[2 * idx + 1], segTree[2 * idx + 2]);
    }

    private bool FindBasket(int idx, int low, int high, int k)
    {
        if (segTree[idx] < k)
            return false;
        if (low == high)
        {
            segTree[idx] = 0;
            return true;
        }

        int mid = (low + high) / 2;
        bool found;

        if (segTree[2 * idx + 1] >= k)
            found = FindBasket(2 * idx + 1, low, mid, k);
        else
            found = FindBasket(2 * idx + 2, mid + 1, high, k);

        segTree[idx] = Math.Max(segTree[2 * idx + 1], segTree[2 * idx + 2]);

        return found;

    }
}