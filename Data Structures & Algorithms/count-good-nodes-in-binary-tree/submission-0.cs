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
    public int GoodNodes(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int count = 1;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                TreeNode node = queue.Dequeue();
                if (node.left != null) {
                    if (node.left.val >= node.val) {
                        count++;
                    }
                    node.left.val = Math.Max(node.left.val, node.val);
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    if (node.right.val >= node.val) {
                        count++;
                    }
                    node.right.val = Math.Max(node.right.val, node.val);
                    queue.Enqueue(node.right);
                }
            }
        }

        return count;
    }
}
