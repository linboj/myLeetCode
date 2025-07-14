public class Solution
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        int n = players.Length, m = trainers.Length;
        int playerIdx = 0, trainerIdx = 0;
        Array.Sort(players);
        Array.Sort(trainers);

        for (; playerIdx < n && trainerIdx < m; trainerIdx++)
            if (players[playerIdx] <= trainers[trainerIdx])
                playerIdx++;
        return playerIdx;
    }
}

public class Solution2
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        int n = players.Length, m = trainers.Length;
        int playerIdx = 0, trainerIdx = 0;
        Array.Sort(players);
        Array.Sort(trainers);

        while (playerIdx < n && trainerIdx < m)
        {
            while (trainerIdx < m && players[playerIdx] > trainers[trainerIdx])
            {
                trainerIdx++;
            }

            if (trainerIdx >= m)
                break;

            playerIdx++;
            trainerIdx++;
        }
        return playerIdx;
    }
}