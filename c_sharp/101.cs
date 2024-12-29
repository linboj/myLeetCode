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
    public bool IsSymmetric(TreeNode root) {
        return DFS(root.left, root.right);
    }

    private bool DFS(TreeNode left, TreeNode right) {
        if (left == null && right == null) return true;

        if (left?.val != right?.val) return false;

        return DFS(left.left, right.right) && DFS(left.right, right.left);
    }
}

public class Solution2 {
    public bool IsSymmetric(TreeNode root) {
        // BFS
        Queue<TreeNode> queue = new ();
        queue.Enqueue (root.left);
        queue.Enqueue (root.right);

        while (queue.Count > 0) {
            var left = queue.Dequeue();
            var right = queue.Dequeue();

            if (left == null && right == null) continue;
            if (left?.val != right?.val) 
                return false;
            else {
                queue.Enqueue (left.left);
                queue.Enqueue (right.right);
                queue.Enqueue (left.right);
                queue.Enqueue (right.left);
            }
        }
        return true;
    }
}