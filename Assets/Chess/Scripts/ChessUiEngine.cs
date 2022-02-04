using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessUiEngine : MonoBehaviour {

	public List<Transform> whitePiecePrefabs;
	public List<Transform> blackPiecePrefabs;

	public int RaycastCell(Ray ray) {
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			Vector3 point = hit.point + new Vector3 (-16, 0, 16);
			int i = (int)-point.x / 4;
			int j = (int)point.z / 4;
			return i * 8 + j;
		}
		return -1;
	}

	public static string GetCellString (int cellNumber)
	{
		int j = cellNumber % 8;
		int i = cellNumber / 8;
		return char.ConvertFromUtf32 (j + 65) + "" + (i + 1);
	}

	public static Vector3 ToWorldPoint(int cellNumber) {
		int j = cellNumber % 8;
		int i = cellNumber / 8;
		return new Vector3 (i*-4+14, 1, j*4-14);
	}

	public void SetUpBoard(Board board)
	{

		Piece.board = board;

        for (int i = 0; i < 8; i++)
		{
            for (int j = 0; j < 8; j++)
            {
				board.boardLayout[i, j] = '-';

			}
        }

		Piece whitePiece;
		Piece blackPiece;
		Transform piece;

		for (int i = 0; i < 8; i++)
		{

			piece = GameObject.Instantiate(whitePiecePrefabs[5]);
			whitePiece = piece.GetComponent<Piece>();
			whitePiece.SetPos(-1, -1);
			whitePiece.SetTeam(true);
			whitePiece.SetPieceType('p');
			whitePiece.MoveTo(1, i);


			piece = GameObject.Instantiate(blackPiecePrefabs[5]);
			blackPiece = piece.GetComponent<Piece>();
			blackPiece.SetPos(-1, -1);
			blackPiece.SetTeam(false);
			blackPiece.SetPieceType('P');
			blackPiece.MoveTo(6, i);
		}

		for (int i = 0; i < 2; i++)
		{
			piece = GameObject.Instantiate(whitePiecePrefabs[4]);
			whitePiece = piece.GetComponent<Piece>();
			whitePiece.SetPos(-1, -1);
			whitePiece.SetTeam(true);
			whitePiece.SetPieceType('b');
			whitePiece.MoveTo(0, 2 + (i * 3));

			piece = GameObject.Instantiate(blackPiecePrefabs[4]);
			blackPiece = piece.GetComponent<Piece>();
			blackPiece.SetPos(-1, -1);
			blackPiece.SetTeam(false);
			blackPiece.SetPieceType('B');
			blackPiece.MoveTo(7, 2 + (i * 3));
		}

		for (int i = 0; i < 2; i++)
		{
			piece = GameObject.Instantiate(whitePiecePrefabs[3]);
			whitePiece = piece.GetComponent<Piece>();
			whitePiece.SetPos(-1, -1);
			whitePiece.SetTeam(true);
			whitePiece.SetPieceType('n');
			whitePiece.MoveTo(0, 1 + (i * 5));

			piece = GameObject.Instantiate(blackPiecePrefabs[3]);
			blackPiece = piece.GetComponent<Piece>();
			blackPiece.SetPos(-1, -1);
			blackPiece.SetTeam(false);
			blackPiece.SetPieceType('N');
			blackPiece.MoveTo(7, 1 + (i * 5));
		}

		for (int i = 0; i < 2; i++)
		{
			piece = GameObject.Instantiate(whitePiecePrefabs[2]);
			whitePiece = piece.GetComponent<Piece>();
			whitePiece.SetPos(-1, -1);
			whitePiece.SetTeam(true);
			whitePiece.SetPieceType('r');
			whitePiece.MoveTo(0, (i * 7));


			piece = GameObject.Instantiate(blackPiecePrefabs[2]);
			blackPiece = piece.GetComponent<Piece>();
			blackPiece.SetPos(-1, -1);
			blackPiece.SetTeam(false);
			blackPiece.SetPieceType('R');
			blackPiece.MoveTo(7, (i * 7));
		}

		piece = GameObject.Instantiate(whitePiecePrefabs[1]);
		whitePiece = piece.GetComponent<Piece>();
		whitePiece.SetPos(-1, -1);
		whitePiece.SetTeam(true);
		whitePiece.SetPieceType('q');
		whitePiece.MoveTo(0, 3);

		piece = GameObject.Instantiate(blackPiecePrefabs[1]);
		blackPiece = piece.GetComponent<Piece>();
		blackPiece.SetPos(-1, -1);
		blackPiece.SetTeam(false);
		blackPiece.SetPieceType('Q');
		blackPiece.MoveTo(7, 3);

		piece = GameObject.Instantiate(whitePiecePrefabs[0]);
		whitePiece = piece.GetComponent<Piece>();
		whitePiece.SetPos(-1, -1);
		whitePiece.SetTeam(true);
		whitePiece.SetPieceType('k');
		whitePiece.MoveTo(0, 4);

		piece = GameObject.Instantiate(blackPiecePrefabs[0]);
		blackPiece = piece.GetComponent<Piece>();
		blackPiece.SetPos(-1, -1);
		blackPiece.SetTeam(false);
		blackPiece.SetPieceType('K');
		blackPiece.MoveTo(7, 4);

		board.whiteKing = whitePiece;
		board.blackKing = blackPiece;

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (board.livePieces[i, j] != null)
				{
					if (board.livePieces[i, j].GetTeam())
					{
						board.liveWhitePieces.Add(board.livePieces[i, j]);
					}
					else
					{
						board.liveBlackPieces.Add(board.livePieces[i, j]);
					}
				}
			}
		}

		for (int i = 0; i < board.liveWhitePieces.Count; i++)
		{
			if (board.liveWhitePieces[i] != null)
			{
				board.liveWhitePieces[i].CalPossibleMoves();
			}
		}
	}
}
