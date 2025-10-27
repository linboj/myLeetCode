public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int ans = 0;
        int prev = 0;

        foreach (var row in bank)
        {
            int current = 0;
            foreach (var cell in row)
            {
                current += cell - '0';
            }

            if (current > 0)
            {
                ans += prev * current;
                prev = current;
            }
        }
        return ans;
    }
}