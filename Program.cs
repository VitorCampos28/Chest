using System;
using xadrez.Table;
using xadrez.GameChess;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Over)
                {
                    try
                    {
                        Console.Clear();
                        PlaceChessTable.placechess(match.GameTable);
                        Console.WriteLine();
                        Console.WriteLine("Turn :" + match.Turn);
                        Console.WriteLine("Waiting Play :" + match.Player);
                        Console.Write("Start: ");
                        Position start = PlaceChessTable.readChessPosition().toChessPosition();
                        match.validPosition(start);
                        bool[,] posibleMoves = match.GameTable.piece(start).MovePiece();
                        Console.Clear();
                        PlaceChessTable.placechess(match.GameTable, posibleMoves);
                        Console.Write("Over: ");
                        Position over = PlaceChessTable.readChessPosition().toChessPosition();
                        match.validoOverPosition(start , over);
                        match.makePlay(start, over);
                    }
                    catch (TableExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }

            catch (TableExceptions e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
