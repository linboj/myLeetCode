public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];

        List<(int val, int l, int r)> stack = new();

        for (int i = 0; i < n; i++)
        {
            var cur = (val: nums[i], l: i, r: i);

            while (stack.Count > 0 && stack[^1].val > nums[i])
            {
                var top = stack[^1];
                stack.RemoveAt(stack.Count - 1);
                cur = (val: Math.Max(top.val, cur.val), l: top.l, r: cur.r);
            }

            stack.Add(cur);
        }

        for (int i = 0; i < stack.Count; i++)
        {
            for (int j = stack[i].l; j <= stack[i].r; j++)
            {
                ans[j] = stack[i].val;
            }
        }

        return ans;
    }
}