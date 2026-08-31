public class Solution {
    public int ClimbStairs(int n) {
        int[] dp = new int[n+1];
        Array.Fill(dp, -1);
        return Helper(n, dp);
    }

    private int Helper(int ind, int[] dp) {
        if (ind == 0 || ind == 1) {
            return 1;
        } else if (dp[ind] != -1) {
            return dp[ind];
        }

        int take = Helper(ind - 1, dp);
        int notTake = Helper(ind - 2, dp);
        return dp[ind] = take + notTake;
    }
}
