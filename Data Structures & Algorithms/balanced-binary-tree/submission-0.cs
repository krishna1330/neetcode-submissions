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
    public bool IsBalanced(TreeNode root) {
        return MaxDepth(root) != -1;
    }

    private int MaxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);

        if (left == -1 || right == -1) {
            return -1;
        } else if (Math.Abs(left - right) > 1) {
            return -1;
        }
        return 1 + Math.Max(left, right);
    }
}
