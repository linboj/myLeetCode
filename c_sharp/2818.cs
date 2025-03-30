public class Solution
{
    // Monotonic Stack & Priority Queue
    private int mod = 1000000007;
    public int MaximumScore(IList<int> nums, int k)
    {
        int n = nums.Count;
        int[] primeScores = new int[n];

        for (int idx = 0; idx < n; idx++)
        {
            int num = nums[idx];

            for (int factor = 2; factor <= Math.Sqrt(num); factor++)
            {
                if (num % factor == 0)
                {
                    primeScores[idx]++;

                    while (num % factor == 0) num /= factor;
                }
            }

            if (num >= 2) primeScores[idx]++;
        }

        int[] nextDominant = new int[n];
        int[] prevDominant = new int[n];
        Array.Fill(nextDominant, n);
        Array.Fill(prevDominant, -1);

        Stack<int> decsPrimeScoreStack = new();

        for (int idx = 0; idx < n; idx++)
        {
            while (decsPrimeScoreStack.Count > 0 && primeScores[decsPrimeScoreStack.Peek()] < primeScores[idx])
            {
                int topIndex = decsPrimeScoreStack.Pop();

                nextDominant[topIndex] = idx;
            }

            if (decsPrimeScoreStack.Count > 0)
                prevDominant[idx] = decsPrimeScoreStack.Peek();

            decsPrimeScoreStack.Push(idx);
        }

        long[] numOfSubarrays = new long[n];
        for (int idx = 0; idx < n; idx++)
        {
            numOfSubarrays[idx] = ((long)nextDominant[idx] - idx) * (idx - prevDominant[idx]);
        }

        PriorityQueue<int[], int[]> pq = new(Comparer<int[]>.Create((a, b) =>
        {
            if (b[0] == a[0])
                return a[1].CompareTo(b[1]);
            return b[0].CompareTo(a[0]);
        }));

        for (int idx = 0; idx < n; idx++)
        {
            var items = new int[] { nums[idx], idx };
            pq.Enqueue(items, items);
        }

        long score = 1;

        while (k > 0)
        {
            int[] top = pq.Dequeue();
            int num = top[0];
            int idx = top[1];

            long operations = Math.Min(k, numOfSubarrays[idx]);

            score = score * power(num, operations) % mod;

            k -= (int)operations;
        }

        return (int)score;
    }

    private long power(long n, long exponent)
    {
        long res = 1;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                res = res * n % mod;
            }

            n = n * n % mod;
            exponent /= 2;
        }

        return res;
    }
}