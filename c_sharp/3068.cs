public class Solution
{
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long sum = 0;
        int count = 0, minGain = int.MaxValue, minLoss = int.MaxValue;

        foreach (var node in nums)
        {
            int oxrNode = node ^ k;

            if (oxrNode > node)
            {
                sum += oxrNode;
                minGain = Math.Min(minGain, oxrNode - node);
                count++;
            }
            else
            {
                sum += node;
                minLoss = Math.Min(minLoss, node - oxrNode);
            }
        }

        if (count % 2 == 0)
            return sum;

        return Math.Max(sum - minGain, sum - minLoss);
    }
}