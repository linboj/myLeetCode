public class Solution
{
    private int[,] T;
    HashSet<long> seen;
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        T = new int[7, 7];
        foreach (var item in allowed)
        {
            T[item[0] - 'A', item[1] - 'A'] |= 1 << (item[2] - 'A');
        }

        seen = new();
        int n = bottom.Length;
        int[,] A = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            A[n - 1, i] = bottom[i] - 'A';
        }
        return Solve(A, 0, n - 1, 0);
    }

    private bool Solve(int[,] A, long r, int n, int i)
    {
        if (n == 1 && i == 1)
            return true;
        else if (i == n)
        {
            if (seen.Contains(r)) return false;

            seen.Add(r);
            return Solve(A, 0, n - 1, 0);
        }
        else
        {
            int w = T[A[n, i], A[n, i + 1]];

            for (int b = 0; b < 7; b++)
            {
                if (((w >> b) & 1) != 0)
                {
                    A[n - 1, i] = b;

                    if (Solve(A, r * 8 + (b + 1), n, i + 1)) return true;
                }
            }
            return false;
        }
    }
}