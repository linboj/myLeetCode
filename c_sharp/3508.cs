public class Router
{
    private record Packet(int source, int destination, int timestamp) { }
    private int size;
    private Dictionary<int, List<int>> counts;
    private HashSet<Packet> packets;
    private Queue<Packet> queue;
    public Router(int memoryLimit)
    {
        size = memoryLimit;
        counts = new();
        packets = new();
        queue = new();
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        Packet packet = new Packet(source, destination, timestamp);

        if (packets.Contains(packet))
            return false;

        if (packets.Count == size)
            ForwardPacket();

        packets.Add(packet);
        queue.Enqueue(packet);

        if (!counts.ContainsKey(destination))
            counts[destination] = new();
        counts[destination].Add(timestamp);
        return true;
    }

    public int[] ForwardPacket()
    {
        if (packets.Count == 0)
            return [];

        var packet = queue.Dequeue();
        if (!packets.Contains(packet))
            return [];

        packets.Remove(packet);

        var timestamps = counts[packet.destination];
        timestamps.Remove(packet.timestamp);

        return new int[] { packet.source, packet.destination, packet.timestamp };

    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        if (!counts.ContainsKey(destination))
            return 0;
        var timestamps = counts[destination];
        if (timestamps == null || timestamps.Count == 0)
            return 0;

        int left = LowerBound(timestamps, startTime);
        int right = UpperBound(timestamps, endTime);

        return right - left;
    }

    private int LowerBound(List<int> list, int target)
    {
        int low = 0, high = list.Count;

        while (low < high)
        {
            int mid = (low + high) >> 1;
            if (list[mid] < target)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }

    private int UpperBound(List<int> list, int target)
    {
        int low = 0, high = list.Count;

        while (low < high)
        {
            int mid = (low + high) >> 1;

            if (list[mid] <= target)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */