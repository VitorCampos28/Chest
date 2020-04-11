using xadrez.Table;
namespace xadrez.GameChess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int  Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position toChessPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
