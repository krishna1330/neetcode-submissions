public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> dict = new();
        foreach (string str in strs) {
            char[] charArr = str.ToCharArray();
            Array.Sort(charArr);
            string key = new string(charArr);

            if (dict.ContainsKey(key)) {
                dict[key].Add(str);
            } else {
                dict[key] = new List<string>() { str };
            }
        }

        List<List<string>> anagrams = new();
        foreach (var kvp in dict) {
            anagrams.Add(kvp.Value);
        }

        return anagrams;
    }
}
