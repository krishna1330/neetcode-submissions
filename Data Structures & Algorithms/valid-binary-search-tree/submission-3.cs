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
    public bool IsValidBST(TreeNode root) {
        return IsValid(root, int.MinValue, int.MaxValue);
    }

    private bool IsValid(TreeNode root, int mini, int maxi) {
        if (root == null) {
            return true;
        }
        if (root.val <= mini || root.val >= maxi) {
            return false;
        }
        return IsValid(root.left, mini, root.val) && IsValid(root.right, root.val, maxi);
    }
}
