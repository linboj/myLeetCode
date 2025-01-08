public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new();
        List<char> current = new();
        Solve(n, n, current, result);
        return result;
    }

    private void Solve(int nOpen, int nClose, List<char> current, List<string> result)
    {
        if (nOpen < 0 || nClose < 0 || nOpen > nClose) return;
        if (nOpen == 0 && nClose == 0)
        {
            result.Add(new string(current.ToArray()));
            return;
        }

        current.Add('(');
        Solve(nOpen - 1, nClose, current, result);
        current.RemoveAt(current.Count - 1);

        current.Add(')');
        Solve(nOpen, nClose - 1, current, result);
        current.RemoveAt(current.Count - 1);
    }
}