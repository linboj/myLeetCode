public class Solution
{
    public int CountHillValley(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        int currentIdx = 1;
        int rightIdx = currentIdx;

        while (rightIdx < n)
        {
            currentIdx = rightIdx;
            rightIdx++;
            int leftIdx = currentIdx - 1;
            while (leftIdx >= 0 && nums[leftIdx] == nums[currentIdx])
                leftIdx--;

            if (leftIdx < 0)
                continue;

            if (nums[leftIdx] < nums[currentIdx])
            {
                while (rightIdx < n && nums[rightIdx] == nums[currentIdx])
                    rightIdx++;

                if (rightIdx >= n)
                    continue;

                if (nums[rightIdx] < nums[currentIdx])
                    ans++;
            }
            else
            {
                while (rightIdx < n && nums[rightIdx] == nums[currentIdx])
                    rightIdx++;

                if (rightIdx >= n)
                    continue;

                if (nums[rightIdx] > nums[currentIdx])
                    ans++;
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int CountHillValley(int[] nums)
    {
        int ans = 0;
        int n = nums.Length;
        List<int> flat = new();

        flat.Add(nums[0]);
        for (int i = 1; i < n; i++)
        {
            if (nums[i] != nums[i - 1])
                flat.Add(nums[i]);
        }

        for (int i = 1; i < flat.Count - 1; i++)
        {
            if ((flat[i - 1] < flat[i] && flat[i + 1] < flat[i]) || (flat[i - 1] > flat[i] && flat[i + 1] > flat[i]))
                ans++;
        }
        return ans;
    }
}