using xadrez.Table;
using System.Collections.Generic;
namespace xadrez.GameChess
{
    class ChessMatch
    {
        public GameTable GameTable { get; private set; }
        public int Turn { get; private set; }
        public Color Player { get; private set; }
        public bool Over { get; private set; }
        private HashSet<Piece> PiecesGame;
        private HashSet<Piece> PrisonPieces;

        public ChessMatch()
        {
            GameTable = new GameTable(8, 8);
            Turn = 1;
            Player = Color.White;
            Over = false;
            PiecesGame = new HashSet<Piece>();
            PrisonPieces = new HashSet<Piece>();
            placePieceInGame();            
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> x = new HashSet<Piece>();
            foreach (Piece obj in PrisonPieces)
            {
                if (obj.Color == color)
                {
                    x.Add(obj);
                }
            }
            return x;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> x = new HashSet<Piece>();
            foreach (Piece obj in PiecesGame)
            {
                if (obj.Color == color)
                {
                    x.Add(obj);
                }
            }
            x.ExceptWith(capturedPieces(color));
            return x;
        }

        public void changePosition(Position start , Position over)
        {
            Piece p = GameTable.removePiece(start);
            p.incrementMove();
            Piece prisonPiece = GameTable.removePiece(over);
            GameTable.placePiece(p, over);
            if (prisonPiece != null)
            {
                PrisonPieces.Add(prisonPiece);
            }
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

        public void placeNewPiece(char column , int line , Piece p)
        {
            GameTable.placePiece(p, new ChessPosition(column, line).toChessPosition());
            PiecesGame.Add(p);
        }

        private void placePieceInGame()
        {
            placeNewPiece('c', 1, new Tower(GameTable, Color.White));
            placeNewPiece('c' , 2 , new Tower(GameTable, Color.White));
            placeNewPiece('d' , 2 , new Tower(GameTable, Color.White));
            placeNewPiece('e' , 2 , new Tower(GameTable, Color.White));
            placeNewPiece('e' , 1, new Tower(GameTable, Color.White));
            placeNewPiece('d' , 1 , new King(GameTable, Color.White));
            placeNewPiece('d' , 8 , new King(GameTable, Color.Black));
            placeNewPiece('c' , 7 , new Tower(GameTable, Color.Black));
            placeNewPiece('d' , 7 , new Tower(GameTable, Color.Black));
            placeNewPiece('e' , 7 , new Tower(GameTable, Color.Black));
            placeNewPiece('e' , 8 , new Tower(GameTable, Color.Black));
            placeNewPiece('c', 8, new Tower(GameTable, Color.Black));
        }
    }
}
