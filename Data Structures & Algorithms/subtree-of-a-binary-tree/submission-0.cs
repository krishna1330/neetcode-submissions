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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();
                if (node.val == subRoot.val && IsSameTree(node, subRoot)) {
                    return true;
                }

                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
        }

        return false;
    }

    private bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        } else if (p != null && q == null) {
            return false;
        } else if (p == null && q != null) {
            return false;
        } else if (p.val != q.val) {
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
