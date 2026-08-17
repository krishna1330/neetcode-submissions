public class Solution {
    public int FindJudge(int n, int[][] trust) {
        int[] score = new int[n + 1];
        for (int i = 0; i < trust.Length; i++) {
            int ai = trust[i][0];
            int bi = trust[i][1];
            score[ai]--;
            score[bi]++;
        }

        for (int i = 1; i <= n; i++) {
            if (score[i] == n - 1) {
                return i;
            }
        }

        return -1;
    }
}