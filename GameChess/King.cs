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
    }
}
