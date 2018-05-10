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
			if (x - 1 >= 0 && !UserField.Cells[y, x - 1].IsEmpty && CheckCells(x - 1, y) ||
				x + 1 < UserField.Column && !UserField.Cells[y, x + 1].IsEmpty && CheckCells(x + 1, y) ||
				y - 1 >= 0 && !UserField.Cells[y - 1, x].IsEmpty && CheckCells(x, y - 1) ||
				y + 1 < UserField.Row && !UserField.Cells[y + 1, x].IsEmpty && CheckCells(x, y + 1))
			{
				check = true;
			}
			return check;
		}

		public bool CheckCells(int x, int y)
		{
			bool isSourceCell = false;
			if (!UserField.Cells[y, x].IsChecked)
			{
				UserField.Cells[y, x].IsChecked = true;
				if (UserField.Cells[y, x].Name == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (UserField.Cells[y, x].Name == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x, y);
				}
				UserField.Cells[y, x].IsChecked = false;
			}
			return isSourceCell;
		}

		public bool CheckEmptyPipe()
		{
			bool hasEmptyPipe = false;
			for (int i = 0; i < UserField.Row; i++)
			{
				for (int j = 0; j < UserField.Column; j++)
				{
					if (UserField.Cells[i, j].Name == PipeCell.pipeName && !UserField.Cells[i, j].HasWater)
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
			if (x - 1 >= 0 && !UserField.Cells[y, x - 1].IsEmpty)
			{
				isLeft = CheckCells(x - 1, y);
			}
			else
			{
				isLeft = true;
			}
			if (x + 1 < UserField.Column && !UserField.Cells[y, x + 1].IsEmpty)
			{
				isRight = CheckCells(x + 1, y);
			}
			else
			{
				isRight = true;
			}
			if (y - 1 >= 0 && !UserField.Cells[y - 1, x].IsEmpty)
			{
				isUp = CheckCells(x, y - 1);
			}
			else
			{
				isUp = true;
			}
			if (y + 1 < UserField.Row && !UserField.Cells[y + 1, x].IsEmpty)
			{
				isDown = CheckCells(x, y + 1);
			}
			else
			{
				isDown = true;
			}
			if (isRight && isLeft && isUp && isDown)
			{
				isPosibleDelete = true;
			}
			UserField.Cells[y, x].IsChecked = false;
			return isPosibleDelete;
		}

		public bool CheckNeighbor(int x, int y)
		{
			bool isCell = false;
			if (x >= 0 && x < UserField.Column && y >= 0 && y < UserField.Row && !UserField.Cells[y, x].IsEmpty)
			{
				isCell = true;
			}
			return isCell;
		}

		public bool CheckNeighbors(int x, int y)
		{
			bool hasNeighbour = false;
			for (int i = -1; i <= 1; i++)
			{
				if (i != 0)
				{
					if (CheckNeighbor(x + i, y) || CheckNeighbor(x, y + i))
					{
						hasNeighbour = true;
					}
				}
				if (hasNeighbour)
				{
					break;
				}
			}
			return hasNeighbour;
		}

		public void DoStep(int x, int y, Cell[,] cellForMakeChanges)
		{
			for (int i = -1; i <= 1; i++)
			{
				if (y + i >= 0 && y + i < UserField.Column && UserField.Cells[x, y + i].Name == PipeCell.pipeName
					&& !UserField.Cells[x, y + i].HasWater)
				{
					cellForMakeChanges[x, y + i].ChangeHasWater();
				}
				if (x + i >= 0 && x + i < UserField.Row && UserField.Cells[x + i, y].Name == PipeCell.pipeName
					&& !UserField.Cells[x + i, y].HasWater)
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