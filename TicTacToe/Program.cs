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
            Console.WriteLine(userletter);
            Console.WriteLine("Printing board starting.....");
            PrintingTheBoard(board);
            Move(board, userletter);
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
            int chance = Toss();
            if (chance == 1) return 'o';
            else return 'x';

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

        private static void Move(char[] board, char letter) 
        {
            bool value_inserted = false;
            while (value_inserted == false)
            {
                int position = Convert.ToInt32(Console.ReadLine());
                if (0 < position && position < 10)
                {
                    if (board[position] == ' ')
                    {
                        board[position] = letter;
                        value_inserted = true;
                    }
                    else Console.WriteLine("place is already filled or invalid position");
                }
            }
            
        }

        private static int Toss() 
        {
            Random random = new Random();
            int chance = random.Next(1, 3);
            return (chance);
        
        }
    }
}