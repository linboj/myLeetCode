public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        int ans = 0;
        Dictionary<int, int> counts = new();
        foreach (var domino in dominoes)
        {
            int key = 0;
            if (domino[0] >= domino[1])
                key = domino[1] * 10 + domino[0];
            else
                key = domino[0] * 10 + domino[1];
            if (!counts.ContainsKey(key))
                counts[key] = 0;
            counts[key]++;
        }

        foreach (var (_, val) in counts)
        {
            if (val > 1)
            {
                ans += val * (val - 1) / 2;
            }
        }

        return ans;
    }
}

public class Solution2
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        int ans = 0;
        int[] counts = new int[100];
        foreach (var domino in dominoes)
        {
            int a = Math.Min(domino[0], domino[1]);
            int b = Math.Max(domino[0], domino[1]);
            int key = a * 10 + b;
            ans += counts[key];
            counts[key]++;
        }

        return ans;
    }
}