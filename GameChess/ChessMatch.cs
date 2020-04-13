using xadrez.Table;
namespace xadrez.GameChess
{
    class ChessMatch
    {
        public GameTable GameTable { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Over { get; private set; }

        public ChessMatch()
        {
            GameTable = new GameTable(8, 8);
            Turn = 1;
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

        public void validPosition(Position pos)
        {
            if (GameTable.piece(pos) == null)
            {
                throw new TableExceptions("Has no valid Piece");
            }
            if (Player != GameTable.piece(pos).Color)
            {
                throw new TableExceptions("Not is your turn ");
            }
            if (!GameTable.piece(pos).possiblemoves())
            {
                throw new TableExceptions("This piece is stuck");
            }
        }

        public void validoOverPosition(Position start , Position over )
        {
            if (!GameTable.piece(start).possibleOverMove(over))
            {
                throw new TableExceptions("Ivalid Movement");
            }
        }

        public void makePlay(Position start , Position over)
        {
            changePosition(start, over);
            Turn++;
            changePlayer();
        }

        private void changePlayer()
        {
            if (Player == Color.White)
            {
                Player = Color.Black;
            }
            else
            {
                Player = Color.White;
            }
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
