using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.Table
{
    class Piece
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Piece(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }
}
