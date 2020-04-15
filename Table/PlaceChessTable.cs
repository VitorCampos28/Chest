using System;
using System.Collections.Generic;
using xadrez.GameChess;

namespace xadrez.Table
{
    class PlaceChessTable
    {

        public static void startMatch(ChessMatch match)
        {
            PlaceChessTable.placechess(match.GameTable);
            Console.WriteLine();
            showPrisonPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn :" + match.Turn);
            if (!match.Over)
            {
                Console.WriteLine("Waiting Play :" + match.Player);
                if (match.Check)
                {
                    Console.WriteLine("Check!");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("XequeMate");
                Console.WriteLine("Vencedor: " + match.Player);
                Console.ReadLine();
            }

        }

        public static void showPrisonPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            showConjunt(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            showConjunt(match.capturedPieces(Color.Black));
            Console.WriteLine();
        }

        public static void showConjunt(HashSet<Piece> conjunt)
        {
            Console.Write("[");
            foreach(Piece obj in conjunt)
            {
                Console.Write( obj + " ");
            }
            Console.Write("]");
        }
        public static void placechess(GameTable gametable)
        {

            for (int i = 0; i < gametable.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gametable.Columns; j++)
                {
                    printPiece(gametable.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");

        }
        public static void placechess(GameTable gametable, bool[,] possiblemoves)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor backgroundMove = ConsoleColor.DarkGray;
            for (int i = 0; i < gametable.Columns; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gametable.Lines; j++)
                {
                    if (possiblemoves[i, j])
                    {
                        Console.BackgroundColor = backgroundMove;
                    }
                    else
                    {
                        Console.BackgroundColor = background;
                    }
                    printPiece(gametable.piece(i, j));
                    Console.BackgroundColor = background;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H ");
            Console.BackgroundColor = background;
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
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
                Console.Write(" ");
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
