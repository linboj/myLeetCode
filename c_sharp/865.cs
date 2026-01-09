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
    Dictionary<TreeNode, int> depthMap;
    int maxDepth;
    public TreeNode SubtreeWithAllDeepest(TreeNode root)
    {
        depthMap = new();
        maxDepth = -1;
        TreeNode ori = new();
        depthMap.Add(ori, -1);
        Dfs(root, ori);

        return Solve(root);
    }

    private void Dfs(TreeNode node, TreeNode parent)
    {
        if (node != null)
        {
            int depth = depthMap[parent] + 1;
            depthMap.Add(node, depth);
            maxDepth = Math.Max(maxDepth, depth);
            Dfs(node.left, node);
            Dfs(node.right, node);
        }
    }

    private TreeNode Solve(TreeNode node)
    {
        if (node == null || depthMap[node] == maxDepth)
            return node;

        TreeNode left = Solve(node.left), right = Solve(node.right);
        if (left != null && right != null) return node;
        if (left != null) return left;
        if (right != null) return right;
        return null;
    }
}