using System;

namespace Mancala
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameComplete = false;
            Board board = new Board();
            bool player1ExtraTurn = false;
            bool player2ExtraTurn = false;
            int pocketNumber;
            while (!gameComplete)
            {
                board.PrintBoard();
                Console.Write("P1: Choose pocket to move: ");
                pocketNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                if (pocketNumber > 0 && pocketNumber <= 6)
                {
                    player1ExtraTurn = board.Player1Move(pocketNumber);
                    if (!player1ExtraTurn && !player2ExtraTurn)
                    {
                        //Move to player 2 turn
                        Console.Write("P2: Choose pocket to move: ");
                        pocketNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine();
                        if (pocketNumber > 0 && pocketNumber <= 6)
                        {
                            player2ExtraTurn = board.Player2Move(pocketNumber);
                        }
                    }
                }
                else
                    Console.WriteLine("Please pick a valid pocket number on your side\n");
            }
        }
    }
}
