using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
	public class Mines
	{
		
		static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = CreatePlayersBoard();
			char[,] bombs = PasteMines();
			int count = 0;
			bool stepOverMine = false;
			List<Scores> players = new List<Scores>(6);
			int row = 0;
			int col = 0;
			bool firstStart = true;
			const int maxCount = 35;
			bool lastTurn = false;

			do
			{
				if (firstStart)
				{
					Console.WriteLine("Let's play “Minesweeper”. Try your luck to find fields without mines." +
					" Command 'top'show Rating, 'restart' Start new Game, 'exit' Quit game!");
					DrawField(field);
					firstStart = false;
				}
				Console.Write("Give row and Col: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						rating(players);
						break;
					case "restart":
						field = CreatePlayersBoard();
						bombs = PasteMines();
						DrawField(field);
						stepOverMine = false;
						firstStart = false;
						break;
					case "exit":
						Console.WriteLine("Bay, Bay, Bay!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
								NextPlayerGo(field, bombs, row, col);
								count++;
							}
							if (maxCount == count)
							{
								lastTurn = true;
							}
							else
							{
								DrawField(field);
							}
						}
						else
						{
							stepOverMine = true;
						}
						break;
					default:
						Console.WriteLine("\nWrong Command!\n");
						break;
				}
				if (stepOverMine)
				{
					DrawField(bombs);
					Console.Write("\nDie with honor {0} points. " +
						"Enter NickName: ", count);
					string nickName = Console.ReadLine();
					Scores player = new Scores(nickName, count);
					if (players.Count < 5)
					{
						players.Add(player);
					}
					else
					{
						for (int i = 0; i < players.Count; i++)
						{
							if (players[i].Score < player.Score)
							{
								players.Insert(i, player);
								players.RemoveAt(players.Count - 1);
								break;
							}
						}
					}
					//players.Sort((Scores x, Scores y) => y.Name.CompareTo(x.Name));
					players.Sort((Scores x, Scores y) => y.Score.CompareTo(x.Score));
					rating(players);

					field = CreatePlayersBoard();
					bombs = PasteMines();
					count = 0;
					stepOverMine = false;
					firstStart = true;
				}
				if (lastTurn)
				{
					Console.WriteLine("\nCongratulation! You Win!.");
					DrawField(bombs);
					Console.WriteLine("Enter NickName: ");
					string nickName = Console.ReadLine();
					Scores player = new Scores(nickName, count);
					players.Add(player);
					rating(players);
					field = CreatePlayersBoard();
					bombs = PasteMines();
					count = 0;
					lastTurn = false;
					firstStart = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria!");
			Console.WriteLine("Play Again.");
			Console.Read();
		}

		private static void rating(List<Scores> players)
		{
			Console.WriteLine("\nPoints:");
			if (players.Count > 0)
			{
				for (int i = 0; i < players.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells",
						i + 1, players[i].Name, players[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty Rating!\n");
			}
		}

		private static void NextPlayerGo(char[,] field,
			char[,] mines, int row, int col)
		{
			char minesCount = numberOfMines(mines, row, col);
			mines[row, col] = minesCount;
			field[row, col] = minesCount;
		}

		private static void DrawField(char[,] board)
		{
			int row = board.GetLength(0);
			int col = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < row; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < col; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreatePlayersBoard()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PasteMines()
		{
			int row = 5;
			int col = 10;
			char[,] playersBoard = new char[row, col];

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					playersBoard[i, j] = '-';
				}
			}

			List<int> minesList = new List<int>();
			while (minesList.Count < 15)
			{
				Random random = new Random();
				int randomNumber = random.Next(50);
				if (!minesList.Contains(randomNumber))
				{
					minesList.Add(randomNumber);
				}
			}

			foreach (int mine in minesList)
			{
				int mineCol = (mine / col);
				int mineRow = (mine % col);
				if (mineRow == 0 && mine != 0)
				{
					mineCol--;
					mineRow = col;
				}
				else
				{
					mineRow++;
				}
				playersBoard[mineCol, mineRow - 1] = '*';
			}

			return playersBoard;
		}

		private static void CalculateSimbolOfBoard(char[,] pole)
		{
			int kol = pole.GetLength(0);
			int red = pole.GetLength(1);

			for (int i = 0; i < kol; i++)
			{
				for (int j = 0; j < red; j++)
				{
					if (pole[i, j] != '*')
					{
						char simbol = numberOfMines(pole, i, j);
						pole[i, j] = simbol;
					}
				}
			}
		}

		private static char numberOfMines(char[,] playersBoard, int row, int col)
		{
			int count = 0;
			int rows = playersBoard.GetLength(0);
			int cols = playersBoard.GetLength(1);

			if (row - 1 >= 0)
			{
				if (playersBoard[row - 1, col] == '*')
				{ 
					count++; 
				}
			}
			if (row + 1 < rows)
			{
				if (playersBoard[row + 1, col] == '*')
				{ 
					count++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (playersBoard[row, col - 1] == '*')
				{ 
					count++;
				}
			}
			if (col + 1 < cols)
			{
				if (playersBoard[row, col + 1] == '*')
				{ 
					count++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (playersBoard[row - 1, col - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (playersBoard[row - 1, col + 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (playersBoard[row + 1, col - 1] == '*')
				{ 
					count++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (playersBoard[row + 1, col + 1] == '*')
				{ 
					count++; 
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
