using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChessUiEngine;

public class CheckForCheck
{

    // Function to check if any of the two
    // kings is unsafe or not
    public static bool CheckBoard(char[,] board, int i, int j)
    {

        // Check for all pieces which
        // can attack White King
        if (board[i, j] == 'k')
        {

            // Check for Knight
            if (LookForn(board, 'N', i, j))
                return true;

            // Check for Pawn
            if (LookForp(board, 'P', i, j))
                return true;

            // Check for Rook
            if (LookForr(board, 'R', i, j))
                return true;

            // Check for Bishop
            if (LookForb(board, 'B', i, j))
                return true;

            // Check for Queen
            if (LookForq(board, 'Q', i, j))
                return true;

            // Check for King
            if (LookFork(board, 'K', i, j))
                return true;
        }

        // Check for all pieces which
        // can attack Black King
        else if (board[i, j] == 'K')
        {

            // Check for Knight
            if (LookForn(board, 'n', i, j))
                return true;

            // Check for Pawn
            if (LookForp(board, 'p', i, j))
                return true;

            // Check for Rook
            if (LookForr(board, 'r', i, j))
                return true;

            // Check for Bishop
            if (LookForb(board, 'b', i, j))
                return true;

            // Check for Queen
            if (LookForq(board, 'q', i, j))
                return true;

            // Check for King
            if (LookFork(board, 'k', i, j))
                return true;
        }
        
        return false;
    }

    private static bool LookFork(char[,] board,
                                 char c, int i,
                                 int j)
    {

        // Store all possible moves of the king
        int[] x = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] y = { -1, 0, 1, -1, 1, -1, 0, 1 };

        for (int k = 0; k < 8; k++)
        {

            // Incrementing index values
            int m = i + x[k];
            int n = j + y[k];

            // Checking boundary conditions
            // and character match
            if (InBounds(m, n) && board[m, n] == c)
                return true;
        }
        return false;
    }

    // Function to check if Queen can attack the King
    private static bool LookForq(char[,] board,
                                 char c, int i,
                                 int j)
    {

        // Queen's moves are a combination
        // of both the Bishop and the Rook
        if (LookForb(board, c, i, j) ||
            LookForr(board, c, i, j))
            return true;

        return false;
    }

    // Function to check if bishop can attack the king
    private static bool LookForb(char[,] board,
                                 char c, int i,
                                 int j)
    {

        // Check the lower right diagonal
        int k = 0;
        while (InBounds(i + ++k, j + k))
        {
            if (board[i + k, j + k] == c)
                return true;
            if (board[i + k, j + k] != '-')
                break;
        }

        // Check the lower left diagonal
        k = 0;
        while (InBounds(i + ++k, j - k))
        {
            if (board[i + k, j - k] == c)
                return true;
            if (board[i + k, j - k] != '-')
                break;
        }

        // Check the upper right diagonal
        k = 0;
        while (InBounds(i - ++k, j + k))
        {
            if (board[i - k, j + k] == c)
                return true;
            if (board[i - k, j + k] != '-')
                break;
        }

        // Check the upper left diagonal
        k = 0;
        while (InBounds(i - ++k, j - k))
        {
            if (board[i - k, j - k] == c)
                return true;
            if (board[i - k, j - k] != '-')
                break;
        }
        return false;
    }

    // Check if
    private static bool LookForr(char[,] board,
                                 char c, int i,
                                 int j)
    {

        // Check downwards
        int k = 0;
        while (InBounds(i + ++k, j))
        {
            if (board[i + k, j] == c)
                return true;
            if (board[i + k, j] != '-')
                break;
        }

        // Check upwards
        k = 0;
        while (InBounds(i + --k, j))
        {
            if (board[i + k, j] == c)
                return true;
            if (board[i + k, j] != '-')
                break;
        }

        // Check right
        k = 0;
        while (InBounds(i, j + ++k))
        {
            if (board[i, j + k] == c)
                return true;
            if (board[i, j + k] != '-')
                break;
        }

        // Check left
        k = 0;
        while (InBounds(i, j + --k))
        {
            if (board[i, j + k] == c)
                return true;
            if (board[i, j + k] != '-')
                break;
        }
        return false;
    }

    // Check if the knight can attack the king
    private static bool LookForn(char[,] board,
                                 char c, int i,
                                 int j)
    {

        // All possible moves of the knight
        int[] x = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] y = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int k = 0; k < 8; k++)
        {

            // Incrementing index values
            int m = i + x[k];
            int n = j + y[k];

            // Checking boundary conditions
            // and character match
            if (InBounds(m, n) && board[m, n] == c)
                return true;
        }
        return false;
    }

    // Function to check if pawn can attack the king
    private static bool LookForp(char[,] board,
                                 char c, int i,
                                 int j)
    {
        char LookFor;
        if (char.IsUpper(c))
        {

            // Check for white pawn
            LookFor = 'P';
            if (InBounds(i + 1, j - 1) &&
                   board[i + 1, j - 1] == LookFor)
                return true;

            if (InBounds(i + 1, j + 1) &&
                   board[i + 1, j + 1] == LookFor)
                return true;
        }
        else
        {

            // Check for black pawn
            LookFor = 'p';
            if (InBounds(i - 1, j - 1) &&
                   board[i - 1, j - 1] == LookFor)
                return true;
            if (InBounds(i - 1, j + 1) &&
                   board[i - 1, j + 1] == LookFor)
                return true;
        }
        return false;
    }

    // Check if the indices are within
    // the matrix or not
    private static bool InBounds(int i, int j)
    {

        // Checking boundary conditions
        return i >= 0 && i < 8 && j >= 0 && j < 8;
    }
}
