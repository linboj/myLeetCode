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
    private const int MOD = 1_000_000_007;
    public int MaxProduct(TreeNode root)
    {
        long allSum = DFS(root);
        long ans = long.MinValue;
        DFSFindMaxProduct(root, allSum, ref ans);

        return (int)(ans % MOD);
    }

    private long DFS(TreeNode node)
    {
        if (node == null) return 0;

        long leftSum = DFS(node.left);
        long rightSum = DFS(node.right);

        long totalSum = leftSum + rightSum + node.val;
        return totalSum;
    }

    private long DFSFindMaxProduct(TreeNode node, long totalSum, ref long max)
    {
        if (node == null) return 0;

        long leftSum = DFSFindMaxProduct(node.left, totalSum, ref max);
        long rightSum = DFSFindMaxProduct(node.right, totalSum, ref max);
        long subtreeSum = node.val + leftSum + rightSum;

        max = Math.Max(max, (totalSum - subtreeSum) * subtreeSum);

        return subtreeSum;
    }
}