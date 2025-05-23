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
    public void Flatten(TreeNode root)
    {
        if (root == null) return;

        var current = root;
        while (current != null){
            if (current.left != null){
                TreeNode rightMost = current.left;
                while (rightMost.right != null){
                    rightMost = rightMost.right;
                }
                rightMost.right = current.right;
                current.right = current.left;
                current.left = null;
            }
            current = current.right;
        }

    }
}