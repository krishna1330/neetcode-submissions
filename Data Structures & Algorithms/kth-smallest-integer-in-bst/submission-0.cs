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
    public int KthSmallest(TreeNode root, int k) {
        List<int> inorder = new List<int>();
        Dfs(root, inorder);
        return inorder[k - 1];
    }

    private void Dfs(TreeNode root, List<int> inorder) {
        if (root == null) {
            return;
        }
        Dfs(root.left, inorder);
        inorder.Add(root.val);
        Dfs(root.right, inorder);
    }
}
