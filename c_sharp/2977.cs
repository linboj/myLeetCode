public class Solution
{
    private const int INF = int.MaxValue / 2;
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        int n = source.Length, m = original.Length;
        Trie root = new Trie();

        int p = -1;
        int[,] graph = new int[m * 2, m * 2];

        for (int i = 0; i < m * 2; i++)
        {
            for (int j = 0; j < m * 2; j++)
            {
                graph[i, j] = INF;
            }
            graph[i, i] = 0;
        }

        for (int i = 0; i < m; i++)
        {
            int x = Add(root, original[i], ref p);
            int y = Add(root, changed[i], ref p);
            graph[x, y] = Math.Min(graph[x, y], cost[i]);
        }

        int size = p + 1;
        for (int k = 0; k < size; k++)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                }
            }
        }

        long[] f = new long[n];
        Array.Fill(f, -1);
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && f[i - 1] == -1)
                continue;

            long baseVal = i == 0 ? 0 : f[i - 1];
            if (source[i] == target[i])
                Update(ref f[i], baseVal);

            Trie a = root;
            Trie b = root;
            for (int j = i; j < n; j++)
            {
                a = a.child[source[j] - 'a'];
                b = b.child[target[j] - 'a'];
                if (a == null || b == null)
                    break;

                if (a.id != -1 && b.id != -1 && graph[a.id, b.id] != INF)
                {
                    long newVal = baseVal + graph[a.id, b.id];
                    Update(ref f[j], newVal);
                }
            }
        }
        return f[n - 1];
    }

    private int Add(Trie node, string word, ref int index)
    {
        foreach (var c in word)
        {
            int i = c - 'a';
            if (node.child[i] == null)
                node.child[i] = new Trie();

            node = node.child[i];
        }
        if (node.id == -1)
            node.id = ++index;

        return node.id;
    }

    private void Update(ref long x, long y)
    {
        if (x == -1 || y < x)
            x = y;
    }


}

public class Trie
{
    public Trie[] child = new Trie[26];
    public int id = -1;
}