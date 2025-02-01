public class Solution {
    public int Candy(int[] ratings) {
        int[] given = new int[ratings.Length];
        given[0] = 1;
        for (int i = 0; i < ratings.Length - 1; i++){
            if (ratings[i] < ratings[i+1]) 
                given[i+1] = given[i] + 1;
            else
                given[i+1] = 1;
        }
        int ans = 0;
        for (int i = ratings.Length - 1; i > 0 ; i--)
        {
            ans += given[i];
            if (ratings[i] < ratings[i-1] && given[i-1] <= given[i])
                given[i-1] = given[i] + 1;
        }
        ans += given[0];
        return ans;
    }
}