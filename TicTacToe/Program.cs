using System;

namespace TicTacToe
{
    class TicTacToeGame
    {

        static void Main(string[] args)
        {
            char[] board;

            board = Createboard();
            Console.WriteLine("moving to choose x/o");
            char userletter = Choosexoro();
            Console.WriteLine("Printing board starting.....");
            PrintingTheBoard(board);
        }

        private static char[] Createboard()
        {
            char[] board = new char[10];
            for (int i = 1; i < 10; i++)
            {
                board[i] = ' ';
            }

            return board;
        }

        private static char Choosexoro()
        {
            char userletter = Convert.ToChar(Console.ReadLine());
            return userletter;

        }

        private static void PrintingTheBoard(char[] board)
        {
            Console.WriteLine("Printing the board......");

            for (int i = 1; i < 10; i++)
            {
                Console.Write(board[i]);
                Console.Write(" ");
                if (i % 3 == 0) Console.WriteLine("");

            }
        }
    }
}