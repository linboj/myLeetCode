public class Solution
{
    public int Calculate(string s)
    {
        s = s.Replace(" ", "");
        Stack<int> stack = new();
        int number = 0;
        int sum = 0;
        int sign = 1;
        foreach (var ch in s)
        {
            switch (ch)
            {
                case '+':
                    sum += sign * number;
                    sign = 1;
                    number = 0;
                    break;
                case '-':
                    sum += sign * number;
                    sign = -1;
                    number = 0;
                    break;
                case '(':
                    stack.Push(sum);
                    stack.Push(sign);
                    sum = 0;
                    sign = 1;
                    break;
                case ')':
                    sum += number * sign;
                    number = 0;
                    sum *= stack.Pop();
                    sum += stack.Pop();
                    break;
                default:
                    if (char.IsDigit(ch))
                    {
                        number = number * 10 + (ch - '0');
                    }
                    break;
            }

        }
        sum += sign * number;
        return sum;
    }
}