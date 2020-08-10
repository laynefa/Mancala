using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Board
    {
        Player player1;
        Player player2;
        bool player1Turn;

        public Board()
        {
            player1 = new Player();
            player2 = new Player();
            player1Turn = true;
        }

        public void PrintBoard()
        {
            string lineOne;
            string lineTwo;
            string lineThree;
            lineOne = "    " + player2.ReversePrintPockets();
            lineTwo = player2.store.GetCount().ToString() + "\t\t       " + player1.store.GetCount().ToString();
            lineThree = "    " + player1.PrintPockets();

            Console.WriteLine(lineOne);
            Console.WriteLine(lineTwo);
            Console.WriteLine(lineThree);
            Console.WriteLine();
        }

        public bool Player1Move(int pocketNumber)
        {
            int stonesToMove = player1.pockets[pocketNumber - 1].Take();
            if (stonesToMove != 0)
                return MovePocketStones(pocketNumber - 1, stonesToMove, player1, player2);
            else
            {
                Console.WriteLine("Pick pocket that has stones\n");
                return false;
            }
        }

        public bool Player2Move(int pocketNumber)
        {
            int stonesToMove = player2.pockets[pocketNumber - 1].Take();
            if (stonesToMove != 0)
                return MovePocketStones(pocketNumber - 1, stonesToMove, player2, player1);
            else
            {
                Console.WriteLine("Pick pocket that has stones\n");
                return false;
            }
        }

        public bool MovePocketStones(int pocketNumber, int stonesToMove, Player player, Player opponent)
        {
            for (int i = pocketNumber + 1; i < 6; i++)
            {
                player.pockets[i].Add(1);
                stonesToMove--;
                if (stonesToMove == 0)
                {
                    // Check if current pocket has one stone (had 0 previous to add operation). if so, check if opposite pocket has stones. If it does, take stones and add to player store
                    if (player.pockets[i].stones == 1 && opponent.pockets[5-i].stones > 0)
                        player.store.Add(opponent.pockets[5-i].Take() + player.pockets[i].Take());
                    return false; // player turn complete
                }
            }
            player.store.Add(1);
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
                return MovePocketStones(-1, stonesToMove, player, opponent);
            }
        }

    }
}
