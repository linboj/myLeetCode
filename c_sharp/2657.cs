public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        int n = A.Length;
        int[] freq = new int[n];
        int[] result = new int[n];
        int count = 0;
        for (int i = 0; i < n; i++) {
            freq[A[i] - 1]++;
            if (freq[A[i]-1] == 2) count++;

            freq[B[i] - 1]++;
            if (freq[B[i]-1] == 2) count++;
            
            result[i] = count;
        }
        return result;
    }
}