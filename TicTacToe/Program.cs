using System;

namespace TicTacToe
{
    class TicTacToeGame
    {
        public enum Player { USER, COMPUTER };
        public enum GameStatus { WON, FULL_BOARD, CONTINUE };


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

            Player player = GetWhoStartsFirst();

            bool gameIsPlaying = true;
            GameStatus gameStatus;

            while (gameIsPlaying)
            {
                if (player.Equals(Player.USER))
                {
                    int usermove = getUserMove(board);
                    string wonMessage = "Hooraay! U have won the game";
                    gameStatus = getGameStatus(board, usermove, ch, wonMessage);
                    player = Player.COMPUTER;

                }

                else
                {
                    string wonMessage = "Oops! Computer defeated you!"
                    int computerMove = GetComputerMove(board, comp_ch, ch);
                    gameStatus = getGameStatus(board, computerMove, comp_ch, wonMessage);
                    player = Player.USER;
                }
                if (gameStatus.Equals(GameStatus.CONTINUE)) continue;
                gameIsPlaying = false;
            }

            

        }

        private static GameStatus getGameStatus(char[] board, int move, char letter, string wonMessage) 
        {
            Move(board, move, letter);
            if(IsWinner(board,letter)) 
            {
                Console.WriteLine(wonMessage);
                return GameStatus.WON;
            }
            if (IsBoardFull(board)) 
            {
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }

            return GameStatus.CONTINUE;
        }

        private static bool IsBoardFull(char[] board) 
        {
        for(int i=1;i<board.Length;i++)
            {
                if (board[i] == ' ') return false;
                
            }
            return true;
        }

        private static int getUserMove(char[] board)
        {
            Console.WriteLine("What is your next move? ");
            int index = Convert.ToInt32(Console.ReadLine());
            bool valid_index = false;
            while (valid_index == false)
            {
                if (0 < index && index < 10)
                {
                    if (board[index] == ' ')
                    {
                        return index;
                    }
                    else
                    {
                        Console.WriteLine("The index is occupied. Please enter another index");
                        index = Convert.ToInt32(Console.ReadLine());
                    }
                }
                else
                {
                    Console.WriteLine("The index is invalid. Please enter another index");
                    index = Convert.ToInt32(Console.ReadLine());
                }
            }
            return index;
        }

        private static Player GetWhoStartsFirst()
        {
            int chance = Toss();
            return (chance == 1) ? Player.USER : Player.COMPUTER;

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
            for (int i = 1; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    char[] boardCopy = BoardCopy(board);
                    Move(boardCopy, i, ch);
                    if (IsWinner(boardCopy, ch)) return i;

                }
            }
            return 0;
        }


        private static int getRandomMoveFromList(char[] board, int[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
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
            int[] corner_moves = { 1, 3, 7, 9 };
            int computer_move = getRandomMoveFromList(board, corner_moves);
            if (computer_move != 0) return computer_move;
            if (board[5] == ' ') return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            computer_move = getRandomMoveFromList(board, sideMoves);
            return 0;
        }
    }
}