public class Solution
{
    // use hashmap and binary search
    public long RepairCars(int[] ranks, int cars)
    {
        long minTime = 1, maxTime = long.MaxValue;
        Dictionary<int, int> dict = new();
        foreach (var rank in ranks)
        {
            if (!dict.ContainsKey(rank))
            {
                dict[rank] = 0;
                // find the time of min rank fixing all cars as maxTime
                maxTime = Math.Min(maxTime, 1L * rank * cars * cars);
            }
            dict[rank]++;
        }

        while (maxTime > minTime)
        {
            long midTime = (maxTime + minTime) / 2;
            long totalFixCars = 0;

            foreach (var (rank, count) in dict)
                totalFixCars += ((long)Math.Sqrt(1.0 * midTime / rank)) * count;

            if (totalFixCars < cars)
                minTime = midTime + 1;
            else
                maxTime = midTime;
        }
        return minTime;
    }
}

