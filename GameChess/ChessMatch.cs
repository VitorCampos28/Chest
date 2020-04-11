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
            GameTable.placePiece(new Tower(GameTable, Color.Black), new ChessPosition('c', 2).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.Black), new ChessPosition('d', 2).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.Black), new ChessPosition('e', 2).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.Black), new ChessPosition('e', 1).toChessPosition());
            GameTable.placePiece(new King(GameTable, Color.Black), new ChessPosition('d', 1).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.White), new ChessPosition('c', 8).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.White), new ChessPosition('c', 7).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.White), new ChessPosition('d', 7).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.White), new ChessPosition('e', 7).toChessPosition());
            GameTable.placePiece(new Tower(GameTable, Color.White), new ChessPosition('e', 8).toChessPosition());
            GameTable.placePiece(new King(GameTable, Color.White), new ChessPosition('d', 8).toChessPosition());
        }
    }
}
