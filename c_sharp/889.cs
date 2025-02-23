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
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        int n = preorder.Length;
        int[] postOrderMap = new int[n];
        for (int i = 0; i < n; i++)
        {
            postOrderMap[postorder[i] - 1] = i;
        }
        return Construct(preorder, postOrderMap, 0, n - 1, 0);
    }

    private TreeNode Construct(int[] preorder, int[] postOrderMap, int preStart, int preEnd, int postStart)
    {
        if (preStart > preEnd) return null;
        if (preStart == preEnd) return new TreeNode(preorder[preStart]);
        int nLeftNode =  postOrderMap[preorder[preStart + 1] - 1] - postStart + 1;

        TreeNode parent = new TreeNode(preorder[preStart]);

        parent.left = Construct(preorder, postOrderMap, preStart + 1, preStart + nLeftNode, postStart);

        parent.right = Construct(preorder, postOrderMap, preStart + 1 + nLeftNode, preEnd, postStart + nLeftNode);

        return parent;
    }
}