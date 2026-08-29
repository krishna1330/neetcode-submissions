public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // To be a valid tree, a graph should not have connected components and a cycle

        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        for (int i = 0; i < edges.Length; i++) {
            int u = edges[i][0];
            int v = edges[i][1];
            if (!adj.ContainsKey(u)) {
                adj[u] = new List<int>();
            }
            if (!adj.ContainsKey(v)) {
                adj[v] = new List<int>();
            }
            adj[u].Add(v);
            adj[v].Add(u);
        }

        bool[] visited = new bool[n];
        if (Dfs(0, -1, adj, visited)) {
            return false;
        }

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                return false;
            }
        }

        return true;
    }

    private bool Dfs(int node, int parent, Dictionary<int, List<int>> adj, bool[] visited) {
        visited[node] = true;
        if (!adj.ContainsKey(node)) {
            return false;
        }

        foreach (int nei in adj[node]) {
            if (!visited[nei]) {
                if (Dfs(nei, node, adj, visited)) {
                    return true;
                }
            } else if (nei != parent) {
                return true;
            }
        }

        return false;
    }
}
