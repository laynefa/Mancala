using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mancala
{
    class Store
    {
        int stones;

        public Store()
        {
            stones = 0;
        }

        public void Add(int stoneCount)
        {
            stones += stoneCount;
        }

        public int GetCount()
        {
            return stones;
        }
    }
}
