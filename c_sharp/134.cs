public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int totalGas = 0;
        int startIdx = 0;
        int curGas = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            int gasGain = gas[i] - cost[i];
            totalGas += gasGain;
            curGas += gasGain;

            if (curGas < 0)
            {
                startIdx = i + 1;
                curGas = 0;
            }
        }

        return totalGas >= 0 ? startIdx : -1;
    }
}