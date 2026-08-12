public class MyHashSet {
    bool[] exists;

    public MyHashSet() {
        this.exists = new bool[1000000];
    }

    public void Add(int key) {
        this.exists[key] = true;
    }

    public void Remove(int key) {
        this.exists[key] = false;
    }

    public bool Contains(int key) {
        return this.exists[key];
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */