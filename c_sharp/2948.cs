public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        int n = nums.Length;
        int[] sorted = new int[n];
        for (int i = 0; i < n; i++)
        {
            sorted[i] = nums[i];
        }
        Array.Sort(sorted);
        int currentGroup = 0;
        Dictionary<int, int> numsToGroup = new();
        Dictionary<int, Queue<int>> groups = new();
        numsToGroup.Add(sorted[0], currentGroup);
        groups.Add(currentGroup, new Queue<int>());
        groups[currentGroup].Enqueue(sorted[0]);

        for (int i = 1; i < n; i++)
        {
            if (sorted[i] - sorted[i - 1] > limit)
            {
                currentGroup++;
            }
            if (!numsToGroup.ContainsKey(sorted[i]))
            {
                numsToGroup.Add(sorted[i], currentGroup);
            }

            if (!groups.ContainsKey(currentGroup))
            {
                groups.Add(currentGroup, new Queue<int>());
            }
            groups[currentGroup].Enqueue(sorted[i]);
        }

        for (int i = 0; i < n; i++)
        {
            int belong = numsToGroup[nums[i]];
            nums[i] = groups[belong].Dequeue();
        }

        return nums;
    }
}