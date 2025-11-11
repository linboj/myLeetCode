public class Solution
{
    public int MinOperations(int[] nums)
    {
        Stack<int> stack = new();

        int ans = 0;

        foreach (var num in nums)
        {
            while (stack.Count > 0 && stack.Peek() > num)
            {
                stack.Pop();
            }

            if (num == 0) continue;

            if (stack.Count == 0 || stack.Peek() < num)
            {
                ans++;
                stack.Push(num);
            }
        }
        return ans;
    }
}