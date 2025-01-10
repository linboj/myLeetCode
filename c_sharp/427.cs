/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

public class Solution
{
    public Node Construct(int[][] grid)
    {
        return DFS(grid, 0, grid.Length, 0, grid[0].Length);
    }

    private Node DFS(int[][] grid, int rStart, int rEnd, int cStart, int cEnd)
    {
        if (rStart == rEnd || cStart == cEnd) return new Node(grid[rStart][cEnd] == 1, true);
        int currentGrid = grid[rStart][cStart];
        for (int row = rStart; row < rEnd; row++)
        {
            for (int col = cStart; col < cEnd; col++)
            {
                if (currentGrid != grid[row][col])
                {
                    var node = new Node(true, false);
                    node.topLeft = DFS(grid, rStart, (rStart + rEnd) / 2, cStart, (cStart + cEnd) / 2);
                    node.topRight = DFS(grid, rStart, (rStart + rEnd) / 2, (cStart + cEnd) / 2, cEnd);
                    node.bottomLeft = DFS(grid, (rStart + rEnd) / 2, rEnd, cStart, (cStart + cEnd) / 2);
                    node.bottomRight = DFS(grid, (rStart + rEnd) / 2, rEnd, (cStart + cEnd) / 2, cEnd);
                    return node;
                }
            }
        }
        return new Node(currentGrid == 1, true);
    }
}

public class Solution2
{
    public Node Construct(int[][] grid)
    {
        return Construct(grid, 0, grid.Length - 1, 0, grid[0].Length - 1);
    }

    private Node Construct(int[][] grid, int rStart, int rEnd, int cStart, int cEnd)
    {
        if (rStart == rEnd || cStart == cEnd) return new Node(grid[rStart][cEnd] == 1, true);

        var topLeft = Construct(grid, rStart, (rStart + rEnd) / 2, cStart, (cStart + cEnd) / 2);
        var topRight = Construct(grid, rStart, (rStart + rEnd) / 2, (cStart + cEnd) / 2 + 1, cEnd);
        var bottomLeft = Construct(grid, (rStart + rEnd) / 2 + 1, rEnd, cStart, (cStart + cEnd) / 2);
        var bottomRight = Construct(grid, (rStart + rEnd) / 2 + 1, rEnd, (cStart + cEnd) / 2 + 1, cEnd);
        
        if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf &&
            topLeft.val == topRight.val && topRight.val == bottomLeft.val && bottomLeft.val == bottomRight.val
        )
        {
            return new Node(topLeft.val, true);
        }
        else
        {
            return new Node(true, false, topLeft, topRight, bottomLeft, bottomRight);
        }

    }
}