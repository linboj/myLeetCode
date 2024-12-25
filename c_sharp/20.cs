public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new();

        foreach (char c in s)
        {
            switch (c)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                default:
                    if (stack.Count == 0 || c != stack.Pop())
                        return false;
                    break;
            }
        }

        return stack.Count == 0;
    }
}