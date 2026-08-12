public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int n = nums.Length;
        int index = 0;
        for (int i = 0; i < n; i++) {
            if (nums[i] != val) {
                (nums[i], nums[index]) = (nums[index], nums[i]);
                index++;
            }
        }
        return index;
    }
}