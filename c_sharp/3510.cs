public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int n = nums.Length;
        PriorityQueue<Item, Item> pq = new();
        bool[] merged = new bool[n];
        int decCnt = 0, ans = 0;
        List<Node> nodes = new();
        nodes.Add(new Node(nums[0], 0));

        for (int i = 1; i < n; i++)
        {
            nodes.Add(new Node(nums[i], i));
            nodes[i - 1].next = nodes[i];
            nodes[i].prev = nodes[i - 1];
            var item = new Item(nodes[i - 1], nodes[i], nodes[i - 1].val + nodes[i].val);
            pq.Enqueue(item, item);

            if (nums[i - 1] > nums[i]) decCnt++;
        }

        while (decCnt > 0)
        {
            var item = pq.Dequeue();
            Node first = item.first;
            Node second = item.second;
            long cost = item.cost;

            if (merged[first.pos] || merged[second.pos] || first.val + second.val != cost)
                continue;

            ans++;

            if (first.val > second.val)
                decCnt--;

            Node prevNode = first.prev;
            Node nextNode = second.next;
            first.next = nextNode;

            if (prevNode != null)
            {
                if (prevNode.val > first.val && prevNode.val <= cost)
                    decCnt--;
                else if (prevNode.val <= first.val && prevNode.val > cost)
                    decCnt++;

                var newItem = new Item(prevNode, first, prevNode.val + cost);

                pq.Enqueue(newItem, newItem);
            }

            if (nextNode != null)
            {
                nextNode.prev = first;

                if (second.val > nextNode.val && cost <= nextNode.val)
                    decCnt--;
                else if (second.val <= nextNode.val && cost > nextNode.val)
                    decCnt++;

                var newItem = new Item(first, nextNode, cost + nextNode.val);
                pq.Enqueue(newItem, newItem);
            }

            first.val = cost;
            merged[second.pos] = true;
        }
        return ans;
    }

    public class Node
    {
        public long val;
        public int pos;
        public Node prev;
        public Node next;

        public Node(long val, int pos)
        {
            this.val = val;
            this.pos = pos;
        }
    }

    public class Item : IComparable<Item>
    {
        public Node first;
        public Node second;
        public long cost;
        public Item(Node first, Node second, long cost)
        {
            this.cost = cost;
            this.first = first;
            this.second = second;
        }

        public int CompareTo(Item other)
        {
            if (cost == other.cost)
                return first.pos.CompareTo(other.first.pos);

            return cost.CompareTo(other.cost);
        }
    }
}