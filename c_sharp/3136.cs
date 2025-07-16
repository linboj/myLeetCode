public class Solution
{
    public bool IsValid(string word)
    {
        if (word.Length < 3)
            return false;

        bool hasVowel = false;
        bool hasConsonant = false;
        foreach (var ch in word)
        {
            bool isValid = false;
            bool isDigit = false;
            if (ch >= (int)'0' && ch <= (int)'9')
            {
                isValid = true;
                isDigit = true;
            }

            if (ch >= 'A' && ch <= 'Z')
                isValid = true;

            if (ch >= 'a' && ch <= 'z')
                isValid = true;

            if (!isValid)
                return false;

            if (!isDigit)
            {
                if (ch == 'A' || ch == 'I' || ch == 'O' || ch == 'U' || ch == 'E' ||
                ch == 'a' || ch == 'i' || ch == 'o' || ch == 'u' || ch == 'e')
                {
                    hasVowel = true;
                }
                else
                {
                    hasConsonant = true;
                }
            }
        }
        return hasVowel && hasConsonant;
    }
}