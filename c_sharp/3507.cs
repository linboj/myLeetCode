public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int ans = 0;
        List<int> list = nums.ToList();


        while (list.Count > 1)
        {
            int minSum = int.MaxValue;
            int idx = 0;
            bool isValid = true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                var sum = list[i] + list[i + 1];

                if (list[i] > list[i + 1])
                    isValid = false;

                if (sum < minSum)
                {
                    minSum = sum;
                    idx = i;
                }
            }

            if (isValid)
                break;

            ans++;
            list[idx] = minSum;
            list.RemoveAt(idx + 1);
        }
        return ans;
    }
}