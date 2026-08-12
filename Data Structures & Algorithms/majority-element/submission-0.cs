public class Solution {
    public int MajorityElement(int[] nums) {
        // Moore's Voting Algorithm
        int n = nums.Length;
        int candidate = 0, count = 0;
        foreach (int num in nums) {
            if (count == 0) {
                candidate = num;
            }
            if (candidate == num) {
                count++;
            } else {
                count--;
            }
        }

        count = nums.Count(x => x == candidate);
        if (count > n / 2) {
            return candidate;
        }
        return -1;
    }
}