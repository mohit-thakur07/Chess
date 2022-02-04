using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public Piece[,] livePieces;
    public char[,] boardLayout;

    public List<Piece> liveWhitePieces;
    public List<Piece> liveBlackPieces;

    public Piece whiteKing, blackKing, selPiece, prevPieceMoved;

    public bool isWhiteTurn, whiteHasMove = true, blackHasMove = true;

    private Board()
    {
        livePieces = new Piece[8, 8];
        boardLayout = new char[8, 8];

        liveWhitePieces = new List<Piece>();
        liveBlackPieces = new List<Piece>();

        isWhiteTurn = true;
    }

    public void PlayTurn(ChessUiEngine uiEngine, int selX, int selY)
    {

        if ((selPiece.GetPieceType() == 'k' || selPiece.GetPieceType() == 'K') && System.Math.Abs(selPiece.GetY() - selY) > 1)
        {
            if (selY == 6)
            {
                livePieces[selX, selY + 1].MoveTo(selX, selY - 1);
                selPiece.MoveTo(selX, selY);
            }
            else
            {
                livePieces[selX, selY - 2].MoveTo(selX, selY + 1);
                selPiece.MoveTo(selX, selY);
            }
        }
        else if (selPiece.GetPieceType() == 'p' || selPiece.GetPieceType() == 'P')
        {
            if (System.Math.Abs(selPiece.GetX() - selX) > 1)
            {
                prevPieceMoved = selPiece;
            }
            else
            {
                if (selPiece.GetTeam())
                {
                    if (selX == 7)
                    {
                        Destroy(selPiece.gameObject);
                        liveWhitePieces.Remove(selPiece);

                        selPiece = GameObject.Instantiate(uiEngine.whitePiecePrefabs[1]).GetComponent<Piece>();

                        selPiece.SetPieceType('q');
                        selPiece.SetTeam(true);
                        liveWhitePieces.Add(selPiece);
                    }
                    else if (selPiece.GetX() == 4 && prevPieceMoved != null && System.Math.Abs(selPiece.GetY() - prevPieceMoved.GetY()) == 1)
                    {
                        Destroy(prevPieceMoved.gameObject);
                        boardLayout[prevPieceMoved.GetX(), prevPieceMoved.GetY()] = '-';
                        livePieces[prevPieceMoved.GetX(), prevPieceMoved.GetY()] = null;
                        
                        liveBlackPieces.Remove(prevPieceMoved);
                        prevPieceMoved = null;
                    }
                }
                else
                {
                    if (selX == 0)
                    {
                        Destroy(selPiece.gameObject);
                        liveBlackPieces.Remove(selPiece);

                        selPiece = GameObject.Instantiate(uiEngine.blackPiecePrefabs[1]).GetComponent<Piece>();

                        selPiece.SetPieceType('Q');
                        selPiece.SetTeam(false);
                        liveBlackPieces.Add(selPiece);
                    }
                    else if (selPiece.GetX() == 3 && prevPieceMoved != null && System.Math.Abs(selPiece.GetY() - prevPieceMoved.GetY()) == 1)
                    {
                        Destroy(prevPieceMoved.gameObject);
                        
                        boardLayout[prevPieceMoved.GetX(), prevPieceMoved.GetY()] = '-';
                        livePieces[prevPieceMoved.GetX(), prevPieceMoved.GetY()] = null;

                        liveWhitePieces.Remove(prevPieceMoved);
                        prevPieceMoved = null;
                    }
                }
            }

            selPiece.MoveTo(selX, selY);
        }
        else
        {
            selPiece.MoveTo(selX, selY);
        }

        whiteHasMove = blackHasMove = false;

        if (isWhiteTurn)
        {

            ((Piece_King)blackKing).SetHasCheck(CheckForCheck.CheckBoard(boardLayout, blackKing.GetX(), blackKing.GetY()));

            for (int i = 0; i < liveBlackPieces.Count; i++)
            {

                Piece piece = liveBlackPieces[i];

                if (piece != null)
                {
                    piece.CalPossibleMoves();

                    if (!blackHasMove)
                    {

                        for (int m = 0; m < 8; m++)
                        {
                            for (int n = 0; n < 8; n++)
                            {

                                if (piece.possibleMoves[m, n])
                                {
                                    blackHasMove = true;
                                    m = 8;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {

            ((Piece_King)whiteKing).SetHasCheck(CheckForCheck.CheckBoard(boardLayout, whiteKing.GetX(), whiteKing.GetY()));

            for (int i = 0; i < liveWhitePieces.Count; i++)
            {

                Piece piece = liveWhitePieces[i];

                if (piece != null)
                {
                    piece.CalPossibleMoves();

                    if (!whiteHasMove)
                    {

                        for (int m = 0; m < 8; m++)
                        {
                            for (int n = 0; n < 8; n++)
                            {

                                if (piece.possibleMoves[m, n])
                                {
                                    whiteHasMove = true;
                                    m = 8;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void ChangeTurn()
    {
        selPiece = null;
        isWhiteTurn = !isWhiteTurn;

        if (prevPieceMoved != null && prevPieceMoved.GetTeam() == isWhiteTurn)
        {
            prevPieceMoved = null;
        }
    }
}
