using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Tower : Piece
    {
        public Tower(GameTable tab, Color cor) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
