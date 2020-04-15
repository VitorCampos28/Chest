using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Horse : Piece
    {
        public Horse (GameTable tab, Color cor) : base(cor, tab)
        {

        }
        private bool canMove(Position pos)
        {
            Piece P = GameTable.piece(pos);
            return P == null || P.Color != Color;
        }


        public override bool[,] MovePiece()
        {
            bool[,] mat = new bool[GameTable.Lines, GameTable.Columns];
            Position pos = new Position(0, 0);
            //NE
            pos.changePosition(Position.Line - 2, Position.Column + 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //NW
            pos.changePosition(Position.Line - 2, Position.Column - 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            //SE
            pos.changePosition(Position.Line + 2, Position.Column + 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //SW
            pos.changePosition(Position.Line + 2, Position.Column - 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //E
            pos.changePosition(Position.Line + 1, Position.Column + 2);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.changePosition(Position.Line - 1, Position.Column + 2);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //W
            pos.changePosition(Position.Line - 1, Position.Column - 2);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.changePosition(Position.Line +1, Position.Column - 2);

            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "H";
        }
    }
}