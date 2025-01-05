public class Solution
{
    public string ShiftingLetters(string s, int[][] shifts)
    {
        if (s == null || s.Length == 0) return "";
        int[] diffArray = new int[s.Length];
        foreach (var shift in shifts)
        {
            if (shift[2] == 1)
            {
                diffArray[shift[0]]++;
                if (shift[1] + 1 < s.Length)
                {
                    diffArray[shift[1] + 1]--;
                }
            }
            else
            {
                diffArray[shift[0]]--;
                if (shift[1] + 1 < s.Length)
                {
                    diffArray[shift[1] + 1]++;
                }
            }
        }
        var result = new char[s.Length];
        int nShifts = 0;
        for (int i = 0; i < s.Length; i++)
        {
            nShifts = (nShifts + diffArray[i]) % 26;
            if (nShifts < 0) nShifts += 26;
            char tmp = (char)('a' + (s[i] - 'a' + nShifts) % 26);
            result[i] = tmp;
        }
        return new string(result) ;
    }
}