using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Pocket
    {
        public int stones;
        bool empty;

        public Pocket()
        {
            stones = 4;
            empty = false;
        }

        public void Add(int stoneCount)
        {
            if (IsEmpty())
                empty = false;
            stones += stoneCount;
        }

        public int Take()
        {
            if (stones == 0)
                return stones;
            int movingStones = stones;
            stones = 0;
            empty = true;
            return movingStones;
        }

        public bool IsEmpty()
        {
            return empty;
        }
    }
}
