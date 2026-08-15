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

public class Codec {
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        if (root == null) {
            return "";
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        List<string> data = new List<string>();

        while (queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            if (node != null) {
                data.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            } else {
                data.Add("#");
            }
        }

        return string.Join(",", data);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if (string.IsNullOrEmpty(data)) {
            return null;
        }

        string[] values = data.Split(",");
        TreeNode root = new TreeNode(int.Parse(values[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0) {
            TreeNode node = queue.Dequeue();
            string val = values[index++];

            if (val == "#") {
                node.left = null;
            } else {
                node.left = new TreeNode(int.Parse(val));
                queue.Enqueue(node.left);
            }

            val = values[index++];
            if (val == "#") {
                node.right = null;
            } else {
                node.right = new TreeNode(int.Parse(val));
                queue.Enqueue(node.right);
            }
        }

        return root;
    }
}
