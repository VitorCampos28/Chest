﻿
namespace xadrez.Table
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public GameTable GameTable { get; set; }


    }
}