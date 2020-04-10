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
                GameTable table = new GameTable(8, 8);
                table.placePiece(new Tower(table, Color.Black), new Position(0, 0));
                table.placePiece(new Tower(table, Color.Black), new Position(0, 0));
                table.placePiece(new King(table, Color.Black), new Position(2, 4));
                PlaceChessTable.placechess(table);
            }

            catch(TableExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
