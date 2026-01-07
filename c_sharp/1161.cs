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
    public int MaxLevelSum(TreeNode root)
    {
        List<int> sums = new();
        DFS(root, sums, 1);

        int ans = 0;
        int maxSum = int.MinValue;

        for (int i = 0; i < sums.Count; i++)
        {
            int sum = sums[i];
            if (sum > maxSum)
            {
                ans = i + 1;
                maxSum = sum;
            }
        }
        return ans;
    }

    private void DFS(TreeNode node, List<int> sums, int level)
    {
        if (node == null) return;

        if (sums.Count < level) sums.Add(0);

        sums[level - 1] += node.val;

        DFS(node.left, sums, level + 1);
        DFS(node.right, sums, level + 1);
    }
}