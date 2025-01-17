public class Solution
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        List<IList<int>> result = new();
        PriorityQueue<(int, int), int> heap = new();
        heap.Enqueue((0, 0), nums1[0] + nums2[0]);
        while (k > result.Count)
        {
            var head = heap.Dequeue();
            int i = head.Item1;
            int j = head.Item2;

            result.Add([nums1[i], nums2[j]]);
            if (i + 1 < nums1.Length)
                heap.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
            if (j + 1 < nums2.Length)
                heap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
        }

        return result;

    }
}

public class Solution2
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        List<IList<int>> result = new();
        PriorityQueue<(int, int), int> heap = new();
        heap.Enqueue((0, 0), nums1[0] + nums2[0]);
        while (k > result.Count)
        {
            var head = heap.Dequeue();
            int i = head.Item1;
            int j = head.Item2;

            result.Add([nums1[i], nums2[j]]);
            if (i + 1 < nums1.Length && i + 1 >= j)
                heap.Enqueue((i + 1, j), nums1[i + 1] + nums2[j]);
            if (j + 1 < nums2.Length && j + 1 > i)
                heap.Enqueue((i, j + 1), nums1[i] + nums2[j + 1]);
        }

        return result;

    }
}