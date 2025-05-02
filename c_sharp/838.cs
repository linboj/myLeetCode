using System.Text;

public class Solution
{
    public string PushDominoes(string dominoes)
    {
        int n = dominoes.Length;
        int[] forces = new int[n];
        int currentIdx = 0;

        int force = 0;
        foreach (var c in dominoes)
        {
            if (c == 'R')
                force = n;
            else if (c == 'L')
                force = 0;
            else
                force = Math.Max(force - 1, 0);
            forces[currentIdx++] += force;
        }

        force = 0;
        while (currentIdx > 0)
        {
            char c = dominoes[--currentIdx];
            if (c == 'R')
                force = 0;
            else if (c == 'L')
                force = n;
            else
                force = Math.Max(force - 1, 0);
            forces[currentIdx] -= force;
        }

        StringBuilder ans = new();
        foreach (var val in forces)
        {
            if (val == 0)
                ans.Append(".");
            else if (val > 0)
                ans.Append('R');
            else
                ans.Append("L");
        }
        return ans.ToString();

    }
}