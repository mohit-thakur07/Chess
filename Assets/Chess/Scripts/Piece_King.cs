using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_King : Piece
{
    private bool hasMoved = false;
    private bool hasCheck = false;

    public override void SetPos(int x, int y)
    {

        if (!hasMoved && (GetX() != -1 && GetY() != -1))
        {
            hasMoved = true;
        }

        base.SetPos(x, y);

    }

    public bool HasPieceMoved()
    {
        return hasMoved;
    }

    public void SetHasCheck(bool check)
    {
        hasCheck = check;
    }

    public bool GetHasCheck()
    {
        return hasCheck;
    }

    //calculates all the available moves for a piece
    //and validates it using IsValidPos() function
    public override void CalPossibleMoves()
    {
        int i, j;

        int currentX = GetX();
        int currentY = GetY();

        for (i = 0; i < 8; i++)
        {
            for (j = 0; j < 8; j++)
            {
                possibleMoves[i, j] = false;
            }
        }

        //for castle
        if (!hasMoved)
        {
            if (GetTeam() && !hasCheck)
            {
                if (board.livePieces[0, 0] != null
                        && (board.livePieces[0, 1] == null && board.livePieces[0, 2] == null && board.livePieces[0, 3] == null)
                        && (board.livePieces[0, 0].GetTeam() && board.livePieces[0, 0].GetPieceType() == 'r'))
                {
                    if (!((Piece_Rook)board.livePieces[0, 0]).HasPieceMoved())
                    {
                        possibleMoves[0, 2] = true;
                        board.boardLayout[0, 0] = '-';
                        board.boardLayout[0, 3] = 'r';
                        possibleMoves[0, 2] = IsValidPos(0, 2);
                        board.boardLayout[0, 0] = 'r';
                        board.boardLayout[0, 3] = '-';
                    }
                }
                else if (board.livePieces[0, 7] != null
                      && (board.livePieces[0, 5] == null && board.livePieces[0, 6] == null)
                      && (board.livePieces[0, 7].GetTeam() && board.livePieces[0, 7].GetPieceType() == 'r'))
                {
                    if (!((Piece_Rook)board.livePieces[0, 7]).HasPieceMoved())
                    {
                        possibleMoves[0, 6] = true;
                        board.boardLayout[0, 7] = '-';
                        board.boardLayout[0, 5] = 'r';
                        possibleMoves[0, 6] = IsValidPos(0, 6);
                        board.boardLayout[0, 7] = 'r';
                        board.boardLayout[0, 5] = '-';
                    }
                }
            }
            else if (!GetTeam() && !hasCheck)
            {
                if (board.livePieces[7, 0] != null
                        && (board.livePieces[7, 1] == null && board.livePieces[7, 2] == null && board.livePieces[7, 3] == null)
                        && (!board.livePieces[7, 0].GetTeam() && board.livePieces[7, 0].GetPieceType() == 'R'))
                {
                    if (!((Piece_Rook)board.livePieces[7, 0]).HasPieceMoved())
                    {
                        possibleMoves[7, 2] = true;
                        board.boardLayout[7, 0] = '-';
                        board.boardLayout[7, 3] = 'R';
                        possibleMoves[7, 2] = IsValidPos(7, 2);
                        board.boardLayout[7, 0] = 'R';
                        board.boardLayout[7, 3] = '-';
                    }
                }
                else if (board.livePieces[7, 7] != null
                      && (board.livePieces[7, 5] == null && board.livePieces[7, 6] == null)
                      && (!board.livePieces[7, 7].GetTeam() && board.livePieces[7, 7].GetPieceType() == 'R'))
                {
                    if (!((Piece_Rook)board.livePieces[7, 7]).HasPieceMoved())
                    {
                        possibleMoves[7, 6] = true;
                        board.boardLayout[7, 7] = '-';
                        board.boardLayout[7, 5] = 'R';
                        possibleMoves[7, 6] = IsValidPos(7, 6);
                        board.boardLayout[7, 7] = 'R';
                        board.boardLayout[7, 5] = '-';
                    }
                }
            }
        }

        i = currentX + 1;
        j = currentY + 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX + 1;
        j = currentY - 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX - 1;
        j = currentY + 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX - 1;
        j = currentY - 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX;
        j = currentY + 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX;
        j = currentY - 1;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX - 1;
        j = currentY;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }

        i = currentX + 1;
        j = currentY;

        if (((i >= 0 && i < 8) && (j >= 0 && j < 8)))
        {
            if (board.livePieces[i, j] == null)
            {
                possibleMoves[i, j] = true;
                possibleMoves[i, j] = IsValidPos(i, j);
            }
            else if (board.livePieces[i, j] != null)
            {
                if (board.livePieces[i, j].GetTeam() != GetTeam())
                {
                    possibleMoves[i, j] = true;
                    possibleMoves[i, j] = IsValidPos(i, j);
                }
            }
        }
    }
}
