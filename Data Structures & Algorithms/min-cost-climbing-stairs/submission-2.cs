public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length + 1];
        // Array.Fill(dp, -1);
        int prev = cost[1];
        int prev2 = cost[0];
        for (int i = 2; i < cost.Length; i++) {
            int oneStep = cost[i] + prev;
            int twoStep = cost[i] + prev2;
            int curr = Math.Min(oneStep, twoStep);
            prev2 = prev;
            prev = curr;
        }
        return Math.Min(prev, prev2);
        // return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
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
