using xadrez.Table;
namespace xadrez.GameChess
{
    class ChessMatch
    {
        public GameTable GameTable { get; private set; }
        private int turn;
        private Color Player;
        public bool Over { get; private set; }

        public ChessMatch()
        {
            GameTable = new GameTable(8, 8);
            turn = 1;
            Player = Color.White;
            Over = false;
            placePieceInGame();            
        }

        public void changePosition(Position start , Position over)
        {
            Piece p = GameTable.removePiece(start);
            p.incrementMove();
            Piece prisonPiece = GameTable.removePiece(over);
            GameTable.placePiece(p, over);
        }

        private void placePieceInGame()
        {
            GameTable.placePiece(new Tower(GameTable, Color.Black), new ChessPosition('c', 1).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.Black), new Position(1, 3));
            GameTable.placePiece(new King(GameTable, Color.Black), new Position(0, 2));
            GameTable.placePiece(new King(GameTable, Color.White), new Position(3, 5));
            GameTable.placePiece(new Tower(GameTable, Color.White), new Position(2, 6));
            GameTable.placePiece(new Tower(GameTable, Color.White), new Position(3, 7));
        }
    }
}
