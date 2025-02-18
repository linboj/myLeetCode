using System.Text;

public class Solution
{
    // Regulated Brute Force via Recursion
    public string SmallestNumber(string pattern)
    {
        StringBuilder result = new();
        buildSequence(0, 0, pattern, result);
        var ans = result.ToString().ToCharArray();
        Array.Reverse(ans);
        return new string(ans);

    }

    private int buildSequence(int currentIdx, int currentCount, string pattern, StringBuilder result)
    {
        if (currentIdx != pattern.Length)
        {
            if (pattern[currentIdx] == 'I')
                buildSequence(currentIdx + 1, currentIdx + 1, pattern, result);
            else
                currentCount = buildSequence(currentIdx + 1, currentCount, pattern, result);
        }

        result.Append(currentCount + 1);
        return currentCount + 1;

    }
}

public class Solution2
{
    // Using Stack
    public string SmallestNumber(string pattern)
    {
        StringBuilder result = new();
        Stack<int> stack = new ();
        for (int idx = 0; idx <= pattern.Length; idx++)
        {
            stack.Push(idx+1);
            if (idx == pattern.Length || pattern[idx] == 'I'){
                while (stack.Count > 0){
                    result.Append(stack.Pop());
                }
            }
        }
        return result.ToString();
    }
}
