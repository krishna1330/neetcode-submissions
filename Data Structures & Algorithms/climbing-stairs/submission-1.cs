public class Solution {
    public int ClimbStairs(int n) {
        int[] dp = new int[n + 1];
        Array.Fill(dp, -1);

        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++) {
            int one = dp[i - 1];
            int two = dp[i - 2];
            dp[i] = one + two;
        }

        return dp[n];
    }

    private int Helper(int ind, int[] dp) {
        if (ind == 0 || ind == 1) {
            return 1;
        } else if (dp[ind] != -1) {
            return dp[ind];
        }

        int one = Helper(ind - 1, dp);
        int two = Helper(ind - 2, dp);
        return dp[ind] = one + two;
    }
}
