using System;
using xadrez.Table;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            GameTable table = new GameTable(8,8);
            PlaceChessTable.placechess(table);
        }
    }
}
