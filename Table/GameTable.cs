namespace xadrez.Table
{
    class GameTable
    {
        public Piece[,] Pieces { get; set; }

        public GameTable()
        {

        }

        public void PrintTable(int line, int column )
        {
            for (int i = 0; i < line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < column; j++)
                {
                    Console.Write("- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

    }
}
