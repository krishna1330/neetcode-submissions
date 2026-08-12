public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int n = grid.Length;
        int m = grid[0].Length;
        int perimeter = 0;

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (grid[i][j] == 0) {
                    continue;
                }

                bool isLeftSideLand = false;
                bool isTopSideLand = false;
                if (j - 1 >= 0 && grid[i][j - 1] == 1) {
                    isLeftSideLand = true;
                }
                if (i - 1 >= 0 && grid[i - 1][j] == 1) {
                    isTopSideLand = true;
                }

                if (isLeftSideLand && isTopSideLand) {
                    continue;
                } else if (isLeftSideLand || isTopSideLand) {
                    perimeter += 2;
                } else {
                    perimeter += 4;
                }
            }
        }

        return perimeter;
    }
}