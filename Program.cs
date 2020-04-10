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
                GameTable tab = new GameTable(8, 8);

                tab.placePiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.placePiece(new Tower(tab, Color.Black), new Position(1, 3));
                tab.placePiece(new King(tab, Color.Black), new Position(0, 2));
                tab.placePiece(new King(tab, Color.White), new Position(3, 5));
                tab.placePiece(new Tower(tab, Color.White), new Position(2, 6));
                tab.placePiece(new Tower(tab, Color.White), new Position(3, 7));

                PlaceChessTable.placechess(tab);
            }

            catch (TableExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
