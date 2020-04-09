using System;
using xadrez.Table;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            GameTable table = new GameTable();
            table.PrintTable(8, 8);
        }
    }
}
