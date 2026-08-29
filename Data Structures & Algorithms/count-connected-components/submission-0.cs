public class Solution {
    public int CountComponents(int n, int[][] edges) {
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

        int count = 0;
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++) {
            if (!visited[i]) {
                Dfs(i, adj, visited);
                count++;
            }
        }

        return count;
    }

    private void Dfs(int node, Dictionary<int, List<int>> adj, bool[] visited) {
        visited[node] = true;
        if (!adj.ContainsKey(node)) {
            return;
        }

        foreach (int nei in adj[node]) {
            if (!visited[nei]) {
                Dfs(nei, adj, visited);
            }
        }
    }
}
