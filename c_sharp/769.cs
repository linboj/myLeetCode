public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        
        // prefix sum
        /*
        int n = arr.Length;
        int chunks = 0, prefixSum = 0, sortedPrefixSum = 0;
        for (int i = 0; i < n; i++)
        {
            prefixSum += arr[i];
            sortedPrefixSum += i;
            if (prefixSum == sortedPrefixSum) chunks++;
        }

        return chunks;
        */

        // Monotonic Increasing Stack
        /*
        int n = arr.Length;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            if (stack.Count == 0 || arr[i] > stack.Peek()) stack.Push(arr[i]);
            else {
                int maxElement = stack.Pop();
                while (stack.Count != 0 && arr[i] < stack.Peek()){
                    stack.Pop();
                }
                stack.Push(maxElement);
            }
        }
        return stack.Count;
        */

        // Maximum Element
        int n = arr.Length;
        int chunks = 0, maxElement = 0;
        for (int i = 0; i < n; i++)
        {
            maxElement = Math.Max(maxElement, arr[i]);
            if (maxElement == i) chunks++;
        }
        return chunks;
    }
}