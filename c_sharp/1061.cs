using System.Text;

public class Solution
{
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        int n = s1.Length;
        int[] parents = new int[26];
        Array.Fill(parents, -1);

        for (int i = 0; i < n; i++)
        {
            Union(s1[i] - 'a', s2[i] - 'a', parents);
        }

        StringBuilder sb = new();
        foreach (var ch in baseStr)
        {
            sb.Append((char)(Find(ch - 'a', parents) + 'a'));
        }

        return sb.ToString();
    }

    private void Union(int a, int b, int[] parents)
    {
        a = Find(a, parents);
        b = Find(b, parents);

        if (a == b) return;

        if (a > b)
            parents[a] = b;
        else
            parents[b] = a;
    }

    private int Find(int a, int[] parents)
    {
        if (parents[a] == -1)
            return a;
        return parents[a] = Find(parents[a], parents);
    }
}