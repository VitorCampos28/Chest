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
                    Console.Clear();
                    PlaceChessTable.placechess(match.GameTable);
                    Console.Write("Start: ");
                    Position start = PlaceChessTable.readChessPosition().toChessPosition();
                    Console.Write("Over: ");
                    Position over = PlaceChessTable.readChessPosition().toChessPosition();
                    match.changePosition(start, over);
                }

            }

            catch (TableExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
