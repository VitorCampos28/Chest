﻿using System;
using xadrez.Table;
namespace xadrez.GameChess
{
    class Queen : Piece
    {
        public Queen(GameTable tab, Color cor) : base(cor, tab)
        {

        }

        public override bool[,] MovePiece()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}