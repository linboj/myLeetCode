public class Solution
{
    public int FindSmallestInteger(int[] nums, int value)
    {
        int[] cnts = new int[value];

        foreach (int num in nums)
        {
            int v = ((num % value) + value) % value;
            cnts[v]++;
        }

        int ans = 0;
        while (cnts[ans % value] != 0)
        {
            cnts[ans % value]--;
            ans++;
        }
        return ans;
    }
}