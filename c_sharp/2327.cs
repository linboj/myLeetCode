public class Solution
{
    private const int MOD = 1_000_000_007;
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        Queue<(int day, int count)> known = new();
        Queue<(int day, int count)> share = new();
        int knownCount = 1, shareCount = 0;
        known.Enqueue((1, 1));

        for (int i = 2; i <= n; i++)
        {
            if (known.Count != 0 && known.Peek().day == i - delay)
            {
                var pop = known.Dequeue();
                knownCount = (knownCount - pop.count + MOD) % MOD;
                shareCount = (shareCount + pop.count) % MOD;
                share.Enqueue(pop);
            }

            if (share.Count != 0 && share.Peek().day == i - forget)
            {
                var pop = share.Dequeue();
                shareCount = (shareCount - pop.count + MOD) % MOD;
            }

            if (share.Count != 0)
            {
                knownCount = (knownCount + shareCount) % MOD;
                known.Enqueue((i, shareCount));
            }
        }
        return (knownCount + shareCount) % MOD;
    }
}