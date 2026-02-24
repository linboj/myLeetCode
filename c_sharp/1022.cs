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
    public int SumRootToLeaf(TreeNode root)
    {
        int ans = 0;
        DFS(root, ref ans, 0);
        return ans;
    }

    private void DFS(TreeNode node, ref int total, int sum)
    {

        if (node == null) return;

        int cur = (sum << 1) + node.val;
        if (node.left == null && node.right == null)
        {
            total += cur;
        }
        else
        {
            DFS(node.left, ref total, cur);
            DFS(node.right, ref total, cur);
        }
    }
}