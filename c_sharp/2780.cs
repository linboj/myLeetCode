public class Solution
{
    // Hash map
    public int MinimumIndex(IList<int> nums)
    {
        Dictionary<int, int> counts = new();
        int maxCount = 0, maxNum = 0;

        foreach (var num in nums)
        {
            if (!counts.ContainsKey(num)) counts[num] = 0;
            counts[num]++;

            if (counts[num] > maxCount)
            {
                maxCount = counts[num];
                maxNum = num;
            }
        }
        int n = nums.Count;
        int curNumCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == maxNum)
            {
                curNumCount++;
            }

            if (curNumCount * 2 > i + 1 && (maxCount - curNumCount) * 2 > n - i - 1)
                return i;
        }

        return -1;
    }
}

public class Solution2
{
    // Boyer-Moore Majority Voting Algorithm
    public int MinimumIndex(IList<int> nums)
    {
        int count = 0, maxNum = nums[0];

        foreach (var num in nums)
        {
            if (num == maxNum)
                count++;
            else
                count--;
            if (count == 0)
            {
                maxNum = num;
                count = 1;
            }
        }
        int maxCount = 0;
        foreach (var num in nums)
        {
            if (num == maxNum) maxCount++;
        }

        int n = nums.Count;
        int curNumCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == maxNum)
            {
                curNumCount++;
            }

            if (curNumCount * 2 > i + 1 && (maxCount - curNumCount) * 2 > n - i - 1)
                return i;
        }

        return -1;
    }
}