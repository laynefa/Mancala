using System;

namespace Mancala
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameComplete = false;
            Board board;
            Console.Write("Vs CPU? y/n: ");
            bool cpuEnable = false;
            if (Console.ReadLine() == "y")
            {
                board = new Board(new Player(), new CpuPlayer());
                cpuEnable = true;
            }
            else
                board = new Board(new Player(), new Player());
            bool player1AvailableTurn;
            bool player2AvailableTurn;
            int pocketNumber;
            while (!gameComplete)
            {
                board.PrintBoard();
                player1AvailableTurn = true;
                player2AvailableTurn = true;
                Console.Write("P1: Choose pocket to move: ");
                pocketNumber = Int32.Parse(Console.ReadLine());
                Console.WriteLine();
                player1AvailableTurn = board.Player1Move(pocketNumber);
                while (!player1AvailableTurn && player2AvailableTurn)
                {
                    if (!board.IsGameOver())
                    {
                        //Move to player 2 turn
                        board.PrintBoard();
                        if (!cpuEnable)
                        {
                            Console.Write("P2: Choose pocket to move: ");
                            pocketNumber = Int32.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        else
                            Console.WriteLine("CPU Turn...\n");
                        player2AvailableTurn = board.Player2Move(pocketNumber);
                    }
                    else
                    {
                        board.PrintBoard();
                        Console.WriteLine("Game Over!");
                        board.PrintResult();
                        Console.WriteLine("Play again? y/n");
                        if (Console.ReadLine() == "y")
                        {
                            board = new Board();
                            gameComplete = false;

                        }
                        else
                            gameComplete = true;
                    }
                }
            }
        }
    }
}
