using System;

namespace TicTacToe
{
    class TicTacToeGame
    {

        static void Main(string[] args)
        {
            char[] board;

            board = Createboard();
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

        private void Choosexoro()
        {
            char compOption;
            char playerOption = Convert.ToChar(Console.ReadLine());
            if (playerOption == 'x')   compOption = 'o'; 
            else compOption = 'x';
        

        }
    }
}