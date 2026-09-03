public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length+1];
        // Array.Fill(dp, -1);
        dp[0] = cost[0];
        dp[1] = cost[1];
        for (int i=2; i<cost.Length; i++) {
            int oneStep = cost[i] + dp[i-1];
            int twoStep = cost[i] + dp[i-2];
            dp[i] = Math.Min(oneStep, twoStep);
        }
        return Math.Min(dp[cost.Length-1], dp[cost.Length-2]);
        // return Helper(cost.Length, cost, dp);
    }

    private int Helper(int floor, int[] cost, int[] dp) {
        if (floor < 0) {
            return 0;
        } else if (dp[floor] != -1) {
            return dp[floor];
        }
        int currCost = 0;
        if (floor != cost.Length) {
            currCost = cost[floor];
        }
        int oneStep = currCost + Helper(floor - 1, cost, dp);
        int twoStep = currCost + Helper(floor - 2, cost, dp);
        return dp[floor] = Math.Min(oneStep, twoStep);
    }
}
