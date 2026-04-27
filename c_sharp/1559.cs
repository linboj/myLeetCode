public class Solution
{
    public bool ContainsCycle(char[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        var uf = new UnionFind(n * m);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i > 0 && grid[i][j] == grid[i - 1][j])
                {
                    if (!uf.FindAndUnion(i * m + j, (i - 1) * m + j))
                        return true;
                }

                if (j > 0 && grid[i][j] == grid[i][j - 1])
                {
                    if (!uf.FindAndUnion(i * m + j, i * m + j - 1))
                        return true;
                }
            }
        }
        return false;
    }

    class UnionFind
    {
        private int[] parent;
        private int[] size;
        private int n;
        private int setCnt;

        public UnionFind(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
            size = new int[n];
            Array.Fill(size, 1);
            this.n = n;
            setCnt = n;
        }

        public int Find(int x)
        {
            if (parent[x] == x)
                return x;

            return parent[x] = Find(parent[x]);
        }

        public void Union(int x, int y)
        {
            if (size[x] < size[y])
            {
                int tmp = x;
                x = y;
                y = tmp;
            }

            parent[y] = x;
            size[x] += size[y];
            setCnt--;
        }

        public bool FindAndUnion(int x, int y)
        {
            int xp = Find(x);
            int yp = Find(y);
            if (xp != yp)
            {
                Union(xp, yp);
                return true;
            }

            return false;
        }
    }
}