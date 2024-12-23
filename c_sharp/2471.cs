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
    public int MinimumOperations(TreeNode root)
    {
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        int level = 0;
        int nOperation = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            int[] currentNodes = new int[size];

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                currentNodes[i] = node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            if (currentNodes.Length > 1)
            {
                nOperation += getMinSwaps(currentNodes);
            }
        }

        return nOperation;
    }

    private int getMinSwaps(int[] original)
    {
        int swaps = 0;
        int[] target = (int[])original.Clone();
        Array.Sort(target);

        Dictionary<int, int> pos = new();
        for (int i = 0; i < original.Length; i++)
        {
            pos.Add(original[i], i);
        }

        for (int i = 0; i < original.Length; i++)
        {
            if (original[i] != target[i])
            {
                swaps++;

                int curPos = pos[target[i]];
                pos[original[i]] = curPos;
                original[curPos] = original[i];
            }
        }
        return swaps;
    }
}