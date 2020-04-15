using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Bishop : Piece
    {
        public Bishop(GameTable tab, Color cor) : base(cor, tab)
        {

        }

        private bool canMove(Position pos)
        {
            Piece P = GameTable.piece(pos);
            return P == null || P.Color != Color;
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovePiece()
        {
            bool[,] mat = new bool[GameTable.Lines, GameTable.Columns];
            Position pos = new Position(0, 0);
            //NE
            pos.changePosition(Position.Line - 1, Position.Column + 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.changePosition(pos.Line -1, pos.Column + 1 );
            }
            //NW
            pos.changePosition(Position.Line -1 , Position.Column - 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.changePosition(pos.Line - 1, pos.Column - 1);
            }

            //SE
            pos.changePosition(Position.Line + 1, Position.Column + 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.changePosition(pos.Line + 1, pos.Column + 1);
            }
            //SW
            pos.changePosition(Position.Line + 1, Position.Column - 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.changePosition(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}