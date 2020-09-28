using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mancala
{
    class CpuPlayer : Player
    {
        List<int> options = Enumerable.Range(1, 6).ToList();
        readonly Random rand = new System.Random();

        public override bool TakeTurn(int pocketNumber, Player opponent)
        {
            // logic for cpu to automatically choose a pocket
            pocketNumber = options[rand.Next(0, options.Count)];
            options.Remove(pocketNumber);
            return base.TakeTurn(pocketNumber, opponent);
        }
    }
}
