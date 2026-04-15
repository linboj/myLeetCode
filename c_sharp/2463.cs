public class Solution
{
    private const long INF = (long)1e12;
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        int nR = robot.Count;
        int[] robots = new int[nR];
        for (int i = 0; i < nR; i++)
        {
            robots[i] = robot[i];
        }
        Array.Sort(robots);
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));

        long[] current = new long[nR + 1];
        long[] next = new long[nR + 1];
        Array.Fill(current, INF);
        current[0] = 0;

        long[] prefixSum = new long[nR + 1];
        int[] deque = new int[nR + 1];

        foreach (var item in factory)
        {
            int pos = item[0], limit = item[1];
            for (int i = 0; i < nR; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + Math.Abs((long)robots[i] - pos);
            }
            int head = 0, tail = 0;
            for (int i = 0; i <= nR; i++)
            {
                long currentVal = current[i] != INF ? current[i] - prefixSum[i] : INF;
                while (tail > head)
                {
                    int lastK = deque[tail - 1];
                    long lastVal = current[lastK] != INF ? current[lastK] - prefixSum[lastK] : INF;
                    if (lastVal >= currentVal)
                    {
                        tail--;
                    }
                    else
                    {
                        break;
                    }
                }
                deque[tail++] = i;
                while (head < tail && deque[head] < i - limit)
                {
                    head++;
                }
                int bestK = deque[head];
                long bestVal = current[bestK] != INF ? current[bestK] - prefixSum[bestK] : INF;
                next[i] = bestVal != INF ? prefixSum[i] + bestVal : INF;
            }
            Array.Copy(next, 0, current, 0, nR + 1);
        }


        return current[nR];
    }
}