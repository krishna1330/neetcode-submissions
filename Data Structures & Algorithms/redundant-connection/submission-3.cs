public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        DisjointSet dsu = new DisjointSet(n + 1);
        for (int i = 0; i < edges.Length; i++) {
            int u = edges[i][0];
            int v = edges[i][1];

            if (dsu.IsConnected(u, v)) {
                return new int[] { u, v };
            }

            dsu.Union(u, v);
        }

        return Array.Empty<int>();
    }
}

public class DisjointSet {
    private int[] parent;
    private int[] size;

    public DisjointSet(int n) {
        parent = new int[n];
        size = new int[n];

        for (int i = 0; i < n; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int node) {
        if (node == parent[node]) {
            return node;
        }
        return parent[node] = Find(parent[node]);
    }

    public void Union(int u, int v) {
        int up = Find(u);
        int vp = Find(v);
        if (up == vp) {
            return;
        }

        if (size[up] < size[vp]) {
            parent[up] = vp;
            size[vp] += size[up];
        } else {
            parent[vp] = up;
            size[up] += size[vp];
        }
    }

    public bool IsConnected(int u, int v) {
        return Find(u) == Find(v);
    }
}