public class MedianFinder
{

    private PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();
    private PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

    private double median;

    public MedianFinder()
    {
        median = 0;
    }

    public void AddNum(int num)
    {
        int nMax = maxHeap.Count;
        int nMin = minHeap.Count;
        if (nMax == nMin)
        {
            if (num > median)
                maxHeap.Enqueue(num, num);
            else
                minHeap.Enqueue(num, num);
        }
        else if (nMax > nMin)
        {
            if (num > median)
            {
                int moved = maxHeap.Dequeue();
                minHeap.Enqueue(moved, moved);
                maxHeap.Enqueue(num, num);
            }
            else
            {
                minHeap.Enqueue(num, num);
            }
        }
        else
        {
            if (num < median)
            {
                int moved = minHeap.Dequeue();
                maxHeap.Enqueue(moved, moved);
                minHeap.Enqueue(num, num);
            }
            else
            {
                maxHeap.Enqueue(num, num);
            }
        }
        median = FindMedian();
    }

    public double FindMedian()
    {
        int nMax = maxHeap.Count;
        int nMin = minHeap.Count;
        if (nMax == nMin)
            return (maxHeap.Peek() + minHeap.Peek()) / 2D;
        else if (nMax > nMin)
            return maxHeap.Peek();
        else
            return minHeap.Peek();
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */