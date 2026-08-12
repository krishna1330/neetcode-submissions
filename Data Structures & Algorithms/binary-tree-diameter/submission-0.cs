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
    public int DiameterOfBinaryTree(TreeNode root) {
        int[] diameter = new int[] { 0 };
        MaxDepth(root, diameter);
        return diameter[0];
    }

    private int MaxDepth(TreeNode root, int[] diameter) {
        if (root == null) {
            return 0;
        }

        int leftMax = MaxDepth(root.left, diameter);
        int rightMax = MaxDepth(root.right, diameter);
        diameter[0] = Math.Max(diameter[0], leftMax + rightMax);
        return 1 + Math.Max(leftMax, rightMax);
    }
}
