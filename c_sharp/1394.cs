public class Solution
{
    public int FindLucky(int[] arr)
    {
        Dictionary<int, int> freq = new();
        foreach (var num in arr)
        {
            freq.TryGetValue(num, out int count);
            freq[num] = count + 1;
        }
        int ans = -1;
        foreach (var (num, count) in freq)
        {
            if (count == num && num > ans)
                ans = num;
        }
        return ans;
    }
}

public class Solution2
{
    public int FindLucky(int[] arr)
    {
        int[] freq = new int[501];
        foreach (var num in arr)
        {
            freq[num]++;
        }
        int ans = -1;
        for (int i = 1; i <= 500; i++)
        {
            if (freq[i] == i && i > ans)
                ans = i;
        }
        return ans;
    }
}