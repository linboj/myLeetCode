public class Solution
{
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        int[] ans = new int[numberOfUsers];

        PriorityQueue<(int time, int type, string idStr), (int, int)> pq = new();
        foreach (var e in events)
        {
            int type = e[0] == "OFFLINE" ? 0 : 1;
            int time = int.Parse(e[1]);
            pq.Enqueue((time, type, e[2]), (time, type));
        }

        Dictionary<int, int> onlineFrom = new();
        while (pq.Count > 0)
        {
            var e = pq.Dequeue();
            if (e.type == 0)
            {
                int onlineTime = e.time + 60;
                int id = int.Parse(e.idStr);
                onlineFrom[id] = onlineTime;
            }
            else
            {
                if (e.idStr == "ALL")
                {
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        ans[i]++;
                    }
                }
                else if (e.idStr == "HERE")
                {
                    int curTime = e.time;
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        int userOnlineTime = onlineFrom.GetValueOrDefault(i, 0);
                        if (curTime >= userOnlineTime)
                            ans[i]++;
                    }
                }
                else
                {
                    var idsStr = e.idStr.Split(" ");
                    foreach (var idStr in idsStr)
                    {
                        int id = int.Parse(idStr[2..]);
                        ans[id]++;
                    }
                }
            }
        }

        return ans;
    }
}