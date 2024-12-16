public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        // use PriorityQueue with (value, index) Priority
        /*
        PriorityQueue<int, (int Value, int Index)> pq = new(Comparer<(int Value, int Index)>.Create((a, b) => a.Value == b.Value ? a.Index.CompareTo(b.Index) : a.Value.CompareTo(b.Value)));
        for (int i = 0; i < nums.Length; i++)
        {
            pq.Enqueue(i, (nums[i], i));
        }

        while (k-- > 0){
            var picked = pq.Dequeue();
            nums[picked] *= multiplier;
            pq.Enqueue(picked, (nums[picked], picked));
        }

        return nums;
        */

        // brute
        while (k-- > 0)
        {
            int min = int.MaxValue;
            int minIdx = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min){
                    min = nums[i];
                    minIdx = i;
                } 
            }
            nums[minIdx] *= multiplier;
        }

        return nums;
    }
}