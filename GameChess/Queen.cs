using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Queen : Piece
    {
        public Queen(GameTable tab, Color cor) : base(cor, tab)
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
            //UP
            pos.changePosition(Position.Line - 1, Position.Column);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            //Right
            pos.changePosition(Position.Line, Position.Column + 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //Left
            pos.changePosition(Position.Line, Position.Column - 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            //Sul
            pos.changePosition(Position.Line + 1, Position.Column);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //NE
            pos.changePosition(Position.Line - 1, Position.Column + 1);
            while (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (GameTable.piece(pos) != null && GameTable.piece(pos).Color != Color)
                {
                    break;
                }
                pos.changePosition(pos.Line - 1, pos.Column + 1);
            }
            //NW
            pos.changePosition(Position.Line - 1, Position.Column - 1);
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

        public override string ToString()
        {
            return "Q";
        }
    }
}