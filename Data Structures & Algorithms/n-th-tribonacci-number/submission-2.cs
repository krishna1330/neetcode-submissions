public class Solution {
    public int Tribonacci(int n) {
        if (n == 0) {
            return 0;
        } else if (n == 1 || n == 2) {
            return 1;
        }
        int[] dp = new int[n + 1];
        // Array.Fill(dp, -1);
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;
        for (int i = 3; i <= n; i++) {
            dp[i] = dp[i - 3] + dp[i - 2] + dp[i - 1];
        }
        return dp[n];
        // return Helper(n, dp);
    }

    private int Helper(int n, int[] dp) {
        if (n == 0) {
            dp[0] = 0;
            return 0;
        } else if (n == 1) {
            dp[1] = 1;
            return 1;
        } else if (n == 2) {
            dp[2] = 1;
            return 1;
        } else if (dp[n] != -1) {
            return dp[n];
        }
        return Helper(n - 1, dp) + Helper(n - 2, dp) + Helper(n - 3, dp);
    }
}