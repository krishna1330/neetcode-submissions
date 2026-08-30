public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        int n = accounts.Count;
        Dictionary<string, int> mailsDict = new Dictionary<string, int>();
        DisjointSet dsu = new DisjointSet(n);

        for (int i = 0; i < n; i++) {
            for (int j = 1; j < accounts[i].Count; j++) {
                string mail = accounts[i][j];
                if (!mailsDict.ContainsKey(mail)) {
                    mailsDict[mail] = i;
                } else {
                    dsu.Union(mailsDict[mail], i);
                }
            }
        }

        Dictionary<int, List<string>> usersMails = new Dictionary<int, List<string>>();
        foreach (var kvp in mailsDict) {
            string mail = kvp.Key;
            int userIndex = kvp.Value;
            int rootUser = dsu.Find(userIndex);
            if (!usersMails.ContainsKey(rootUser)) {
                usersMails[rootUser] = new List<string>();
            }
            usersMails[rootUser].Add(mail);
        }

        List<List<string>> res = new List<List<string>>();
        foreach (var kvp in usersMails) {
            int userIndex = kvp.Key;
            List<string> mails = kvp.Value;
            mails.Sort();
            List<string> temp = new List<string>();
            temp.Add(accounts[userIndex][0]);
            temp.AddRange(mails);
            res.Add(temp);
        }

        return res;
    }
}

public class DisjointSet {
    private int[] parent;
    private int[] size;

    public DisjointSet(int n) {
        parent = new int[n + 1];
        size = new int[n + 1];
        for (int i = 0; i < n + 1; i++) {
            parent[i] = i;
            size[i] = 1;
        }
    }

    public int Find(int node) {
        if (parent[node] == node) {
            return node;
        }
        return parent[node] = Find(parent[node]);
    }

    public void Union(int u, int v) {
        int up = Find(u);
        int vp = Find(v);
        if (up == vp) {
            return;
        } else if (size[up] < size[vp]) {
            parent[up] = vp;
            size[vp] += size[up];
        } else {
            parent[vp] = up;
            size[up] += size[vp];
        }
    }
}