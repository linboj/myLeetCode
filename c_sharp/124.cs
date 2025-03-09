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
public class Solution {

    private int max = int.MinValue;
    public int MaxPathSum(TreeNode root) {
        FindMaxPath(root);
        return max;
    }

    private int FindMaxPath(TreeNode node) {
        if (node == null) return 0;

        var left = Math.Max(FindMaxPath(node.left), 0);
        var right = Math.Max(FindMaxPath(node.right), 0);

        max = Math.Max(max, left + right + node.val);

        return Math.Max(left, right) + node.val;
    }
}