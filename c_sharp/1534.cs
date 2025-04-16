public class Solution
{
    public int CountGoodTriplets(int[] arr, int a, int b, int c)
    {
        int ans = 0, n = arr.Length;
        int[] sum = new int[1002];

        for (int j = 0; j < n; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                if (Math.Abs(arr[j] - arr[k]) <= b)
                {
                    int l = Math.Max(0, Math.Max(arr[j] - a, arr[k] - c));
                    int r = Math.Min(1000, Math.Min(arr[j] + a, arr[k] + c));

                    if (l <= r)
                    {
                        if (l == 0)
                            ans += sum[r];
                        else
                            ans += sum[r] - sum[l - 1];
                    }
                }
            }

            for (int i = arr[j]; i <= 1000; i++)
            {
                sum[i]++;
            }
        }
        return ans;
    }
}