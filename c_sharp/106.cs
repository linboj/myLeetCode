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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return BuildTreeHelper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }
    private TreeNode BuildTreeHelper(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
    {
        if (postStart > postEnd || inStart > inEnd) return null;

        int rootValue = postorder[postEnd];
        var root = new TreeNode(rootValue);

        int rootIdxIn = Array.IndexOf(inorder, rootValue);
        int leftSubtreeSize = rootIdxIn - inStart;

        root.left = BuildTreeHelper(inorder, inStart, rootIdxIn - 1, postorder, postStart, postStart + leftSubtreeSize - 1);
        root.right = BuildTreeHelper(inorder, rootIdxIn + 1, inEnd, postorder, postStart + leftSubtreeSize, postEnd - 1);
        return root;
    }
}