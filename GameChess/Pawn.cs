using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Pawn : Piece
    {
        public Pawn(GameTable tab, Color cor) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "P";
        }
    }
}