public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        int[] indegrees = new int[numCourses];
        for (int i = 0; i < prerequisites.Length; i++) {
            int u = prerequisites[i][0];
            int v = prerequisites[i][1];
            if (!adj.ContainsKey(v)) {
                adj[v] = new List<int>();
            }
            adj[v].Add(u);
            indegrees[u]++;
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegrees[i] == 0) {
                queue.Enqueue(i);
            }
        }

        if (queue.Count == 0) {
            return new int[0];
        }

        List<int> topos = new List<int>();
        while (queue.Count > 0) {
            int node = queue.Dequeue();
            topos.Add(node);

            if (!adj.ContainsKey(node)) {
                continue;
            }

            foreach (int nei in adj[node]) {
                indegrees[nei]--;
                if (indegrees[nei] == 0) {
                    queue.Enqueue(nei);
                }
            }
        }

        if (topos.Count != numCourses) {
            return new int[0];
        }

        int[] res = new int[numCourses];
        for (int i = 0; i < numCourses; i++) {
            res[i] = topos[i];
        }

        return res;
    }
}
