public class MyHashSet {
    public ListNode head;

    public MyHashSet() {
        this.head = null;
    }

    public void Add(int key) {
        if (this.head == null) {
            this.head = new ListNode(key);
            return;
        }

        if (this.Contains(key)) {
            return;
        }

        ListNode curr = this.head;
        while (curr.next != null) {
            curr = curr.next;
        }
        curr.next = new ListNode(key);
    }

    public void Remove(int key) {
        if (this.head == null) {
            return;
        }

        if (this.head.val == key) {
            this.head = this.head.next;
            return;
        }

        ListNode prev = this.head, curr = this.head.next;
        while (curr != null) {
            if (curr.val == key) {
                prev.next = curr.next;
                return;
            }
            prev = curr;
            curr = curr.next;
        }
    }

    public bool Contains(int key) {
        ListNode curr = this.head;
        while (curr != null) {
            if (curr.val == key) {
                return true;
            }
            curr = curr.next;
        }
        return false;
    }
}

public class ListNode {
    public ListNode next;
    public int val;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */