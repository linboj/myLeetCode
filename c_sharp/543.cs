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
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int max = 0;
        DiameterOfBinaryTree(root, ref max);
        return max;
    }

    private int DiameterOfBinaryTree(TreeNode node, ref int max)
    {
        if (node == null) return 0;

        var left = DiameterOfBinaryTree(node.left, ref max);
        var right = DiameterOfBinaryTree(node.right, ref max);

        max = Math.Max(max, left + right);

        return Math.Max(left, right) + 1;
    }
}