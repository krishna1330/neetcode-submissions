/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int Rob(TreeNode root) {
        return GetMaxMoney(root).Max();
    }

    private int[] GetMaxMoney(TreeNode root) {
        if (root == null) {
            return new int[2];  // [rob_this, do_not_rob_this]
        }

        int[] left = GetMaxMoney(root.left);
        int[] right = GetMaxMoney(root.right);
        int rob = root.val + left[1] + right[1];
        int notRob = left.Max() + right.Max();
        return new int[] { rob, notRob };
    }
}