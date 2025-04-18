using System.Text;

public class Solution
{
    public string CountAndSay(int n)
    {
        string current = "1";

        for (int i = 1; i < n; i++)
        {
            var counts = Count(current);
            current = Say(counts);
        }

        return current;
    }

    private List<int[]> Count(string s)
    {
        List<int[]> result = new();

        if (s == null || s.Length == 0)
            return result;

        int count = 1;
        int prevNum = s[0] - '0';

        for (int i = 1; i < s.Length; i++)
        {
            int currentNum = s[i] - '0';
            if (currentNum != prevNum)
            {
                result.Add([prevNum, count]);
                count = 0;
                prevNum = currentNum;
            }
            count++;
        }
        result.Add([prevNum, count]);
        return result;
    }

    private string Say(List<int[]> list)
    {
        StringBuilder ans = new();
        foreach (var item in list)
        {
            ans.Append(item[1]);
            ans.Append(item[0]);
        }
        return ans.ToString();
    }
}