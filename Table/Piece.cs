
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
        public void DecrementMove()
        {
            Moves--;
        }

        public bool possiblemoves()
        {
            bool[,] math = MovePiece();
            for (int i = 0; i < GameTable.Lines; i++)
            {
                for ( int j = 0; j < GameTable.Columns; j++)
                {
                    if (math[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleOverMove(Position pos)
        {
            return MovePiece()[pos.Line, pos.Column];
        }

        public abstract bool[,] MovePiece();
    }
}
