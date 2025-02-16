public class Solution
{
    public int PunishmentNumber(int n)
    {
        int punishmentNum = 0;

        for (int currentNum = 1; currentNum <= n; currentNum++)
        {
            int squareNum = currentNum * currentNum;
            if (CanPartition(squareNum, currentNum))
            {
                punishmentNum += squareNum;
            }
        }
        return punishmentNum;
    }

    private bool CanPartition(int num, int target)
    {
        if (target < 0 || num < target) return false;

        if (num == target) return true;

        for (int i = 10; i < num; i *= 10)
        {
            if (CanPartition(num / i, target - (num % i))) return true;
        }
        return false;
    }
}