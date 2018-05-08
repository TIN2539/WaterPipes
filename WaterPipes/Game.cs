using System;
using System.Collections.Generic;
using System.Threading;

namespace WaterPipes
{
	internal class Game
	{
		private const int delay = 400;
		private List<ICommand> commands;
		private Step step = new Step();

		public Game()
		{
			UserCursor = new Cursor(UserField.LeftMost, UserField.TopMost);
			commands = new List<ICommand>
			{
				new RightCommand(this),
				new LeftCommand(this),
				new UpCommand(this),
				new DownCommand(this),
				new EnterCommand(this),
				new PlayCommand(this),
				new SourceCommand(this),
				new DeleteCommand(this)
			};
		}

		public bool IsGameOver
		{
			get { return !CheckEmptyPipe(); }
		}

		public Cursor UserCursor { get; internal set; }

		public Field UserField { get; internal set; } = new Field(15, 30);

		public bool CheckCell(int x, int y)
		{
			bool check = false;
			if (CheckLeftCell(x, y) || CheckRightCell(x, y) || CheckUpCell(x, y) || CheckDownCell(x, y))
			{
				check = true;
			}
			return check;
		}

		public bool CheckDownCell(int x, int y)
		{
			bool isSourceCell = false;
			if (y + 1 < UserField.Row && UserField.Cells[y + 1, x].IsChecked == false)
			{
				UserField.Cells[y + 1, x].IsChecked = true;
				if (UserField.Cells[y + 1, x].Name == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (UserField.Cells[y + 1, x].Name == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x, y + 1);
				}
				UserField.Cells[y + 1, x].IsChecked = false;
			}
			return isSourceCell;
		}

		public bool CheckDownNeighbor(int x, int y)
		{
			bool isCell = false;
			if (y + 1 < UserField.Row && UserField.Cells[y + 1, x].IsEmpty == false)
			{
				isCell = true;
			}
			return isCell;
		}

		public bool CheckEmptyPipe()
		{
			bool hasEmptyPipe = false;
			for (int i = 0; i < UserField.Row; i++)
			{
				for (int j = 0; j < UserField.Column; j++)
				{
					if (UserField.Cells[i, j].Name == PipeCell.pipeName && UserField.Cells[i, j].HasWater == false)
					{
						hasEmptyPipe = true;
						break;
					}
				}
				if (hasEmptyPipe)
				{
					break;
				}
			}
			return hasEmptyPipe;
		}

		public bool CheckIsPosibleDelete(int x, int y)
		{
			bool isPosibleDelete = false;
			bool isLeft = false;
			bool isRight = false;
			bool isDown = false;
			bool isUp = false;
			UserField.Cells[y, x].IsChecked = true;
			if (CheckLeftNeighbor(x, y))
			{
				isLeft = CheckLeftCell(x, y);
			}
			else
			{
				isLeft = true;
			}
			if (CheckRightNeighbor(x, y))
			{
				isRight = CheckRightCell(x, y);
			}
			else
			{
				isRight = true;
			}
			if (CheckDownNeighbor(x, y))
			{
				isDown = CheckDownCell(x, y);
			}
			else
			{
				isDown = true;
			}
			if (CheckUpNeighbor(x, y))
			{
				isUp = CheckUpCell(x, y);
			}
			else
			{
				isUp = true;
			}
			if (isRight && isLeft && isUp && isDown)
			{
				isPosibleDelete = true;
			}
			UserField.Cells[y, x].IsChecked = false;
			return isPosibleDelete;
		}

		public bool CheckLeftCell(int x, int y)
		{
			bool isSourceCell = false;
			if (x - 1 >= 0 && UserField.Cells[y, x - 1].IsChecked == false)
			{
				UserField.Cells[y, x - 1].IsChecked = true;
				if (UserField.Cells[y, x - 1].Name == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (UserField.Cells[y, x - 1].Name == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x - 1, y);
				}
				UserField.Cells[y, x - 1].IsChecked = false;

			}
			return isSourceCell;
		}

		public bool CheckLeftNeighbor(int x, int y)
		{
			bool isCell = false;
			if (x - 1 >= 0 && UserField.Cells[y, x - 1].IsEmpty == false)
			{
				isCell = true;
			}
			return isCell;
		}

		public bool CheckNeighbors(int x, int y)
		{
			bool hasNeighbor = false;
			if (CheckUpNeighbor(x, y) || CheckLeftNeighbor(x, y) || CheckDownNeighbor(x, y) || CheckRightNeighbor(x, y))
			{
				hasNeighbor = true;
			}
			return hasNeighbor;
		}

		public bool CheckRightCell(int x, int y)
		{
			bool isSourceCell = false;
			if (x + 1 < UserField.Column && UserField.Cells[y, x + 1].IsChecked == false)
			{
				UserField.Cells[y, x + 1].IsChecked = true;
				if (UserField.Cells[y, x + 1].Name == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (UserField.Cells[y, x + 1].Name == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x + 1, y);
				}
				UserField.Cells[y, x + 1].IsChecked = false;

			}
			return isSourceCell;
		}

		public bool CheckRightNeighbor(int x, int y)
		{
			bool isCell = false;
			if (x + 1 < UserField.Column && UserField.Cells[y, x + 1].IsEmpty == false)
			{
				isCell = true;
			}
			return isCell;
		}

		public bool CheckUpCell(int x, int y)
		{
			bool isSourceCell = false;
			if (y - 1 >= 0 && UserField.Cells[y - 1, x].IsChecked == false)
			{
				UserField.Cells[y - 1, x].IsChecked = true;
				if (UserField.Cells[y - 1, x].Name == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (UserField.Cells[y - 1, x].Name == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x, y - 1);
				}
				UserField.Cells[y - 1, x].IsChecked = false;

			}
			return isSourceCell;
		}

		public bool CheckUpNeighbor(int x, int y)
		{
			bool isCell = false;
			if (y - 1 >= 0 && UserField.Cells[y - 1, x].IsEmpty == false)
			{
				isCell = true;
			}
			return isCell;
		}

		public void DoStep(int x, int y, Cell[,] cellForMakeChanges)
		{
			for (int i = -1; i <= 1; i++)
			{
				if (y + i >= 0 && y + i < UserField.Column && UserField.Cells[x, y + i].Name == PipeCell.pipeName
					&& UserField.Cells[x, y + i].HasWater == false)
				{
					cellForMakeChanges[x, y + i].ChangeHasWater();
				}
				if (x + i >= 0 && x + i < UserField.Row && UserField.Cells[x + i, y].Name == PipeCell.pipeName
					&& UserField.Cells[x + i, y].HasWater == false)
				{
					cellForMakeChanges[x + i, y].ChangeHasWater();
				}
			}
		}

		public bool IsKeyPressed(ConsoleKey key)
		{
			bool isSpacebarPressed = false;
			foreach (ICommand command in commands)
			{
				if (command.CanExecute(key))
				{
					isSpacebarPressed = command.Execute();
					break;
				}
			}
			return isSpacebarPressed;
		}

		public void Play()
		{
			step.Update();
			step.Paint();
			Cell[,] cellForMakeChanges = new Cell[UserField.Row, UserField.Column];
			for (int i = 0; i < UserField.Row; i++)
			{
				for (int j = 0; j < UserField.Column; j++)
				{
					cellForMakeChanges[i, j] = new Cell(UserField.Cells[i, j].IsEmpty, UserField.Cells[i, j].CharacterForCell,
						UserField.Cells[i, j].HasWater, UserField.Cells[i, j].ColorForCharacter, UserField.Cells[i, j].Name);
				}
			}
			for (int i = 0; i < UserField.Row; i++)
			{
				for (int j = 0; j < UserField.Column; j++)
				{
					if (UserField.Cells[i, j].Name == SourceCell.sourceName || (UserField.Cells[i, j].Name == PipeCell.pipeName &&
						UserField.Cells[i, j].HasWater == true))
					{
						DoStep(i, j, cellForMakeChanges);
					}
				}
			}

			UserField.Cells = cellForMakeChanges;
			step.Paint();
			UserField.Update();
			Thread.Sleep(delay);
		}

		public void Update()
		{
			step.Paint();
			UserField.Update();
			UserCursor.ShowCursor();
		}
	}
}