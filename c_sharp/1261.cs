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
public class FindElements
{
    // DFS
    private HashSet<int> _elements = new HashSet<int>();

    public FindElements(TreeNode root)
    {
        if (root == null) return;

        root.val = 0;
        _elements.Add(root.val);
        DFS(root.left, 1);
        DFS(root.right, 2);
    }

    public bool Find(int target)
    {
        return _elements.Contains(target);
    }

    private void DFS(TreeNode node, int targetValue)
    {
        if (node == null) return;

        node.val = targetValue;
        _elements.Add(node.val);
        DFS(node.left, targetValue * 2 + 1);
        DFS(node.right, targetValue * 2 + 2);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */

public class FindElements2
{
    // binary search
    private TreeNode _root;
    public FindElements(TreeNode root)
    {
        _root = root;
    }

    public bool Find(int target)
    {
        if (target == 0) return true;

        target++;
        int depth = int.Log2(target);
        var node = _root;

        var low = 1 << depth;
        var high = (1 << (depth + 1)) - 1;

        while (depth > 0 && node != null){
            var mid = (low + high) / 2;
            if (mid >= target){
                if (node.left == null) return false;

                high = mid;
                node = node.left;
            }else{
                if (node.right == null) return false;

                low = mid+1;
                node = node.right;
            }
            depth--;
        }
        return true;
    }
}