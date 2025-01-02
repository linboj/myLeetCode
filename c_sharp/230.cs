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
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new();
        int count = 0;

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
                count++;
                if (count == k) {
                    return currentNode.val;
                }
                currentNode = currentNode.right;
            }
        }
        return 0;
    }
}