/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        int n = traversal.Length;
        Stack<TreeNode> stack = new();
        int idx = 0;

        while (idx < n)
        {
            int depth = 0;
            while (idx < n && traversal[idx] == '-')
            {
                depth++;
                idx++;
            }

            int value = 0;
            while (idx < n && traversal[idx] != '-')
            {
                value = value * 10 + (traversal[idx] - '0');
                idx++;
            }

            TreeNode node = new TreeNode(value);

            while (stack.Count > depth)
            {
                stack.Pop();
            }

            if (stack.Count != 0)
            {
                var parent = stack.Peek();
                if (parent.left == null)
                {
                    parent.left = node;
                }
                else
                {
                    parent.right = node;
                }
            }
            stack.Push(node);
        }

        while (stack.Count > 1)
        {
            stack.Pop();
        }
        return stack.Pop();
    }
}