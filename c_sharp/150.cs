public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int outNum))
            {
                stack.Push(outNum);
            }
            else
            {
                int num2 = stack.Pop();
                int num1 = stack.Pop();
                int res = 0;

                switch (token)
                {
                    case "+":
                        res = num1 + num2;
                        break;
                    case "-":
                        res = num1 - num2;
                        break;
                    case "/":
                        res = num1 / num2;
                        break;
                    case "*":
                        res = num1 * num2;
                        break;
                    default:
                        break;
                }
                stack.Push(res);
            }
        }

        return stack.Pop();
    }
}