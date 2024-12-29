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
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        switch (preorder.Length)
        {
            case 0:
                return null;
            case 1:
                return new TreeNode(preorder[0]);
            case 2:
                if (preorder[1] == inorder[0])
                {
                    return new TreeNode(preorder[0], new TreeNode(preorder[1]));
                }
                else
                {
                    return new TreeNode(preorder[0], null, new TreeNode(preorder[1]));
                }
            default:
                int rootIdxIn = 0;
                while (inorder[rootIdxIn] != preorder[0]) rootIdxIn++;
                TreeNode root = new TreeNode(preorder[0]);
                root.left = BuildTree(preorder[1..(rootIdxIn + 1)], inorder[..rootIdxIn]);
                root.right = BuildTree(preorder[(rootIdxIn + 1)..], inorder[(rootIdxIn + 1)..]);
                return root;
        }
    }
}

public class Solution1
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTreeHelper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }
    private TreeNode BuildTreeHelper(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
    {
        if (preStart > preEnd || inStart > inEnd) return null;

        int rootValue = preorder[preStart];
        var root = new TreeNode(rootValue);

        int rootIdxIn = Array.IndexOf(inorder, rootValue);
        int leftSubtreeSize = rootIdxIn - inStart;

        root.left = BuildTreeHelper(preorder, preStart + 1, preStart + leftSubtreeSize, inorder, inStart, rootIdxIn - 1);
        root.right = BuildTreeHelper(preorder, preStart + leftSubtreeSize + 1, preEnd, inorder, rootIdxIn + 1, inEnd);
        return root;
    }
}

public class Solution2
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 0 || inorder.Length == 0) return null;
        TreeNode root = new TreeNode(preorder[0]);
        Stack<TreeNode> stack = new();
        stack.Push(root);
        int inorderIdx = 0;
        for (int i = 1; i < preorder.Length; i++)
        {
            var node = stack.Peek();
            if (node.val != inorder[inorderIdx])
            {
                node.left = new TreeNode(preorder[i]);
                stack.Push(node.left);
            }
            else
            {
                while (stack.Count > 0 && stack.Peek().val == inorder[inorderIdx])
                {
                    node = stack.Pop();
                    inorderIdx++;
                }
                node.right = new TreeNode(preorder[i]);
                stack.Push(node.right);
            }
        }
        return root;
    }
}