public class Solution
{
    public int NumRabbits(int[] answers)
    {
        int ans = 0;
        Dictionary<int, int> counts = new();

        foreach (var answer in answers)
        {
            if (!counts.ContainsKey(answer))
                counts[answer] = 0;
            counts[answer]++;
        }

        foreach (var (key, val) in counts)
        {
            ans += ((val - 1) / (key + 1) + 1) * (key + 1);
        }

        return ans;
    }
}