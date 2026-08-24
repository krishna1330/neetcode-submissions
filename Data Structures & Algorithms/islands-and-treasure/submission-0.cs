public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[,] visited = new bool[n, m];

        // Traverse the grid and the chests to the queue
        Queue<(int, int)> chests = new Queue<(int, int)>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 0) {
                    chests.Enqueue((i, j));
                }
            }
        }

        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        while (chests.Count > 0) {
            var (r, c) = chests.Dequeue();
            visited[r, c] = true;
            for (int i = 0; i < 4; i++) {
                int nrow = dr[i] + r;
                int ncol = dc[i] + c;

                if (IsValidCell(grid, nrow, ncol) && grid[nrow][ncol] == int.MaxValue &&
                    !visited[nrow, ncol]) {
                    grid[nrow][ncol] = grid[r][c] + 1;
                    chests.Enqueue((nrow, ncol));
                }
            }
        }
    }

    private bool IsValidCell(int[][] grid, int r, int c) {
        int n = grid.Length;
        int m = grid[0].Length;
        return r >= 0 && r < n && c >= 0 && c < m;
    }
}
