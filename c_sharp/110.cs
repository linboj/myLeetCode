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
    public bool IsBalanced(TreeNode root)
    {
        int depth = GetDepth(root);

        return depth != -1;
    }

    private int GetDepth(TreeNode node)
    {
        if (node == null) return 0;

        int lDepth = GetDepth(node.left);
        int rDepth = GetDepth(node.right);

        return lDepth != -1 && rDepth != -1 && Math.Abs(lDepth - rDepth) <= 1 ?
        Math.Max(lDepth, rDepth) + 1 : -1;
    }
}