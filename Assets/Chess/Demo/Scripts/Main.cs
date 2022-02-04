using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ChessUiEngine;

public class Main : MonoBehaviour {

	public ChessUiEngine uiEngine;

	public Text cell, gameOverText;
	public Transform brightSquare;
	public List<Transform> brightSquareNormalMoves;
	public List<Transform> brightSquareKillerMoves;
	public List<Transform> brightSquareSpecialMoves;
	private int count, countK, countS;
	int selectionX, selectionY;
	private bool isGameOver;
	Vector3 wCamPos, bCamPos;

	public Board board;
	// Use this for initialization
	void Start () {

		wCamPos = Camera.main.transform.position;
		bCamPos = new Vector3(-Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

		isGameOver = false;
		count = countK = countS = 0;
		selectionX = selectionY = -1;

		uiEngine.SetUpBoard(board);
	}

	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
		int cellNumber = uiEngine.RaycastCell (ray);
		if (isGameOver || !IsValidCell(cellNumber)) {
			return;
		}

		selectionX = cellNumber / 8;
		selectionY = cellNumber % 8;
		cell.text = ChessUiEngine.GetCellString(cellNumber);

		PlaceBrightSquare (cellNumber);

        if (Input.GetMouseButtonDown(0))
        {

			if (board.livePieces[selectionX, selectionY] != null
                && board.isWhiteTurn == board.livePieces[selectionX, selectionY].GetTeam())
            {
				board.selPiece = board.livePieces[selectionX, selectionY];

				bool flag = true;

				ResetAllSquares();

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (board.selPiece.possibleMoves[i, j])
						{
							flag = false;
							if ((board.selPiece.GetPieceType() == 'p'
                                || board.selPiece.GetPieceType() == 'P') && board.livePieces[i, j] == null)
							{
								if (board.isWhiteTurn)
								{
									if (board.selPiece.GetX() == 6)
									{
										PlaceSpecialSquare(i * 8 + j);
									}
									else if (board.selPiece.GetX() == 4 && j != board.selPiece.GetY())
									{
										PlaceSpecialSquare(i * 8 + j);
									}
									else
									{
										PlacePossibleMoveSquare(i * 8 + j);
									}
								}
								else
								{
									if (board.selPiece.GetX() == 1)
									{
										PlaceSpecialSquare(i * 8 + j);
									}
									else if (board.selPiece.GetX() == 3 && j != board.selPiece.GetY())
									{
										PlaceSpecialSquare(i * 8 + j);
									}
									else
									{
										PlacePossibleMoveSquare(i * 8 + j);
									}
								}
							}
							else if ((board.selPiece.GetPieceType() == 'k' || board.selPiece.GetPieceType() == 'K')
                                && System.Math.Abs(j - board.selPiece.GetY()) > 1)
							{
								PlaceSpecialSquare(i * 8 + j);
							}
							else
							{
								PlacePossibleMoveSquare(i * 8 + j);
							}

						}
					}

				}

				if (flag)
				{
					board.selPiece = null;
				}
			}
            else if(board.selPiece != null)
            {
				ResetAllSquares();

				if (board.selPiece.possibleMoves[selectionX, selectionY])
                {

					board.PlayTurn(uiEngine, selectionX, selectionY);
					board.ChangeTurn();
					ResetCheckSquare();

                    if (board.isWhiteTurn && ((Piece_King) board.whiteKing).GetHasCheck())
                    {
						PlaceCheckSquare(board.whiteKing.GetX() * 8 + board.whiteKing.GetY());

                        if (!board.whiteHasMove)
                        {
							Debug.Log("Black Wins!");
							gameOverText.text = "Black Wins!";
							isGameOver = true;
						}
                    } 
					else if (!board.isWhiteTurn && ((Piece_King)board.blackKing).GetHasCheck())
                    {
						PlaceCheckSquare(board.blackKing.GetX() * 8 + board.blackKing.GetY());

                        if (!board.blackHasMove)
                        {
							Debug.Log("White Wins!");
							gameOverText.text = "White Wins!";
							isGameOver = true;
						}
					}
					else if ((board.isWhiteTurn && !board.whiteHasMove) || (!board.isWhiteTurn && !board.blackHasMove))
                    {
						Debug.Log("Draw!");
						gameOverText.text = "Draw!";
						isGameOver = true;
					}

					RotateCamera();

					Debug.Log(board.liveWhitePieces.Count);
					Debug.Log(board.liveBlackPieces.Count);

					/*for (int i = 7; i >= 0; i--)
					{
						System.Diagnostics.Debug.Write((i + 1) +"[" + board.boardLayout[i, 0] + "]" +
							"[" + board.boardLayout[i, 1] + "]" +
							"[" + board.boardLayout[i, 2] + "]" +
							"[" + board.boardLayout[i, 3] + "]" +
							"[" + board.boardLayout[i, 4] + "]" +
							"[" + board.boardLayout[i, 5] + "]" +
							"[" + board.boardLayout[i, 6] + "]" +
							"[" + board.boardLayout[i, 7] + "]");
						
						System.Diagnostics.Debug.WriteLine("");
					}

					System.Diagnostics.Debug.WriteLine("  a  b  c  d  e  f  g  h");*/
				}
			}
		}
	}

	private void PlaceBrightSquare (int cellNumber)
	{
		brightSquare.position = ChessUiEngine.ToWorldPoint (cellNumber);
	}

	private void PlacePossibleMoveSquare(int cellNumber)
    {
		
		if (board.livePieces[cellNumber / 8, cellNumber % 8] == null) {

			brightSquareNormalMoves[count].position = ChessUiEngine.ToWorldPoint(cellNumber);
				count++;
		}
        else
        {
			brightSquareKillerMoves[countK].position = ChessUiEngine.ToWorldPoint(cellNumber);
			countK++;
		}
	}

	private void PlaceSpecialSquare(int cellNumber)
    {
		brightSquareSpecialMoves[countS].position = ChessUiEngine.ToWorldPoint(cellNumber);
		countS++;
	}

	private void PlaceCheckSquare(int cellNumber)
    {
		brightSquareKillerMoves[8].position = ChessUiEngine.ToWorldPoint(cellNumber);
	}

	private void ResetAllSquares()
    {
		count = countK = countS = 0;
        for (int i = 0; i < 27; i++)
        {
			brightSquareNormalMoves[i].position = brightSquareNormalMoves[i].parent.position;
		}

        for (int i = 0; i < 8; i++)
        {
			brightSquareKillerMoves[i].position = brightSquareKillerMoves[i].parent.position;
		}

		for (int i = 0; i < 2; i++)
		{
			brightSquareSpecialMoves[i].position = brightSquareSpecialMoves[i].parent.position;
		}
	}

    private void ResetCheckSquare()
    {
		brightSquareKillerMoves[8].position = brightSquareKillerMoves[8].parent.position;
	}

    private bool IsValidCell (int cellNumber)
	{
		return cellNumber >= 0 && cellNumber < 64;
	}

	private void RotateCamera()
    {
		Camera.main.transform.position = board.isWhiteTurn ? wCamPos : bCamPos;
		Vector3 to = new Vector3(board.isWhiteTurn ? 60 : 120, -90, board.isWhiteTurn ? 0 : 180);
		Camera.main.transform.eulerAngles = to;
	}
}
