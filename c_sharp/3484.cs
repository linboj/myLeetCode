public class Spreadsheet
{

    private Dictionary<string, int> map;
    public Spreadsheet(int rows)
    {
        map = new();
    }

    public void SetCell(string cell, int value)
    {
        map[cell] = value;
    }

    public void ResetCell(string cell)
    {
        map[cell] = 0;
    }

    public int GetValue(string formula)
    {
        for (int i = 1; i < formula.Length; i++)
        {
            if (formula[i] == '+')
            {
                string s1 = formula.Substring(1, i - 1), s2 = formula.Substring(i + 1);
                int left;
                if (Char.IsLetter(s1[0]))
                    map.TryGetValue(s1, out left);
                else
                    left = int.Parse(s1);

                int right;
                if (Char.IsLetter(s2[0]))
                    map.TryGetValue(s2, out right);
                else
                    right = int.Parse(s2);
                return left + right;
            }
        }
        return 0;
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */