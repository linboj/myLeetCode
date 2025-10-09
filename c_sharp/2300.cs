public class Solution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        int n = spells.Length, m = potions.Length;
        Array.Sort(potions);
        int[][] pairs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            pairs[i] = [spells[i], i];
        }
        Array.Sort(pairs, (a, b) => a[0].CompareTo(b[0]));
        int[] ans = new int[n];
        int j = m - 1;
        for (int i = 0; i < n; i++)
        {
            int spell = pairs[i][0];
            int idx = pairs[i][1];
            while (j >= 0 && (long)spell * potions[j] >= success)
                j--;
            ans[idx] = m - (j + 1);
        }
        return ans;
    }
}

public class Solution2
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        int n = spells.Length, m = potions.Length;
        Array.Sort(potions);
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int target = (int)Math.Ceiling(success / (double)spells[i]);
            ans[i] = BinarySearch(potions, target);
        }

        return ans;
    }

    private int BinarySearch(int[] array, int target)
    {
        int n = array.Length;
        int l = 0, r = n - 1, ans = n;
        while (l <= r)
        {
            int mid = (l + r) >> 1;
            if ((long)array[mid] >= target)
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
        return n - ans;
    }
}