public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        bool[] seen = new bool[n];
        Queue<int> q = new();

        q.Enqueue(start);

        while (q.Count > 0)
        {
            int cn = q.Count;

            for (int i = 0; i < cn; i++)
            {
                int idx = q.Dequeue();
                if (seen[idx])
                    continue;

                int num = arr[idx];

                if (num == 0)
                    return true;

                seen[idx] = true;

                if (idx - num >= 0)
                    q.Enqueue(idx - num);

                if (idx + num < n)
                    q.Enqueue(idx + num);
            }
        }

        return false;
    }
}