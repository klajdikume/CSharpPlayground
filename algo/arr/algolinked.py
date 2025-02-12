from typing import Optional

# create linked list to call deleteDuplicates
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

    # Helper function to create a linked list from a list of values
    def create_linked_list(values):
        if not values:
            return None
        head = ListNode(values[0])
        current = head
        for value in values[1:]:
            current.next = ListNode(value)
            current = current.next
        return head
    
    # Helper function to print the linked list
    def print_linked_list(head):
        current = head
        while current:
            print(current.val, end=" -> ")
            current = current.next
        print("None")

class Solution:
    def __init__(self):
        pass
    def deleteDuplicates(self, head: Optional[ListNode]) -> Optional[ListNode]:  # type: ignore
        current = head
        while current:
            if current.next and current.val == current.next.val:
                current.next = current.next.next
            else:
                current = current.next
        return head
        
    def reverseLinkedList(self, head: Optional[ListNode]) -> Optional[ListNode]:  # type: ignore
        prev = None
        current = head
        while current:
            next_node = current.next
            current.next = prev
            prev = current
            current = next_node
        return prev
    
    def mergeTwoSortedLists(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        dummy = ListNode()
        tail = dummy

        while l1 and l2:
            if l1.val < l2.val:
                tail.next = l1
                l1 = l1.next
            else:
                tail.next = l2
                l2 = l2.next
                tail = tail.next

        if l1:
            tail.next = l1
        elif l2:
            tail.next = l2

        return dummy.next
    
if __name__ == '__main__':
    a = Solution()
    
    # Create a linked list with duplicates
    values = [1, 1, 2, 3, 3]
    head = ListNode.create_linked_list(values)

    # Print the original linked list
    print("Original linked list:")
    ListNode.print_linked_list(head)

    # Call deleteDuplicates and print the result
    print("Linked list after removing duplicates:")
    result = a.deleteDuplicates(head)
    ListNode.print_linked_list(result)
    

    