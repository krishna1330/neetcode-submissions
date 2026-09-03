// ============================= Space optimization ===============================
public class Solution 
{
    public int Rob(int[] nums) 
    {
        int n = nums.Length;        
        int prev2 = 0;
        int prev1 = nums[0];

        for (int index = 1; index < n; index++)
        {
            int pick = nums[index];
            if (index - 2 >= 0) pick += prev2;
            int notPick = prev1;
            int curr = Math.Max(pick, notPick);

            prev2 = prev1;
            prev1 = curr;
        }

        return prev1;
    }
}

// ============================= Tabulation ===============================
// public class Solution 
// {
//     public int Rob(int[] nums) 
//     {
//         int n = nums.Length;
//         int[] dp = new int[n];
//         Array.Fill(dp, -1);
//         dp[0] = nums[0];

//         for (int index = 1; index < n; index++)
//         {
//             int pick = nums[index];
//             if (index - 2 >= 0) pick += dp[index - 2];
//             int notPick = dp[index - 1];
//             dp[index] = Math.Max(pick, notPick);
//         }

//         return dp[n - 1];
//     }

// ============================= Memoization ===============================
// public class Solution 
// {
//     public int Rob(int[] nums) 
//     {
//         int n = nums.Length;
//         int[] dp = new int[n];
//         Array.Fill(dp, -1);
//         return Helper(n - 1, nums, dp);
//     }

//     private int Helper(int index, int[] nums, int[] dp)
//     {
//         if (index < 0) return 0;
//         if (index == 0) return nums[0];
//         if (dp[index] != -1) return dp[index];

//         int pick = nums[index] + Helper(index - 2, nums, dp);
//         int notPick = Helper(index - 1, nums, dp);
//         return dp[index] = Math.Max(pick, notPick);
//     }
// }

// ============================= Recursion ===============================
// public class Solution 
// {
//     public int Rob(int[] nums) 
//     {
//         int n = nums.Length;
//         return Helper(n - 1, nums);
//     }

//     private int Helper(int index, int[] nums)
//     {
//         if (index < 0) return 0;
//         if (index == 0) return nums[0];

//         int pick = nums[index] + Helper(index - 2, nums);
//         int notPick = Helper(index - 1, nums);
//         return Math.Max(pick, notPick);
//     }
// }