using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Block
    {
        private List<Index> indexes = new List<Index>();
        
        public Block() {
             

        }
        public override string ToString()
        {  string str = "(";
        for (int i = 0; i < indexes.Count; i++)
        {

            str += indexes[i] + ",";
            }
            return str + ")";
        }
            
        
        public void AddIndexes(Index index)
        {
            indexes.Add(index);
        }

        public List<Index> Indexes    
        {
            get
            {
                return indexes;
            }
        }
    }
}
