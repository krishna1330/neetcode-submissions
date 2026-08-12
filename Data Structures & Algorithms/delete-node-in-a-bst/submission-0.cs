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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if (root == null) {
            return root;
        }
        if (root.val == key) {
            return Connector(root);
        }

        TreeNode curr = root;
        while (curr != null) {
            if (key < curr.val) {
                if (curr.left != null && curr.left.val == key) {
                    curr.left = Connector(curr.left);
                    break;
                }
                curr = curr.left;
            } else {
                if (curr.right != null && curr.right.val == key) {
                    curr.right = Connector(curr.right);
                    break;
                }
                curr = curr.right;
            }
        }

        return root;
    }

    private TreeNode Connector(TreeNode keyNode) {
        if (keyNode.left == null) {
            return keyNode.right;
        }
        if (keyNode.right == null) {
            return keyNode.left;
        }

        TreeNode left = keyNode.left;
        TreeNode right = keyNode.right;
        TreeNode curr = left;

        while (curr.right != null) {
            curr = curr.right;
        }
        curr.right = right;
        return left;
    }
}