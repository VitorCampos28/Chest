using System;

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

                    Console.Write( gametable.piece(i,j) + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A  B  C  D  E  F  G  H ");

        }
    }
}
