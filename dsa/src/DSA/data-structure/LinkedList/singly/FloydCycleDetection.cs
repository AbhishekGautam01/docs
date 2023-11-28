using System.Collections.Generic;

namespace data_structure.linked_list.singly
{
    public static class FloydCycleDetection
    {
        //Method1: Using HashSet - If element is already present then it has cycle
        //Time Complexity: O(N)
        //Space Complexity: O(N)
        public static bool DoesCycleExists<T>(this LinkedList<T> linkedList)
        {
            if (linkedList.Head == null)
                return false;
            HashSet<Node<T>> set = new HashSet<Node<T>>();
            var current = linkedList.Head;
            while(current != null)
            {
                if (set.Contains(current))
                    return true;
                set.Add(current);
                current = current.Next;
            }
            return false; 
        }

        //Method 2: Flyod Cycle Detection Algortihm : Using Fast & Slow Pointers
        // https://www.youtube.com/watch?v=jcZtMh_jov0&list=PLUcsbZa0qzu3yNzzAxgvSgRobdUUJvz7p&index=40
        public static Node<T>  DoesCycleExistsFlyod<T>(this LinkedList<T> linkedList)
        {
            if (linkedList.Head == null)
                return null;
            
            var slowPtr = linkedList.Head;
            var fastPtr = linkedList.Head;  

            while(fastPtr != null && fastPtr.Next == null)
            {
                fastPtr = fastPtr.Next.Next;
                slowPtr = slowPtr.Next;

                if (fastPtr == slowPtr)
                    return slowPtr;
            }

            return null;
        }

        // This can be easily proved using mathematical induction. Proving theorem 
        // If the proof holds for 1, 2 Nodes it will hold for K nodes also. 
        public static Node<T> DetectedFirstNodeOfCycle<T>(this LinkedList<T> linkedList)
        {
            Node<T> meetingPoint = linkedList.DoesCycleExistsFlyod();
            Node<T> start = linkedList.Head;
            while (start != meetingPoint)
            {
                meetingPoint = meetingPoint.Next;
                start = start.Next; 
            }
            return start;
        }

        public static int CountCycleLen<T>(Node<T> node)
        {
            int count = 1;
            var temp = node; 
            while(temp != node)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }
    }
}
