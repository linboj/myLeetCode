public class Solution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        // Three Pointers
        int n = nums.Length;
        int maxSum = int.MinValue;

        int[] prefixSums = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        int[] leftMaxIdx = new int[n];
        int[] rightMaxIdx = new int[n];

        int[] result = new int[3];

        for (int i = k, currentMaxSum = prefixSums[k] - prefixSums[0]; i < n; i++)
        {
            if (prefixSums[i + 1] - prefixSums[i + 1 - k] > currentMaxSum)
            {
                leftMaxIdx[i] = i - k + 1;
                currentMaxSum = prefixSums[i + 1] - prefixSums[i + 1 - k];
            }
            else
            {
                leftMaxIdx[i] = leftMaxIdx[i - 1];
            }
        }

        rightMaxIdx[n - k] = n - k;
        for (int i = n - k - 1, currentMaxSum = prefixSums[n] - prefixSums[n - k]; i >= 0; i--)
        {
            if (prefixSums[i + k] - prefixSums[i] >= currentMaxSum)
            {
                rightMaxIdx[i] = i;
                currentMaxSum = prefixSums[i + k] - prefixSums[i];
            }
            else
            {
                rightMaxIdx[i] = rightMaxIdx[i + 1];
            }
        }

        for (int i = k; i <= n - 2 * k; i++)
        {
            int leftIdx = leftMaxIdx[i - 1];
            int rightIdx = rightMaxIdx[i + k];
            int totalSum = prefixSums[i + k] - prefixSums[i] + prefixSums[leftIdx + k] - prefixSums[leftIdx] + prefixSums[rightIdx + k] - prefixSums[rightIdx];
            if (totalSum > maxSum)
            {
                maxSum = totalSum;
                result[0] = leftIdx;
                result[1] = i;
                result[2] = rightIdx;
            }
        }
        return result;
    }
}

public class Solution2
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        // Sliding Window
        int best1Start = 0;
        int[] best2Start = new int[] { 0, k };
        int[] best3Start = new int[] { 0, k, 2 * k };

        int currentWindowSum1 = 0;
        for (int i = 0; i < k; i++)
        {
            currentWindowSum1 += nums[i];
        }

        int currentWindowSum2 = 0;
        for (int i = k; i < 2 * k; i++)
        {
            currentWindowSum2 += nums[i];
        }

        int currentWindowSum3 = 0;
        for (int i = 2 * k; i < 3 * k; i++)
        {
            currentWindowSum3 += nums[i];
        }
        int best1Sum = currentWindowSum1;
        int best2Sum = currentWindowSum1 + currentWindowSum2;
        int best3Sum = currentWindowSum1 + currentWindowSum2 + currentWindowSum3;
        int startIndex1 = 1, startIndex2 = k + 1, startIndex3 = 2 * k + 1;
        while (startIndex3 <= nums.Length - k)
        {
            currentWindowSum1 += nums[startIndex1 + k - 1] - nums[startIndex1 - 1];
            currentWindowSum2 += nums[startIndex2 + k - 1] - nums[startIndex2 - 1];
            currentWindowSum3 += nums[startIndex3 + k - 1] - nums[startIndex3 - 1];
            if (currentWindowSum1 > best1Sum)
            {
                best1Start = startIndex1;
                best1Sum = currentWindowSum1;
            }

            if (currentWindowSum2 + best1Sum > best2Sum)
            {
                best2Start[0] = best1Start;
                best2Start[1] = startIndex2;
                best2Sum = currentWindowSum2 + best1Sum;
            }

            if (currentWindowSum3 + best2Sum > best3Sum)
            {
                best3Start[0] = best2Start[0];
                best3Start[1] = best2Start[1];
                best3Start[2] = startIndex3;
                best3Sum = currentWindowSum3 + best2Sum;
            }
            startIndex1++;
            startIndex2++;
            startIndex3++;
        }
        return best3Start;
    }
}