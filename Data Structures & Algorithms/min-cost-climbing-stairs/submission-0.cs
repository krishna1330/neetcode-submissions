public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.Length+1];
        Array.Fill(dp, -1);
        return Helper(cost.Length, cost, dp);
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
