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
    public int MaxPathSum(TreeNode root) {
        if (root == null) {
            return 0;
        }
        int[] arr = new int[] { int.MinValue };
        Postorder(root, arr);
        return arr[0];
    }

    private int Postorder(TreeNode root, int[] arr) {
        if (root == null) {
            return 0;
        }
        int left = Postorder(root.left, arr);
        int right = Postorder(root.right, arr);
        int maxLeft = Math.Max(0, left);
        int maxRight = Math.Max(0, right);
        arr[0] = Math.Max(arr[0], root.val + maxLeft + maxRight);
        return root.val + Math.Max(maxLeft, maxRight);
    }
}
