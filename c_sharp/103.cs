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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> result = new();
        if (root == null) return result;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int currentLevel = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count();
            List<int> collection = new();
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                collection.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            if (currentLevel % 2 == 1) collection.Reverse();
            result.Add(collection);
            currentLevel++;
        }
        return result;
    }
}