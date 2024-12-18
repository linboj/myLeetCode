public class RandomizedSet {

    private List<int> _nums;
    private Dictionary<int, int> _indexMap;
    private Random _random;

    public RandomizedSet() {
        _nums = new List<int>();
        _indexMap = new Dictionary<int,int>();
        _random = new Random();
    }
    
    public bool Insert(int val) {
        if (_indexMap.ContainsKey(val)) return false;

        _nums.Add(val);
        _indexMap[val] = _nums.Count - 1;
        return true;
    }
    
    public bool Remove(int val) {
        if (!_indexMap.ContainsKey(val)) return false;

        int lastElement = _nums[_nums.Count - 1];
        int valIdx = _indexMap[val];

        _nums[valIdx] = lastElement;
        _indexMap[lastElement] = valIdx;

        _nums.RemoveAt(_nums.Count - 1);
        _indexMap.Remove(val);

        return true;
    }
    
    public int GetRandom() {
        int randIdx = _random.Next(_nums.Count);
        return _nums[randIdx];
    }
}