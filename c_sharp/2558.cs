public class Solution
{
  public long PickGifts(int[] gifts, int k)
  {
    var pq = new PriorityQueue<int, int>();
    // Array.Sort(gifts, new Comparison<int>(
    //   (i1, i2) => i2.CompareTo(i1)));
    
    foreach (var g in gifts)
    {
      pq.Enqueue(g, -g);
    }

    for (int i = 0; i < k; i++)
    {
      int picked = pq.Dequeue();
      int leaved = (int)Math.Sqrt(picked);
      pq.Enqueue(leaved, -leaved);
    }

    long sum = 0;
    while (pq.Count > 0)
    {
      sum += pq.Dequeue();
    }

    return sum;
  }
}