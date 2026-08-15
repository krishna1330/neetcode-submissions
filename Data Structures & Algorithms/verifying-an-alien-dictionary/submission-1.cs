public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i = 0; i < order.Length; i++) {
            dict[order[i]] = i;
        }

        for (int i = 0; i < words.Length - 1; i++) {
            string word1 = words[i];
            string word2 = words[i + 1];
            if (word1 == word2) {
                continue;
            }

            int length = Math.Min(word1.Length, word2.Length);
            for (int j = 0; j < length; j++) {
                char c1 = word1[j];
                char c2 = word2[j];
                if (c1 == c2) {
                    continue;
                } else if (dict[c1] > dict[c2]) {
                    return false;
                } else {
                    break;
                }
            }

            if (word1.Length > word2.Length && word1.Substring(0, length) == word2) {
                return false;
            }
        }

        return true;
    }
}