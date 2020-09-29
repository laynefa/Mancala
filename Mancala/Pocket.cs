using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Pocket
    {
        public int Stones { get; set; }
        bool empty;

        public Pocket()
        {
            Stones = 4;
            empty = false;
        }

        public void Add(int stoneCount)
        {
            if(IsEmpty())
                empty = false;
            Stones += stoneCount;
        }

        public int Take()
        {
            if (Stones == 0)
                return Stones;
            int movingStones = Stones;
            Stones = 0;
            empty = true;
            return movingStones;
        }

        public bool IsEmpty()
        {
            return empty;
        }
    }
}
