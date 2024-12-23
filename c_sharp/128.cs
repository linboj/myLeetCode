public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        HashSet<int> hashset = new(nums);

        int ans = 0;
        foreach (int num in hashset)
        {
            if (hashset.Contains(num - 1)) continue;

            int counter = 1;
            while (hashset.Contains(num + counter)) counter++;

            ans = Math.Max(counter, ans);
        }

        return ans;
    }
}