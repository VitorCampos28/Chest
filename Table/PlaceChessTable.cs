using System;
using xadrez.GameChess;

namespace xadrez.Table
{
    class PlaceChessTable
    {
        public static void placechess(GameTable gametable)
        {

            for (int i = 0; i < gametable.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gametable.Columns; j++)
                {
                    if (gametable.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(gametable.piece(i, j));
                        Console.Write(" ");
                    }
                   
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");

        }

        public static void printPiece(Piece piece)
        {
            if (piece.Color  == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
    }
}
