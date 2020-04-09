using System;

namespace xadrez.Table

{
    class GameTable
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private  Piece[,] Pieces { get; set; }

        public GameTable(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int line , int column)
        {
            return Pieces[line, column];
        }

    }
}
