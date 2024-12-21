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

// DFS
public class Solution {
    public TreeNode ReverseOddLevels(TreeNode root) {
        TraverseDFS(root.left, root.right, oddLevel);
        return root;
    }
    private void TraverseDFS(TreeNode leftChild, TreeNode rightChild, bool oddLevel) {
        if (leftChild == null || rightChild == null) return;

        if (oddLevel) (leftChild.val, rightChild.val) = (rightChild.val, leftChild.val);

        TraverseDFS(leftChild.left, rightChild.right, !oddLevel); 
        TraverseDFS(leftChild.right, rightChild.left, !oddLevel); 
    }
}

// BFS
/*
public class Solution {
    public TreeNode ReverseOddLevels(TreeNode root) {
        Queue<TreeNode> queue = new ();
        queue.Enqueue (root);
        int level = 0;

        while (queue.Count > 0) {
            int size = queue.Count;
            List<TreeNode> currentNodes = new ();

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                currentNodes.Add(node);

                if (node.left != null ) queue.Enqueue(node.left);
                if (node.right != null ) queue.Enqueue(node.right);                
            }

            if (level%2 == 1) {
                int left = 0, right = currentNodes.Count - 1;
                while (left < right) {
                    (currentNodes[left].val, currentNodes[right].val) = (currentNodes[right--].val, currentNodes[left++].val);
                }
            }

            level++;
        }

        return root;

    }
}
*/