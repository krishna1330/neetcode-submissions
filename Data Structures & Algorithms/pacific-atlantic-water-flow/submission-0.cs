public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        int n = heights.Length;
        int m = heights[0].Length;
        bool[,] pacificVisited = new bool[n, m];
        bool[,] atlanticVisited = new bool[n, m];

        for (int j = 0; j < m; j++) {
            if (!pacificVisited[0, j]) {
                Dfs(heights, 0, j, pacificVisited, atlanticVisited, "pacific");
            }
            if (!atlanticVisited[n - 1, j]) {
                Dfs(heights, n - 1, j, pacificVisited, atlanticVisited, "atlantic");
            }
        }

        for (int i = 0; i < n; i++) {
            if (!pacificVisited[i, 0]) {
                Dfs(heights, i, 0, pacificVisited, atlanticVisited, "pacific");
            }
            if (!atlanticVisited[i, m - 1]) {
                Dfs(heights, i, m - 1, pacificVisited, atlanticVisited, "atlantic");
            }
        }

        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (pacificVisited[i, j] && atlanticVisited[i, j]) {
                    res.Add(new List<int>() { i, j });
                }
            }
        }

        return res;
    }

    private void Dfs(int[][] heights, int r, int c, bool[,] pacificVisited, bool[,] atlanticVisited,
                     string ocean) {
        if (ocean == "pacific") {
            pacificVisited[r, c] = true;
        } else if (ocean == "atlantic") {
            atlanticVisited[r, c] = true;
        }

        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++) {
            int nr = dr[i] + r;
            int nc = dc[i] + c;

            if (IsValidCell(heights, r, c, nr, nc, ocean, pacificVisited, atlanticVisited)) {
                Dfs(heights, nr, nc, pacificVisited, atlanticVisited, ocean);
            }
        }
    }

    private bool IsValidCell(int[][] heights, int r, int c, int nr, int nc, string ocean,
                             bool[,] pacificVisited, bool[,] atlanticVisited) {
        if (nr >= 0 && nr < heights.Length && nc >= 0 && nc < heights[0].Length &&
            heights[nr][nc] >= heights[r][c]) {
            if (ocean == "pacific") {
                return !pacificVisited[nr, nc];
            } else if (ocean == "atlantic") {
                return !atlanticVisited[nr, nc];
            }
        }
        return false;
    }
}
