public class Solution
{
    public string SimplifyPath(string path)
    {
        var splited = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        Stack<string> stack = new();
        StringBuilder ans = new StringBuilder();

        foreach (var item in splited)
        {
            switch (item)
            {
                case "..":
                    stack.TryPop(out var _);
                    break;
                case ".":
                    break;
                case "":
                    if (stack.Count > 0 && stack.Peek() != "/")
                    {
                        stack.Push("/");
                    }
                    break;
                default:
                    stack.Push(item);
                    break;
            }
        }

        while (stack.Count > 0)
        {
            ans.Insert(0, stack.Pop());
            ans.Insert(0, '/');
        }

        if (ans.Length == 0) ans.Append("/");

        return ans.ToString();

    }
}