public class Solution
{
    // Hash map
    public int MinOperations(int[] nums, int k)
    {
        int[] counts = new int[100];

        foreach (int num in nums)
        {
            counts[num - 1]++;
        }

        for (int i = 0; i < k - 1; i++)
        {
            if (counts[i] > 0) return -1;
        }

        int ans = 0;
        for (int i = k - 1; i < 100; i++)
        {
            if (counts[i] > 0)
                ans++;
        }
        if (counts[k - 1] != 0) ans--;

        return ans;
    }
}

public class Solution
{
    // Hash set
    public int MinOperations(int[] nums, int k)
    {
        HashSet<int> seen = new();

        foreach (int num in nums)
        {
            if (num < k)
                return -1;
            else if (num > k)
                seen.Add(num);
        }

        return seen.Count;
    }
}