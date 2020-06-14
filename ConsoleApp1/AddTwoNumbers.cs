using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class AddTwoNumbers
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if(l1.val+l2.val>9)
            {
                ListNode l1Temp = l1.next, l2temp= l2.next;
                while (l1.next is null == false|| l2.next is null)
                {

                }
            }
        }
    }
}
