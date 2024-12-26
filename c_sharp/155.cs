public class MinStack2
{

    private Stack<(int val, int minValue)> _stack;
    private int _min = int.MaxValue;
    public MinStack2()
    {
        _stack = new Stack<(int, int)>();
    }

    public void Push(int val)
    {
        if (_min > val) _min = val;
        _stack.Push((val, _min));
    }

    public void Pop()
    {
        _stack.Pop();
        if (_stack.Count > 0)
        {
            _min = _stack.Peek().minValue;
        }
        else
        {
            _min = int.MaxValue;
        }
    }

    public int Top()
    {
        return _stack.Peek().val;
    }

    public int GetMin()
    {
        return _stack.Peek().minValue;
    }
}

public class MinStack
{

    private class Node
    {
        public Node() { }
        public Node(int val, int min, Node next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
        public Node next;
        public int val;
        public int min;
    }

    private Node _head;
    public MinStack()
    {
        _head = new Node();
    }

    public void Push(int val)
    {
        if (_head.next == null)
        {
            _head = new Node(val, val, _head);
        }
        else
        {
            _head = new Node(val, Math.Min(val,_head.min), _head);
        }
    }

    public void Pop()
    {
        _head = _head.next;
    }

    public int Top()
    {
        return _head.val;
    }

    public int GetMin()
    {
        return _head.min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */