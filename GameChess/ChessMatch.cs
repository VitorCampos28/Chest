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

        public bool Check { get; private set; }

        public ChessMatch()
        {
            GameTable = new GameTable(8, 8);
            Turn = 1;
            Player = Color.White;
            Over = false;
            Check = false;
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

        public Piece  changePosition(Position start , Position over)
        {
            Piece p = GameTable.removePiece(start);
            p.incrementMove();
            Piece prisonPiece = GameTable.removePiece(over);
            GameTable.placePiece(p, over);
            if (prisonPiece != null)
            {
                PrisonPieces.Add(prisonPiece);
            }
            return prisonPiece;
        }

        public void cancelMoviment(Position start, Position over , Piece prisonPiece)
        {
            Piece p = GameTable.removePiece(over);
            p.DecrementMove();
            if (prisonPiece != null)
            {
                GameTable.placePiece(prisonPiece, over);
                PrisonPieces.Remove(prisonPiece);
            }
            GameTable.placePiece(p, start);
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
            Piece prisonPiece = changePosition(start, over);

            if (inCheck(Player))
            {
                cancelMoviment(start , over , prisonPiece);
                throw new TableExceptions("Your king is in check");
            }

            if (inCheck(enemy(Player)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (checkMate(enemy(Player)))
            {
                Over = true;
            }
            else
            {
                Turn++;
                changePlayer();
            }
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

        private Color enemy (Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king (Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if ( x is King)
                {
                    return x;
                }
            }
            return null; 
        }

        public bool inCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new TableExceptions("Dont have a " + color + "king in table");
            }
            foreach (Piece x in piecesInGame(enemy(color)))
            {
                bool[,] mat = x.MovePiece();
                if (mat[K.Position.Line , K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkMate(Color color)
        {
            if (!inCheck(color))
            {
                return false;
            }

            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.MovePiece();
                for (int i = 0; i < GameTable.Lines; i++)
                {
                    for ( int j = 0; j < GameTable.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position start = x.Position;
                            Position over = new Position(i, j);
                            Piece prisonPiece = changePosition(start, over);
                            bool Check = inCheck(color);
                            cancelMoviment(start, over, prisonPiece);
                            if (!Check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void placePieceInGame()
        {
            placeNewPiece('a', 1, new Tower(GameTable, Color.White));
            placeNewPiece('b', 1, new Horse(GameTable, Color.White));
            placeNewPiece('c', 1, new Bishop(GameTable, Color.White));
            placeNewPiece('d', 1, new Queen(GameTable, Color.White));
            placeNewPiece('e', 1, new King(GameTable, Color.White));
            placeNewPiece('f', 1, new Bishop(GameTable, Color.White));
            placeNewPiece('g', 1, new Horse(GameTable, Color.White));
            placeNewPiece('h', 1, new Tower(GameTable, Color.White));
            placeNewPiece('a', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('b', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('c', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('d', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('e', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('f', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('g', 2, new Pawn(GameTable, Color.White));
            placeNewPiece('h', 2, new Pawn(GameTable, Color.White));

            placeNewPiece('a', 8, new Tower(GameTable, Color.White));
            placeNewPiece('b', 8, new Horse(GameTable, Color.White));
            placeNewPiece('c', 8, new Bishop(GameTable, Color.White));
            placeNewPiece('d', 8, new Queen(GameTable, Color.White));
            placeNewPiece('e', 8, new King(GameTable, Color.White));
            placeNewPiece('f', 8, new Bishop(GameTable, Color.White));
            placeNewPiece('g', 8, new Horse(GameTable, Color.White));
            placeNewPiece('h', 8, new Tower(GameTable, Color.White));
            placeNewPiece('a', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('b', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('c', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('d', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('e', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('f', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('g', 7, new Pawn(GameTable, Color.White));
            placeNewPiece('h', 7, new Pawn(GameTable, Color.White));
        }
    }
}
