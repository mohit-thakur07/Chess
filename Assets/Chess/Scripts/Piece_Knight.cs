using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Knight : Piece
{
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

        i = currentX + 2;
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

        i = currentX + 2;
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

        i = currentX - 2;
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

        i = currentX - 2;
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

        i = currentX + 1;
        j = currentY + 2;

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
        j = currentY - 2;

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
        j = currentY + 2;

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
        j = currentY - 2;

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
