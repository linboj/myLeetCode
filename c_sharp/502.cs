public class Solution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        PriorityQueue<int, int> pq = new();
        Array.Sort(capital, profits);
        int n = profits.Length;
        int currentIdx = 0;

        while (k > 0)
        {
            while (currentIdx < n && capital[currentIdx] <= w)
            {
                pq.Enqueue(profits[currentIdx], -profits[currentIdx]);
                currentIdx++;
            }
            if (pq.Count == 0) break;
            int highestProfit = pq.Dequeue();
            w += highestProfit;
            k--;
        }

        return w;
    }
}

public class Solution2
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        int n = profits.Length;
        int[] map = new int[n];
        for (int i = 0; i < n; i++)
            map[i] = i;
        Array.Sort(map, (x,y) => capital[x].CompareTo(capital[y]));
        int currentIdx = 0;
        PriorityQueue<int, int> pq = new(n);

        if (capital[map[n-1]] <= w && k >= n){
            foreach (var p in profits)
            {
                w += p;
            }
            return w;
        }
        if (capital[map[0]] > w) return w;


        while (k > 0)
        {
            while (currentIdx < n && capital[map[currentIdx]] <= w)
            {
                pq.Enqueue(profits[map[currentIdx]], -profits[map[currentIdx++]]);
            }
            if (pq.Count == 0) break;
            int highestProfit = pq.Dequeue();
            w += highestProfit;
            k--;
        }

        return w;
    }
}