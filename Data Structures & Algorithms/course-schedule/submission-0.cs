public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        for (int i = 0; i < prerequisites.Length; i++) {
            int u = prerequisites[i][0];
            int v = prerequisites[i][1];
            if (!adj.ContainsKey(v)) {
                adj[v] = new List<int>();
            }
            adj[v].Add(u);
        }

        bool[] visited = new bool[numCourses];
        bool[] pathVisited = new bool[numCourses];

        for (int i = 0; i < numCourses; i++) {
            if (!visited[i]) {
                if (Dfs(i, adj, visited, pathVisited)) {
                    return false;
                }
            }
        }

        return true;
    }

    private bool Dfs(int node, Dictionary<int, List<int>> adj, bool[] visited, bool[] pathVisited) {
        visited[node] = true;
        pathVisited[node] = true;
        if (!adj.ContainsKey(node)) {
            pathVisited[node] = false;
            return false;
        }

        foreach (int nei in adj[node]) {
            if (!visited[nei]) {
                if (Dfs(nei, adj, visited, pathVisited)) {
                    return true;
                }
            } else if (pathVisited[nei]) {
                return true;
            }
        }

        pathVisited[node] = false;
        return false;
    }
}
