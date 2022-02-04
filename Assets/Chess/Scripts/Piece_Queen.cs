using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Queen : Piece
{
    //calculates all the available moves for a piece
    //and validates it using IsValidPos() function
    public override void CalPossibleMoves()
    {
        int currentX = GetX();
        int currentY = GetY();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                possibleMoves[i, j] = false;
            }
        }

        for (int i = currentX + 1, j = currentY - 1; i < 8 && j >= 0; i++, j--)
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
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentX - 1, j = currentY + 1; i >= 0 && j < 8; i--, j++)
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
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentX - 1, j = currentY - 1; i >= 0 && j >= 0; i--, j--)
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
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = currentX + 1, j = currentY + 1; i < 8 && j < 8; i++, j++)
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
                    break;
                }
                else
                {
                    break;
                }
            }
        }

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
