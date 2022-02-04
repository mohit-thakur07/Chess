using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Rook : Piece
{
    private bool hasMoved = false;

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

    //calculates all the available moves for a piece
    //and validates it using IsValidPos() function
    public override void CalPossibleMoves()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                possibleMoves[i, j] = false;
            }
        }

        int currentX = GetX();
        int currentY = GetY();

        for (int i = currentY + 1; i < 8; i++)
        {
            if (board.livePieces[currentX, i] == null)
            {
                possibleMoves[currentX, i] = true;
                possibleMoves[currentX, i] = IsValidPos(currentX, i);
            }
            else if (board.livePieces[currentX, i] != null)
            {
                if (board.livePieces[currentX, i].GetTeam() != GetTeam())
                {
                    possibleMoves[currentX, i] = true;
                    possibleMoves[currentX, i] = IsValidPos(currentX, i);
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentY - 1; i >= 0; i--)
        {
            if (board.livePieces[currentX, i] == null)
            {
                possibleMoves[currentX, i] = true;
                possibleMoves[currentX, i] = IsValidPos(currentX, i);
            }
            else if (board.livePieces[currentX, i] != null)
            {
                if (board.livePieces[currentX, i].GetTeam() != GetTeam())
                {
                    possibleMoves[currentX, i] = true;
                    possibleMoves[currentX, i] = IsValidPos(currentX, i);
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentX + 1; i < 8; i++)
        {
            if (board.livePieces[i, currentY] == null)
            {
                possibleMoves[i, currentY] = true;
                possibleMoves[i, currentY] = IsValidPos(i, currentY);
            }
            else if (board.livePieces[i, currentY] != null)
            {
                if (board.livePieces[i, currentY].GetTeam() != GetTeam())
                {
                    possibleMoves[i, currentY] = true;
                    possibleMoves[i, currentY] = IsValidPos(i, currentY);
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentX - 1; i >= 0; i--)
        {
            if (board.livePieces[i, currentY] == null)
            {
                possibleMoves[i, currentY] = true;
                possibleMoves[i, currentY] = IsValidPos(i, currentY);
            }
            else if (board.livePieces[i, currentY] != null)
            {
                if (board.livePieces[i, currentY].GetTeam() != GetTeam())
                {
                    possibleMoves[i, currentY] = true;
                    possibleMoves[i, currentY] = IsValidPos(i, currentY);
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
