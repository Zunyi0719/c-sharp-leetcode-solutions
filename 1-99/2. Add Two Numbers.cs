/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode ret = new ListNode(-1);
        ListNode cur = ret;
        
        int carry = 0;
        while(l1!=null || l2!=null)
        {
            int sum = 0;
            if(l1!=null)
            {
                sum += l1.val;
                l1 = l1.next;
            }
            if(l2!=null)
            {
                sum += l2.val;
                l2 = l2.next;
            }
            sum += carry;
            if(sum >= 10)
            {
                sum -= 10;
                carry = 1;
            }
            else
            {
                carry = 0;
            }
            cur.next = new ListNode(sum);
            cur = cur.next;
        }
        
        if(carry == 1) 
        {
            cur.next = new ListNode(1);
        }
        
        return ret.next == null? new ListNode(0):ret.next;
    }
}
