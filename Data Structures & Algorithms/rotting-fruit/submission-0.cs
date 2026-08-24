public class Solution {
    public int OrangesRotting(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        bool[,] visited = new bool[n, m];
        Queue<(int, int)> rotten = new Queue<(int, int)>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 2) {
                    rotten.Enqueue((i, j));
                    visited[i, j] = true;
                }
            }
        }

        int time = 0;
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        while (rotten.Count > 0) {
            int count = rotten.Count;

            for (int val = 0; val < count; val++) {
                var (r, c) = rotten.Dequeue();
                for (int i = 0; i < 4; i++) {
                    int nr = dr[i] + r;
                    int nc = dc[i] + c;
                    if (IsValidCell(grid, nr, nc) && grid[nr][nc] == 1 && !visited[nr, nc]) {
                        rotten.Enqueue((nr, nc));
                        visited[nr, nc] = true;
                    }
                }
            }

            if (rotten.Count > 0) {
                time += 1;
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (!visited[i, j] && grid[i][j] == 1) {
                    return -1;
                }
            }
        }
        return time;
    }

    private bool IsValidCell(int[][] grid, int r, int c) {
        return r >= 0 && r < grid.Length && c >= 0 && c < grid[0].Length;
    }
}
