using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Pawn : Piece
    {
        public Pawn(GameTable tab, Color cor) : base(cor, tab)
        {

        }
        private bool IsEnemy(Position pos)
        {
            Piece P = GameTable.piece(pos);
            return P != null && P.Color != Color;
        }
        private bool free(Position pos)
        {
            return GameTable.piece(pos) == null;
        }

        public override bool[,] MovePiece()
        {
            bool[,] mat = new bool[GameTable.Lines, GameTable.Columns];
            Position pos = new Position(0, 0);
            //UP
            if (this.Color == Color.White)
            {
                pos.changePosition(Position.Line - 1, Position.Column);
                if (GameTable.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line - 2, Position.Column);
                if (GameTable.validPosition(pos) && free(pos) && Moves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line - 1, Position.Column - 1);
                if (GameTable.validPosition(pos) && IsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line - 1, Position.Column + 1);
                if (GameTable.validPosition(pos) && IsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

            }

            if (this.Color == Color.Black)
            {
                pos.changePosition(Position.Line + 1, Position.Column);
                if (GameTable.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line + 2, Position.Column);
                if (GameTable.validPosition(pos) && free(pos) && Moves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line + 1, Position.Column - 1);
                if (GameTable.validPosition(pos) && IsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.changePosition(Position.Line + 1, Position.Column + 1);
                if (GameTable.validPosition(pos) && IsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}