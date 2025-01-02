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
    public int GetMinimumDifference(TreeNode root)
    {
        Stack<TreeNode> stack = new();
        int minDiff = int.MaxValue;
        int current = int.MaxValue;
        int previous;

        var currentNode = root;
        while (currentNode != null || stack.Count > 0)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.left;
            }
            if (stack.Count > 0)
            {
                currentNode = stack.Pop();
                previous = current;
                current = currentNode.val;
                minDiff = Math.Min(minDiff, Math.Abs(current - previous));
                currentNode = currentNode.right;
            }
        }
        return minDiff;
    }
}