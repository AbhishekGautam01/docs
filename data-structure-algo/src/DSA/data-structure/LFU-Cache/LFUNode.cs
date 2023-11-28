using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structure.LFU_Cache
{
    public class LFUNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public int Frequency { get; set; }
        public LFUNode Previous { get; set; }
        public LFUNode Next { get; set; }
        public LFUNode(int key , int value) {
            Key = key;
            Value = value;
            Frequency = 1;
        }

        public LFUNode() {
        }
    }
}
