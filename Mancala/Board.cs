using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Board
    {
        Player player1;
        Player player2;
        bool gameEnd;

        public Board()
        {
            player1 = new Player();
            player2 = new Player();
            gameEnd = false;
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

        public void PrintResult()
        {
            int player1Score = player1.GetScore();
            int player2Score = player2.GetScore();
            Console.WriteLine("P1: " + player1.PrintScore());
            Console.WriteLine("P2: " + player2.PrintScore());
            if (player1Score > player2Score)
                Console.WriteLine("P1 Wins");
            else if (player2Score > player1Score)
                Console.WriteLine("P2 Wins");
            else
                Console.WriteLine("Tie");

        }

        public bool Player1Move(int pocketNumber)
        {
            bool result = player1.TakeTurn(pocketNumber, player2);
            gameEnd = player1.CheckEmptyPockets();
            return result;
        }

        public bool Player2Move(int pocketNumber)
        {
            bool result = player2.TakeTurn(pocketNumber, player1);
            gameEnd = player2.CheckEmptyPockets();
            return result;
        }

        public bool IsGameOver()
        {
            return gameEnd;
        }
    }
}
