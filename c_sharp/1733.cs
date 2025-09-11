public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        HashSet<int> notComm = new();
        foreach (var friendship in friendships)
        {
            Dictionary<int, int> map = new();
            bool comm = false;
            foreach (var lan in languages[friendship[0] - 1])
            {
                map.TryGetValue(lan, out int cnt);
                map[lan] = cnt + 1;
            }

            foreach (var lan in languages[friendship[1] - 1])
            {
                if (map.ContainsKey(lan))
                {
                    comm = true;
                    break;
                }
            }

            if (!comm)
            {
                notComm.Add(friendship[0] - 1);
                notComm.Add(friendship[1] - 1);
            }
        }

        int maxCnt = 0;
        int[] cnts = new int[n];
        foreach (var user in notComm)
        {
            foreach (var lan in languages[user])
            {
                cnts[lan - 1]++;
                maxCnt = Math.Max(maxCnt, cnts[lan - 1]);
            }
        }
        return notComm.Count - maxCnt;
    }
}