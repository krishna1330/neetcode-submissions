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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int n = inorder.Length;
        if (n == 0) {
            return null;
        }

        Dictionary<int, int> inorderMap = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            int val = inorder[i];
            inorderMap[val] = i;
        }

        return Build(preorder, inorder, inorderMap, 0, n - 1, 0, n - 1);
    }

    private TreeNode Build(int[] preorder, int[] inorder, Dictionary<int, int> inorderMap,
                           int inStart, int inEnd, int preStart, int preEnd) {
        if (inStart > inEnd || preStart > preEnd) {
            return null;
        }

        int rootValue = preorder[preStart];
        TreeNode root = new TreeNode(rootValue);
        int rootIndex = inorderMap[rootValue];
        int numsLeft = rootIndex - inStart;
        root.left = Build(preorder, inorder, inorderMap, inStart, rootIndex - 1, preStart + 1,
                          preStart + numsLeft);
        root.right = Build(preorder, inorder, inorderMap, rootIndex + 1, inEnd,
                           preStart + numsLeft + 1, preEnd);
        return root;
    }
}
