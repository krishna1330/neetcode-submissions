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
    public List<int> InorderTraversal(TreeNode root) {
        List<int> res = new List<int>();
        if (root == null) {
            return res;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode node = root;

        while (true) {
            if (node != null) {
                stack.Push(node);
                node = node.left;
            } else {
                if (stack.Count == 0) {
                    break;
                }
                node = stack.Pop();
                res.Add(node.val);
                node = node.right;
            }
        }

        return res;
    }
}