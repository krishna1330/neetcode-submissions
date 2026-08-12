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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val);
        }

        TreeNode curr = root;
        TreeNode prev = root;

        while (curr != null) {
            if (curr.val < val) {
                prev = curr;
                curr = curr.right;
            } else if (curr.val > val) {
                prev = curr;
                curr = curr.left;
            }
        }

        if (curr == null) {
            if (prev.val > val) {
                prev.left = new TreeNode(val);
            } else {
                prev.right = new TreeNode(val);
            }
        }

        return root;
    }
}