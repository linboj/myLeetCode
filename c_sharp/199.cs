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
    public IList<int> RightSideView(TreeNode root)
    {
        if (root == null) return [];
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        List<int> result = new List<int>();

        while (queue.Count > 0)
        {
            int size = queue.Count();
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                if (i == 0)
                {
                    result.Add(node.val);
                }
                if (node.right != null) queue.Enqueue(node.right);
                if (node.left != null) queue.Enqueue(node.left);
            }
        }
        return result;
    }
}