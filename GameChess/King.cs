using xadrez.Table;

namespace xadrez.GameChess
{
    class King : Piece
    {
        public King (GameTable tab , Color cor ) : base(cor , tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position pos)
        {
            Piece P = GameTable.piece(pos);
            return P == null || P.Color != Color;
        }
        public override bool[,] MovePiece()
        {
            bool[,] mat = new bool[GameTable.Lines, GameTable.Columns];
            Position pos = new Position(0,0);
            //UP
            pos.changePosition(Position.Line - 1, Position.Column);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //NE
            pos.changePosition(Position.Line - 1, Position.Column + 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //NW
            pos.changePosition(Position.Line - 1, Position.Column - 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Right
            pos.changePosition(Position.Line , Position.Column + 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Left
            pos.changePosition(Position.Line , Position.Column - 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //Sul
            pos.changePosition(Position.Line + 1, Position.Column );
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //SE
            pos.changePosition(Position.Line + 1, Position.Column + 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //SW
            pos.changePosition(Position.Line + 1, Position.Column - 1);
            if (GameTable.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }


    }
}
