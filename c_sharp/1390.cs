public class Solution
{
    public int SumFourDivisors(int[] nums)
    {
        int ans = 0;

        foreach (var num in nums)
        {
            int sum = 0;
            int count = 0;

            for (int i = 1; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    int r = num / i;
                    if (r == i)
                    {
                        count++;
                        sum += i;
                    }
                    else
                    {
                        sum += i + r;
                        count += 2;
                    }

                    if (count > 4)
                        break;
                }
            }

            if (count == 4)
                ans += sum;
        }
        return ans;
    }
}