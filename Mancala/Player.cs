using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Player
    {
        public Pocket[] pockets = new Pocket[6];
        public Store store;

        public Player()
        {
            for (int i = 0; i < 6; i++)
                pockets[i] = new Pocket();
            store = new Store();
        }

        public String PrintPockets()
        {
            string printedPockets = "";

            for (int i = 0; i < 6; i++)
            {
                printedPockets = printedPockets + pockets[i].stones.ToString() + "  ";
            }
            return printedPockets;
        }

        public String ReversePrintPockets()
        {
            string printedPockets = "";

            for (int i = 5; i >= 0; i--)
            {
                printedPockets = printedPockets + pockets[i].stones.ToString() + "  ";
            }
            return printedPockets;
        }

        public int GetScore()
        {
            return store.GetCount();
        }

        public String PrintScore()
        {
            return store.GetCount().ToString();
        }

        public bool CheckEmptyPockets()
        {
            for (int i = 0; i < 6; i++)
            {
                if (!pockets[i].IsEmpty())
                    return false;
            }
            return true;
        }

        public bool TakeTurn(int pocketNumber, Player opponent)
        {
            bool additionalTurn;
            if (pocketNumber > 0 && pocketNumber <= 6)
            {
                int stonesToMove = pockets[pocketNumber - 1].Take();
                if (stonesToMove != 0)
                {
                    additionalTurn = MovePocketStones(pocketNumber - 1, stonesToMove, opponent);
                    if (additionalTurn)
                        Console.WriteLine("Additional turn!");
                    return additionalTurn;
                }   
                else
                {
                    Console.WriteLine("Pick pocket that has stones\n");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Pick a valid pocket number on your side\n");
                return true;
            }
            
        }

        public bool MovePocketStones(int pocketNumber, int stonesToMove, Player opponent)
        {
            for (int i = pocketNumber + 1; i < 6; i++)
            {
                pockets[i].Add(1);
                stonesToMove--;
                if (stonesToMove == 0)
                {
                    // Check if current pocket has one stone (had 0 previous to add operation). if so, check if opposite pocket has stones. If it does, take stones and add to player store
                    if (pockets[i].stones == 1 && opponent.pockets[5 - i].stones > 0)
                        store.Add(opponent.pockets[5 - i].Take() + pockets[i].Take());
                    return false; // player turn complete
                }
            }
            store.Add(1);
            stonesToMove--;
            if (stonesToMove == 0)
                return true; // extra player move since turn ended in store
            else
            {
                // Start placing in opposing stores
                for (int i = 0; i < 6; i++)
                {
                    opponent.pockets[i].Add(1);
                    stonesToMove--;
                    if (stonesToMove == 0)
                        return false; // player turn complete
                }
                return MovePocketStones(-1, stonesToMove, opponent);
            }
        }
    }
}
