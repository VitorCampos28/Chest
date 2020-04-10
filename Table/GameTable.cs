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

        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool alreadyHavePiece(Position pos)
        {
            
            validPosition(pos);
            return piece(pos) != null;

        }
        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }
        public void placePiece(Piece p , Position pos)
        {
            if (alreadyHavePiece(pos))
            {
                throw new TableExceptions("Already have piece");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line>=Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                throw new TableExceptions("Invalid position! ");
            }
            return true;
        }



    }
}
