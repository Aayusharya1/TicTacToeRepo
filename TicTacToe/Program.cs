using System;

namespace TicTacToe
{
    class TicTacToeGame
    {

        static void Main(string[] args)
        {


            char[] board = Createboard();
            Console.WriteLine("moving to choose x/o");
            char ch = Choosexoro();
            char comp_ch;
            if (ch == 'x') comp_ch = 'o';
            else comp_ch = 'x';
            Console.WriteLine(ch);
            Console.WriteLine("Printing board starting.....");
            PrintingTheBoard(board);
            Move(board, 5, ch);
            PrintingTheBoard(board);
            int m = GetWinningMove(board, 'x');
            Console.WriteLine("winning move is " + m);
            Move(board, 2, ch);
            PrintingTheBoard(board);
            int l = GetWinningMove(board, 'x');
            Console.WriteLine("winning move is " + l);
            Move(board, 6, ch);
            PrintingTheBoard(board);
            int k = GetWinningMove(board, 'x');
            Console.WriteLine("winning move is " + k);
            Move(board, 8, ch);
            PrintingTheBoard(board);
            int j = GetWinningMove(board, 'x');
            Console.WriteLine("winning move is " + j);
            Move(board, 1, ch);
            PrintingTheBoard(board);
            Console.WriteLine("Check if won " + IsWinner(board, ch));
            int i = GetWinningMove(board, 'x');
            Console.WriteLine("winning move is " + i);

            int comp_move = GetComputerMove(board, comp_ch, ch);

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
                Console.Write("|");
                if (i % 3 == 0) Console.WriteLine("");

            }
        }

        private static void Move(char[] board, int position, char letter)
        {
            bool value_inserted = false;
            while (value_inserted == false)
            {
              
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

        private static bool IsWinner(char[] b, char ch)
        {
            return (
                (b[1] == ch && b[2] == ch && b[3] == ch) ||
                (b[4] == ch && b[5] == ch && b[6] == ch) ||
                (b[7] == ch && b[8] == ch && b[9] == ch) ||
                (b[1] == ch && b[4] == ch && b[7] == ch) ||
                (b[2] == ch && b[5] == ch && b[8] == ch) ||
                (b[3] == ch && b[6] == ch && b[9] == ch) ||
                (b[1] == ch && b[5] == ch && b[9] == ch) ||
                (b[7] == ch && b[5] == ch && b[3] == ch));

        }

        private static char[] BoardCopy(char[] board) 
        {
            char[] boardCopy = new char[10];
            for (int i = 1; i < board.Length; i++)
            {
                boardCopy[i] = board[i];     
            }
            return boardCopy;
            
        }

        private static int GetWinningMove(char[] board, char ch) 
        {
            for(int i =1; i< board.Length; i++) 
            { if(board[i]==' ') 
                {
                    char[] boardCopy = BoardCopy(board);
                    Move(boardCopy,i, ch);
                    if (IsWinner(boardCopy,ch)) return i;

                }
            }
            return 0;
        }


        private static int getRandomMoveFromList(char[] board, int [] moves) 
        {
        for(int i=0; i < moves.Length; i++) 
            {
                if (board[moves[i]] == ' ') return moves[i];
            }
            return 0;
        }
        private static int GetComputerMove(char[] board, char comp_ch, char ch) 
        {
            int comp_winning_move = GetWinningMove(board, comp_ch);
            if (comp_winning_move != 0) return comp_winning_move;
            int user_winning_move = GetWinningMove(board, ch);
            if (user_winning_move != 0) return user_winning_move;
            int[] corner_moves = {1,3,7,9 };
            int computer_move = getRandomMoveFromList(board, corner_moves);
            if (computer_move != 0) return computer_move;
            return 0;
        }
    }
}