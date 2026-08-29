public class Solution {
    public void Solve(char[][] board) {
        int n = board.Length;
        int m = board[0].Length;
        bool[,] visited = new bool[n, m];

        for (int c = 0; c < m; c++) {
            if (board[0][c] == 'O' && !visited[0, c]) {
                Dfs(0, c, board, visited);
            }
            if (board[n - 1][c] == 'O' && !visited[n - 1, c]) {
                Dfs(n - 1, c, board, visited);
            }
        }

        for (int r = 0; r < n; r++) {
            if (board[r][0] == 'O' && !visited[r, 0]) {
                Dfs(r, 0, board, visited);
            }
            if (board[r][m - 1] == 'O' && !visited[r, m - 1]) {
                Dfs(r, m - 1, board, visited);
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (board[i][j] == 'O' && !visited[i, j]) {
                    board[i][j] = 'X';
                }
            }
        }
    }

    private void Dfs(int r, int c, char[][] board, bool[,] visited) {
        visited[r, c] = true;
        int[] dr = new int[] { -1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        for (int i = 0; i < 4; i++) {
            int nr = r + dr[i];
            int nc = c + dc[i];
            if (IsValidCell(nr, nc, board) && board[nr][nc] == 'O' && !visited[nr, nc]) {
                Dfs(nr, nc, board, visited);
            }
        }
    }

    private bool IsValidCell(int r, int c, char[][] board) {
        return r >= 0 && r < board.Length && c >= 0 && c < board[0].Length;
    }
}
