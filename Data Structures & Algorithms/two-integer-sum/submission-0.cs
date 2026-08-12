public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int n = nums.Length;
        int[] indices = new int[2];
        Dictionary<int, int> prefix = new();
        for (int i = 0; i < n; i++) {
            int diff = target - nums[i];
            if (prefix.ContainsKey(diff)) {
                indices[0] = Math.Min(i, prefix[diff]);
                indices[1] = Math.Max(i, prefix[diff]);
                return indices;
            }
            if (!prefix.ContainsKey(nums[i])) {
                prefix[nums[i]] = i;
            }
        }
        return indices;
    }
}
