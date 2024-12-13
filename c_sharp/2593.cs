public class Solution
{
    public long FindScore(int[] nums)
    {
        bool[] marked = new bool[nums.Length];
        var compare = Comparer<(int, int)>.Create((i1, i2) => i1.Item1 == i2.Item1 ? i1.Item2.CompareTo(i2.Item2) : i1.Item1.CompareTo(i2.Item1));
        var pq = new PriorityQueue<int, (int, int)>(compare);
        long score = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        while (pq.Count > 0)
        {
            var picked = pq.Dequeue();
            if (!marked[picked])
            {
                score += (long)nums[picked];
                marked[picked] = true;
                if (picked > 0) marked[picked - 1] = true;
                if (picked < nums.Length - 1) marked[picked + 1] = true;
            }
        }

        return score;
    }
}