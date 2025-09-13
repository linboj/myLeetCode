public class Solution
{
    public bool DoesAliceWin(string s)
    {
        foreach (var c in s)
        {
            if (IsVowel(c))
                return true;
        }
        return false;
    }

    private bool IsVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}