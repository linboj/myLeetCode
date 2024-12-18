using System.Text;

public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] freq = new int[26];
        foreach (var item in s)
        {
            freq[item - 'a']++;
        }
        PriorityQueue<(char ch, int count), int> pq = new();
        for (int i = 0; i < 26; i++)
        {
            var frequency = freq[i];
            if (frequency == 0) continue;
            char ch = (char)(i + 'a');
            pq.Enqueue((ch, frequency), -ch);
        }

        var res = new StringBuilder();
        while (pq.Count > 0)
        {
            var (ch, count) = pq.Dequeue();
            int addCount = Math.Min(count, repeatLimit);
            res.Append(ch, addCount);

            if (count <= repeatLimit) continue;

            if (pq.Count == 0) break;

            var (nextCh, nextCount) = pq.Dequeue();
            res.Append(nextCh);

            if (--nextCount > 0) pq.Enqueue((nextCh, nextCount), -nextCh);

            pq.Enqueue((ch, count - addCount), -ch);

        }
        return res.ToString();
    }
}