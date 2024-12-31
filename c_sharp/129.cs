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
    public int SumNumbers(TreeNode root)
    {
        int totalSum = 0;
        DFS(root, 0, ref totalSum);

        return totalSum;

    }

    private void DFS(TreeNode root, int currentSum, ref int totalSum)
    {
        if (root == null) return;
        
        if (root.left == null && root.right == null)
        {
            totalSum += currentSum * 10 + root.val;
            return;
        }


        if (root.left != null){
            DFS(root.left, currentSum * 10 + root.val, ref totalSum);
        }

        if (root.right != null){
            DFS(root.right, currentSum * 10 + root.val, ref totalSum);
        }
    }
}