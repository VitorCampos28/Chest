
namespace xadrez.Table
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public GameTable GameTable { get; set; }
        public int Moves { get; protected set; }

        public Piece( Color color, GameTable gameTable)
        {
            Position = null;
            Color = color;
            GameTable = gameTable;
            Moves = 0;
        }

        public void incrementMove()
        {
            Moves++;
        }

        public abstract bool[,] MovePiece();
    }
}
