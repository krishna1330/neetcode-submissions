public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        int n = strs.Length;
        StringBuilder sb = new();
        int index = 0;

        while (true) {
            if (index >= strs[0].Length) {
                return sb.ToString();
            }

            char c = strs[0][index];
            for (int i = 1; i < n; i++) {
                if (index >= strs[i].Length || strs[i][index] != c) {
                    return sb.ToString();
                }
            }

            sb.Append(c);
            index++;
        }
        return sb.ToString();
    }
}