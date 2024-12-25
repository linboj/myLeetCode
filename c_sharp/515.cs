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
    public IList<int> LargestValues(TreeNode root)
    {
        // BFS
        if (root == null) return [];

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        List<int> result = new();

        while (queue.Count > 0)
        {
            int size = queue.Count;
            int maxValue = int.MinValue;

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);

                if (node.val > maxValue)
                {
                    maxValue = node.val;
                }
            }

            result.Add(maxValue);
        }

        return result;
    }
}