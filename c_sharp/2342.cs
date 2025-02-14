public class Solution
{
    public int MaximumSum(int[] nums)
    {
        Dictionary<int, PriorityQueue<int, int>> equalSumMap = new();

        foreach (var num in nums)
        {
            int sum = digitSum(num);

            if (!equalSumMap.ContainsKey(sum)) equalSumMap[sum] = new PriorityQueue<int, int>();
            equalSumMap[sum].Enqueue(num, -num);
        }
        int maxSum = -1;
        foreach (var (_, pq) in equalSumMap)
        {
            if (pq.Count > 1){
                int current = pq.Dequeue() + pq.Dequeue();
                if (current > maxSum) maxSum = current;
            }
        }
        return maxSum;
    }

    private int digitSum(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}

public class Solution2
{
    public int MaximumSum(int[] nums)
    {
        int maxDigitSum = digitSum((int)Math.Pow(10, 9) - 1);
        int[] maxSumInEachDigitSum = new int[maxDigitSum];
        int[] maxValueInEachDigitSum = new int[maxDigitSum];

        foreach (var num in nums)
        {
            int sum = digitSum(num) - 1;
            if (maxValueInEachDigitSum[sum] == 0){
                maxValueInEachDigitSum[sum] = num;
                continue;
            }
            maxSumInEachDigitSum[sum] = Math.Max(maxSumInEachDigitSum[sum], num + maxValueInEachDigitSum[sum]);
            maxValueInEachDigitSum[sum] = Math.Max(maxValueInEachDigitSum[sum], num);
        }

        int maxSum = -1;
        foreach (var pairSum in maxSumInEachDigitSum)
        {
            maxSum = Math.Max(maxSum, pairSum);
        }
        return maxSum == 0 ? -1 : maxSum;
    }

    private int digitSum(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}