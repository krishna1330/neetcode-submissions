public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[][] visited = new bool [n][];
        for (int i = 0; i < n; i++) {
            visited[i] = new bool[m];
        }
        int maxArea = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 1 && !visited[i][j]) {
                    maxArea = Math.Max(maxArea, Dfs(grid, visited, i, j));
                }
            }
        }

        return maxArea;
    }

    private int Dfs(int[][] grid, bool[][] visited, int r, int c) {
        visited[r][c] = true;
        int area = 1;
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++) {
            int nrow = dr[i] + r;
            int ncol = dc[i] + c;

            if (IsValidCell(grid, nrow, ncol) && grid[nrow][ncol] == 1 && !visited[nrow][ncol]) {
                area += Dfs(grid, visited, nrow, ncol);
            }
        }

        return area;
    }

    private bool IsValidCell(int[][] grid, int r, int c) {
        int n = grid.Length;
        int m = grid[0].Length;
        return r >= 0 && r < n && c >= 0 && c < m;
    }
}
