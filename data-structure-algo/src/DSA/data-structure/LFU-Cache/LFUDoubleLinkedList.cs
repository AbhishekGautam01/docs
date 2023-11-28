using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.LFU_Cache
{
    public class LFUDoubleLinkedList
    {
        private LFUNode Head;
        private LFUNode Tail;
        public int Count { get; set; }
        public LFUDoubleLinkedList()
        {
            Head = new LFUNode();
            Tail = new LFUNode();
            Head.Next = Tail;
            Tail.Previous = Head;
            Count = 0;
        }

        public void AddToTop(LFUNode node)
        {
            node.Previous = Head;
            node.Next = Head;
            node.Next.Previous = node;
            Head.Next = node; 
            Count++;
        }

        public void RemoveNode(LFUNode node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.Previous = null;
            node.Next = null;
            Count--;
        }

        public LFUNode RemoveaLFUNode()
        {
            LFUNode target = Tail.Previous;
            RemoveNode(target);
            return target;
        }
    }
}
