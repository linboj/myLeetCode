public class Solution
{
    string[] map = ["abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"];
    public IList<string> LetterCombinations(string digits)
    {
        if (digits == null || digits.Length == 0) return [];
        List<string> result = new();
        char[] current = new char[digits.Length];
        Backtracking(digits, 0, current, result);
        return result;
    }

    private void Backtracking(string digits, int depth, char[] current, List<string> result)
    {
        foreach (var character in map[digits[depth] - '2'])
        {
            current[depth] = character;
            if (depth == digits.Length - 1)
            {
                result.Add(new string(current));
            }
            else
            {
                Backtracking(digits, depth + 1, current, result);
            }
        }
    }
}