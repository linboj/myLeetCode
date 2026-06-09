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
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        int n = descriptions.Length;
        Dictionary<int, TreeNode> map = new(2 * n);
        bool[] children = new bool[100001];

        foreach (var desc in descriptions)
        {
            int val = desc[0], childVal = desc[1];
            bool isLeft = desc[2] == 1;

            if (!map.ContainsKey(val))
            {
                map[val] = new TreeNode(val);
            }

            if (!map.ContainsKey(childVal))
            {
                map[childVal] = new TreeNode(childVal);
            }

            if (isLeft)
            {
                map[val].left = map[childVal];
            }
            else
            {
                map[val].right = map[childVal];
            }

            children[childVal] = true;
        }

        foreach (var val in map.Keys)
        {
            if (!children[val])
            {
                return map[val];
            }
        }

        return null;
    }
}