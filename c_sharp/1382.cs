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
    public TreeNode BalanceBST(TreeNode root)
    {
        if (root == null) return null;

        TreeNode vineHead = new TreeNode(0);
        vineHead.right = root;
        var current = vineHead;
        while (current.right != null)
        {
            if (current.right.left != null)
            {
                RightRotation(current, current.right);
            }
            else
            {
                current = current.right;
            }
        }

        int cnt = 0;
        current = vineHead.right;
        while (current != null)
        {
            cnt++;
            current = current.right;
        }

        int m = (int)Math.Pow(2, Math.Floor(Math.Log2(cnt + 1))) - 1;
        MakeRotations(vineHead, cnt - m);
        while (m > 1)
        {
            m /= 2;
            MakeRotations(vineHead, m);
        }

        return vineHead.right;
    }

    private void RightRotation(TreeNode parent, TreeNode node)
    {
        var tmp = node.left;
        node.left = tmp.right;
        tmp.right = node;
        parent.right = tmp;
    }

    private void LeftRotation(TreeNode parent, TreeNode node)
    {
        var tmp = node.right;
        node.right = tmp.left;
        tmp.left = node;
        parent.right = tmp;
    }

    private void MakeRotations(TreeNode vineHead, int count)
    {
        TreeNode current = vineHead;
        for (int i = 0; i < count; i++)
        {
            TreeNode tmp = current.right;
            LeftRotation(current, tmp);
            current = current.right;
        }
    }
}