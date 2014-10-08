using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Block
    {
        private List<Index> block = new List<Index>();
        
        private Block(Index index) {
             block.Add(index);

        }

        private void AddIndexes(Index index)
        {
            block.Add(index);
        }

        public List<Index> Indexes    
        {
            get
            {
                return block;
            }
        }
    }
}
