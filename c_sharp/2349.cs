public class NumberContainers
{

    private Dictionary<int, int> store;
    private Dictionary<int, PriorityQueue<int,int>> indexSequence;

    public NumberContainers()
    {
        store = new();
        indexSequence = new();
    }

    public void Change(int index, int number)
    {
        store[index] = number;

        if (!indexSequence.ContainsKey(number) ) indexSequence[number] = new PriorityQueue<int,int>();
        indexSequence[number].Enqueue(index, index);
    }

    public int Find(int number)
    {
        if (!indexSequence.ContainsKey(number)) return -1;

        while (indexSequence[number].Count > 0){
            var peeked = indexSequence[number].Peek();

            if (store[peeked] == number){
                return peeked;
            }

            indexSequence[number].Dequeue();
        }

        return -1;

    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */