public class Solution
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength)
    {
        int ans = 0;

        Array.Sort(tasks);
        Array.Sort(workers);
        int l = 1, r = Math.Min(tasks.Length, workers.Length);
        while (l <= r)
        {
            int mid = (l + r) / 2;
            if (Check(tasks, workers, pills, strength, mid))
            {
                ans = mid;
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }

        return ans;
    }

    private bool Check(int[] tasks, int[] workers, int pills, int strength, int mid)
    {
        int p = pills, m = workers.Length;
        LinkedList<int> availableWorks = new();
        int wIdx = m - 1;

        for (int tIdx = mid - 1; tIdx >= 0; tIdx--)
        {
            while (wIdx >= m - mid && workers[wIdx] + strength >= tasks[tIdx])
            {
                availableWorks.AddFirst(workers[wIdx]);
                wIdx--;
            }

            if (availableWorks.Count <= 0)
                return false;

            if (availableWorks.Last.Value >= tasks[tIdx])
            {
                availableWorks.RemoveLast();
            }
            else
            {
                if (p <= 0)
                    return false;
                p--;
                availableWorks.RemoveFirst();
            }
        }
        return true;
    }
}