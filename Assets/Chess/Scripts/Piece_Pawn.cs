using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Pawn : Piece
{
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

        if (GetTeam())
        {
            if (currentX == 4 && board.prevPieceMoved != null && System.Math.Abs(currentY - board.prevPieceMoved.GetY()) == 1)
            {

                int prevY = board.prevPieceMoved.GetY();

                possibleMoves[5, prevY] = true;
                possibleMoves[5, prevY] = IsValidPos(5, prevY);
            }

            if (currentX == 1)
            {
                if (board.livePieces[currentX + 1, currentY] == null)
                {
                    possibleMoves[currentX + 1, currentY] = true;
                    possibleMoves[currentX + 1, currentY] = IsValidPos(currentX + 1, currentY);

                    if (board.livePieces[currentX + 2, currentY] == null)
                    {
                        possibleMoves[currentX + 2, currentY] = true;
                        possibleMoves[currentX + 2, currentY] = IsValidPos(currentX + 2, currentY);
                    }
                }
            }
            else if (currentX != 7 && board.livePieces[currentX + 1, currentY] == null)
            {
                possibleMoves[currentX + 1, currentY] = true;
                possibleMoves[currentX + 1, currentY] = IsValidPos(currentX + 1, currentY);
            }

            if (currentY != 0 && currentX != 7 && board.livePieces[currentX + 1, currentY - 1] != null)
            {
                if (!board.livePieces[currentX + 1, currentY - 1].GetTeam())
                {
                    possibleMoves[currentX + 1, currentY - 1] = true;
                    possibleMoves[currentX + 1, currentY - 1] = IsValidPos(currentX + 1, currentY - 1);
                }
            }

            if (currentY != 7 && currentX != 7 && board.livePieces[currentX + 1, currentY + 1] != null)
            {
                if (!board.livePieces[currentX + 1, currentY + 1].GetTeam())
                {
                    possibleMoves[currentX + 1, currentY + 1] = true;
                    possibleMoves[currentX + 1, currentY + 1] = IsValidPos(currentX + 1, currentY + 1);
                }
            }
        }
        else
        {
            if (currentX == 3 && board.prevPieceMoved != null && System.Math.Abs(currentY - board.prevPieceMoved.GetY()) == 1)
            {
                int prevY = board.prevPieceMoved.GetY();

                possibleMoves[2, prevY] = true;
                possibleMoves[2, prevY] = IsValidPos(2, prevY);
            }

            if (currentX == 6)
            {
                if (board.livePieces[currentX - 1, currentY] == null)
                {
                    possibleMoves[currentX - 1, currentY] = true;
                    possibleMoves[currentX - 1, currentY] = IsValidPos(currentX - 1, currentY);

                    if (board.livePieces[currentX - 2, currentY] == null)
                    {
                        possibleMoves[currentX - 2, currentY] = true;
                        possibleMoves[currentX - 2, currentY] = IsValidPos(currentX - 2, currentY);
                    }
                }
            }
            else if (currentX != 0 && board.livePieces[currentX - 1, currentY] == null)
            {
                possibleMoves[currentX - 1, currentY] = true;
                possibleMoves[currentX - 1, currentY] = IsValidPos(currentX - 1, currentY);
            }

            if (currentY != 0 && currentX != 0 && board.livePieces[currentX - 1, currentY - 1] != null)
            {
                if (board.livePieces[currentX - 1, currentY - 1].GetTeam())
                {
                    possibleMoves[currentX - 1, currentY - 1] = true;
                    possibleMoves[currentX - 1, currentY - 1] = IsValidPos(currentX - 1, currentY - 1);
                }
            }

            if (currentY != 7 && currentX != 0 && board.livePieces[currentX - 1, currentY + 1] != null)
            {
                if (board.livePieces[currentX - 1, currentY + 1].GetTeam())
                {
                    possibleMoves[currentX - 1, currentY + 1] = true;
                    possibleMoves[currentX - 1, currentY + 1] = IsValidPos(currentX - 1, currentY + 1);
                }
            }
        }

    }

}
