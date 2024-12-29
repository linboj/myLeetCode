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
    public int MaxDepth(TreeNode root)
    {
        // BFS
        if (root == null) return 0;
        Queue<TreeNode> queue = new();
        int depth = 0;
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count();
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            depth++;
        }
        return depth;
    }
}

public class Solution2
{
    public int MaxDepth(TreeNode root)
    {
        // BFS
        if (root == null) return 0;
        int leftMaxDepth = MaxDepth(root.left);
        int rightMaxDepth = MaxDepth(root.right);
        return Math.Max(leftMaxDepth, rightMaxDepth) + 1;
    }
}