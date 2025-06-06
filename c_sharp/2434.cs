using System.Text;

public class Solution
{
    public string RobotWithString(string s)
    {
        int[] counts = new int[26];
        foreach (var ch in s)
        {
            counts[ch - 'a']++;
        }

        Stack<char> stack = new();
        StringBuilder sb = new();
        char minChar = 'a';
        foreach (var ch in s)
        {
            stack.Push(ch);
            counts[ch - 'a']--;
            while (minChar != 'z' && counts[minChar - 'a'] == 0)
                minChar++;
            while (stack.Count > 0 && stack.Peek() <= minChar)
                sb.Append(stack.Pop());
        }
        return sb.ToString();
    }
}