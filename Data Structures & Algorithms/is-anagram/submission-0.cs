public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        int[] freq = new int[26];
        for (int i = 0; i < s.Length; i++) {
            int sIndex = s[i] - 97;
            int tIndex = t[i] - 97;
            freq[sIndex]++;
            freq[tIndex]--;
        }

        foreach (int num in freq) {
            if (num != 0) {
                return false;
            }
        }

        return true;
    }
}
