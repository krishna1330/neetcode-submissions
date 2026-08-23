public class Solution {
    public int NumIslands(char[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[][] visited = new bool [n][];
        for (int i = 0; i < n; i++) {
            visited[i] = new bool[m];
        }
        int count = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == '1' && !visited[i][j]) {
                    count++;
                    Dfs(grid, visited, i, j);
                }
            }
        }

        return count;
    }

    private void Dfs(char[][] grid, bool[][] visited, int row, int col) {
        int n = grid.Length;
        int m = grid[0].Length;

        visited[row][col] = true;
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++) {
            int nrow = dr[i] + row;
            int ncol = dc[i] + col;
            if (nrow >= 0 && nrow < n && ncol >= 0 && ncol < m && !visited[nrow][ncol] &&
                grid[nrow][ncol] == '1') {
                Dfs(grid, visited, nrow, ncol);
            }
        }
    }
}
