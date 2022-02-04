using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    private int X;
    private int Y;

    private bool isWhite;
    private char pieceType;
	
    public bool[,] possibleMoves;

    public static Board board;

    public Piece()
    {

        X = Y = -1;
        possibleMoves = new bool[8, 8];
    }

    public int GetX()
    {
        return X;
    }

    public int GetY()
    {
        return Y;
    }

    public virtual void SetPos(int x, int y)
    {

        this.X = x;
        this.Y = y;

    }

    public bool GetTeam()
    {
        return isWhite;
    }

    public void SetTeam(bool col)
    {
        isWhite = col;
    }

    public void SetPieceType(char type)
    {
        pieceType = type;
    }

    public char GetPieceType()
    {
        return pieceType;
    }

    public static void SetBoard(Board board)
    {
        Piece.board = board;
    }

    //calculates all the available moves for a piece
    //and validates it using isValidPos() function
    public abstract void CalPossibleMoves();

    //checks whether if a available move wont result into
    //check to self king
    public bool IsValidPos(int x, int y)
    {
        bool flag;

        char prev = board.boardLayout[x, y];
        board.boardLayout[X, Y] = '-';
        board.boardLayout[x, y] = pieceType;

        if (isWhite)
        {
            if (pieceType != 'k')
            {
                flag = CheckForCheck.CheckBoard(board.boardLayout, board.whiteKing.GetX(), board.whiteKing.GetY());
            }
            else
            {
                flag = CheckForCheck.CheckBoard(board.boardLayout, x, y);
            }
        }
        else
        {
            if (pieceType != 'K')
            {
                flag = CheckForCheck.CheckBoard(board.boardLayout, board.blackKing.GetX(), board.blackKing.GetY());
            }
            else
            {
                flag = CheckForCheck.CheckBoard(board.boardLayout, x, y);
            }
        }

        board.boardLayout[X, Y] = pieceType;
        board.boardLayout[x, y] = prev;

        return !flag;
    }

    public void MoveTo(int x, int y)
    {

        if (this.X >= 0 && this.Y >= 0)
        {
            board.boardLayout[X, Y] = '-';
            board.livePieces[X, Y] = null;
        }

        SetPos(x, y);

        if (board.livePieces[x, y] != null)
        {
            //destroy the piece at (x, y) position in real time
            Destroy(board.livePieces[x, y].gameObject);

            if (board.isWhiteTurn)
            {
                board.liveBlackPieces.Remove(board.livePieces[x, y]);
            }
            else
            {
                board.liveWhitePieces.Remove(board.livePieces[x, y]);
            }
        }

        board.livePieces[x, y] = this;
        board.boardLayout[x, y] = pieceType;

        //move the piece in real time too

        Vector3 worldPoint = ChessUiEngine.ToWorldPoint((x * 8) + y);
        this.transform.position = new Vector3(worldPoint.x, this.transform.position.y, worldPoint.z);
    }
}

