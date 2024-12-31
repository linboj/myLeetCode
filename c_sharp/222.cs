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
    public int CountNodes(TreeNode root)
    {
        if (root == null) return 0;
        int rightDepth = GetDepth(root.right);
        int leftDepth = GetDepth(root.left);

        if (rightDepth == leftDepth)
        {
            return (1 << leftDepth) + CountNodes(root.right);
        }
        else
        {
            return (1 << rightDepth) + CountNodes(root.left);
        }

        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }

    private int GetDepth(TreeNode root)
    {
        int depth = 0;
        while (root != null)
        {
            depth++;
            root = root.left;
        }
        return depth;
    }
}