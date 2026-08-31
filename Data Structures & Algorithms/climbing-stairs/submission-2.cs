public class Solution {
    public int ClimbStairs(int n) {
        int prev2 = 1;
        int prev1 = 1;

        for (int i = 2; i <= n; i++) {
            int one = prev1;
            int two = prev2;
            int curr = prev1 + prev2;
            prev2 = prev1;
            prev1 = curr;
        }

        return prev1;
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
