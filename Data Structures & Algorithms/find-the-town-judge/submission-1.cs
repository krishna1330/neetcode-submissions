public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[,] adj = new int[n + 1, n + 1];
        for (int i = 0; i < trust.Length; i++) {
            int ai = trust[i][0];
            int bi = trust[i][1];
            adj[ai, bi] = 1;
        }

        for (int i = 1; i < n + 1; i++) {
            bool isValid = true;
            for (int j = 1; j < n + 1; j++) {
                if (i == j) {
                    continue;
                } else if (adj[i, j] == 1) {
                    isValid = false;
                    break;
                }
            }

            if (isValid && CheckVerticalRow(adj, i)) {
                return i;
            }
        }

        return -1;
    }

    private bool CheckVerticalRow(int[,] adj, int col) {
        int n = adj.GetLength(0);
        for (int i = 1; i < n; i++) {
            if (i != col && adj[i, col] == 0) {
                return false;
            }
        }
        return true;
    }
}