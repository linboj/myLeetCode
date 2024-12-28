public class LRUCache
{

    private int capacity = 0;
    private Dictionary<int, LinkedListNode<(int Key, int Value)>> _cacheMap;
    private LinkedList<(int Key, int Value)> _cacheList;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        _cacheMap = new();
        _cacheList = new();
    }

    public int Get(int key)
    {
        if (_cacheMap.TryGetValue(key, out var node))
        {
            _cacheList.Remove(node);
            _cacheList.AddFirst(node);
            return node.Value.Value;
        }
        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cacheMap.TryGetValue(key, out var node))
        {
            _cacheList.Remove(node);
            node.ValueRef.Value = value;
            _cacheList.AddFirst(node);
        }
        else
        {
            if (_cacheList.Count >= capacity)
            {
                var removeKey = _cacheList.Last.Value.Key;
                _cacheMap.Remove(removeKey);
                _cacheList.RemoveLast();
            }
            var newNode = new LinkedListNode<(int Key, int Value)>((key, value));
            _cacheMap.Add(key, newNode);
            _cacheList.AddFirst(newNode);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */