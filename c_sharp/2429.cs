public class Solution
{
    public int MinimizeXor(int num1, int num2)
    {
        int ans = 0;

        int targetBitsCount = int.PopCount(num2);
        // int targetBitsCount = 0;
        // for (int i = 1; i <= num2; i *= 2)
        // {
        //     if ((num2 & i) == i) targetBitsCount++;
        // }
        int setBitsCount = 0;
        int currBit = 31;
        while (setBitsCount < targetBitsCount){
            if (isSet(num1, currBit) || (targetBitsCount - setBitsCount > currBit)){
                ans = setBit(ans, currBit);
                setBitsCount++;
            }
            currBit--;
        }
        return ans;
    }

    private bool isSet(int num, int bit)
    {
        return (num & (1 << bit)) != 0;
    }

    private int setBit(int num, int bit)
    {
        return num | (1 << bit);
    }
}