public class FindSumPairs
{

    private Dictionary<int, int> cnts = new();
    private int[] nums1;
    private int[] nums2;

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;
        foreach (var num2 in nums2)
        {
            cnts.TryGetValue(num2, out int count);
            cnts[num2] = count + 1;
        }
    }

    public void Add(int index, int val)
    {
        int oldVal = nums2[index];
        cnts[oldVal]--;
        nums2[index] += val;
        cnts.TryGetValue(nums2[index], out int count);
        cnts[nums2[index]] = count + 1;
    }

    public int Count(int tot)
    {
        int ans = 0;
        foreach (var num1 in nums1)
        {
            int required = tot - num1;
            if (cnts.ContainsKey(required))
            {
                ans += cnts[required];
            }
        }
        return ans;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.Add(index,val);
 * int param_2 = obj.Count(tot);
 */