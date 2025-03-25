public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        SortedDictionary<int, int> dayMap = new();
        int prefixSum = 0, freeDays = 0, previousDay = days;

        foreach (var meeting in meetings)
        {
            previousDay = Math.Min(previousDay, meeting[0]);

            if (!dayMap.ContainsKey(meeting[0]))
                dayMap[meeting[0]] = 0;
            dayMap[meeting[0]]++;

            if (!dayMap.ContainsKey(meeting[1] + 1))
                dayMap[meeting[1] + 1] = 0;
            dayMap[meeting[1] + 1]--;
        }

        freeDays += previousDay - 1;
        foreach (var (day, count) in dayMap) {
            int currentDay = day;

            if (prefixSum == 0) {
                freeDays += currentDay - previousDay;
            }
            prefixSum += count;
            previousDay = currentDay;
        }

        freeDays += days - previousDay + 1;
        return freeDays;
    }
}

public class Solution2
{
    public int CountDays(int days, int[][] meetings)
    {
        int freeDays = 0, latestEnd = 0;

        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        foreach (var meeting in meetings) {
            int start = meeting[0], end = meeting[1];

            if (start > latestEnd + 1) {
                freeDays += start - latestEnd - 1;
            }

            latestEnd = Math.Max(latestEnd, end);
        }

        freeDays += days - latestEnd;

        return freeDays;
    }
}