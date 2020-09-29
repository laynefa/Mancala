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
                player2AvailableTurn = true;
                pocketNumber = ChoosePocket("P1");
                player1AvailableTurn = board.Player1Move(pocketNumber);
                while (!player1AvailableTurn && player2AvailableTurn)
                {
                    board.PrintBoard();
                    if (!board.IsGameOver())
                    {
                        //Move to player 2 turn
                        //board.PrintBoard();
                        if (!cpuEnable)
                            pocketNumber = ChoosePocket("P2");
                        else
                            Console.WriteLine("CPU Turn...\n");
                        player2AvailableTurn = board.Player2Move(pocketNumber);
                    }
                    else
                    {
                        //board.PrintBoard();
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

        static int ChoosePocket(string player)
        {
            Console.Write(player + ": Choose pocket to move: ");
            int pocketNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            return pocketNumber;
        }
    }
}
