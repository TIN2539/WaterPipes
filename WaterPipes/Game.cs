using System;
using System.Collections.Generic;
using System.Threading;

namespace WaterPipes
{
	class Game
	{
		private List<ICommand> commands;
		private Cursor cursor;
		private int delay;
		private Field field;
		private Step step;

		public Game()
		{
			field = new Field(15, 30);
			cursor = new Cursor(field.GetLeftMost(), field.GetTopMost());
			delay = 400;
			step = new Step();
			commands = new List<ICommand>
			{
				new RightCommand(this),
				new LeftCommand(this),
				new UpCommand(this),
				new DownCommand(this),
				new EnterCommand(this),
				new SpacebarCommand(this),
				new SCommand(this),
				new DeleteCommand(this)
			};
		}

		public bool CheckCell(int x, int y)
		{
			bool check = false;
			if (CheckLeftCell(x, y) || CheckRightCell(x, y) || CheckUpCell(x, y) || CheckDownCell(x, y))
			{
				check = true;
			}
			return check;
		}

		public bool CheckEmptyPipe()
		{
			bool hasEmptyPipe = false;
			for (int i = 0; i < field.GetRow(); i++)
			{
				for (int j = 0; j < field.GetColumn(); j++)
				{
					if (field.GetCells()[i, j].GetName() == PipeCell.pipeName && field.GetCells()[i, j].GetHasWater() == false)
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

		public void DoStep(int x, int y, Cell[,] cellForMakeChanges)
		{
			for (int i = -1; i <= 1; i++)
			{
				if (y + i >= 0 && y + i < field.GetColumn() && field.GetCells()[x, y + i].GetName() == PipeCell.pipeName
					&& field.GetCells()[x, y + i].GetHasWater() == false)
				{
					cellForMakeChanges[x, y + i].ChangeHasWater();
				}
				if (x + i >= 0 && x + i < field.GetRow() && field.GetCells()[x + i, y].GetName() == PipeCell.pipeName
					&& field.GetCells()[x + i, y].GetHasWater() == false)
				{
					cellForMakeChanges[x + i, y].ChangeHasWater();
				}
			}
		}

		public Cursor GetCursor()
		{
			return cursor;
		}

		public Field GetField()
		{
			return field;
		}

		public bool IsGameOver()
		{
			bool isGameOver = true;
			if (CheckEmptyPipe())
			{
				isGameOver = false;
			}
			return isGameOver;
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
			Cell[,] cellForMakeChanges = new Cell[field.GetRow(), field.GetColumn()];
			for (int i = 0; i < field.GetRow(); i++)
			{
				for (int j = 0; j < field.GetColumn(); j++)
				{
					cellForMakeChanges[i, j] = new Cell(field.GetCells()[i, j].GetIsEmpty(), field.GetCells()[i, j].GetCharacterForCell(),
						field.GetCells()[i, j].GetHasWater(), field.GetCells()[i, j].GetColor(), field.GetCells()[i, j].GetName());
				}
			}
			for (int i = 0; i < field.GetRow(); i++)
			{
				for (int j = 0; j < field.GetColumn(); j++)
				{
					if (field.GetCells()[i, j].GetName() == SourceCell.sourceName || (field.GetCells()[i, j].GetName() == PipeCell.pipeName &&
						field.GetCells()[i, j].GetHasWater() == true))
					{
						DoStep(i, j, cellForMakeChanges);
					}
				}
			}

			field.SetCell(cellForMakeChanges);
			step.Paint();
			field.Update();
			Thread.Sleep(delay);
		}

		public void Update()
		{
			step.Paint();
			field.Update();
			cursor.ShowCursor();
		}

		internal bool CheckIsPosibleDelete(int x, int y)
		{
			bool isPosibleDelete = false;
			bool isLeft = false;
			bool isRight = false;
			bool isDown = false;
			bool isUp = false;
			field.GetCells()[y, x].SetIsChecked();
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
			field.GetCells()[y, x].ResetIsChecked();
			return isPosibleDelete;
		}

		internal bool CheckNeighbors(int x, int y)
		{
			bool hasNeighbor = false;
			if (CheckUpNeighbor(x, y) || CheckLeftNeighbor(x, y) || CheckDownNeighbor(x, y) || CheckRightNeighbor(x, y))
			{
				hasNeighbor = true;
			}
			return hasNeighbor;
		}

		private bool CheckDownCell(int x, int y)
		{
			bool isSourceCell = false;
			if (y + 1 < field.GetRow() && field.GetCells()[y + 1, x].GetIsCheckec() == false)
			{
				field.GetCells()[y + 1, x].SetIsChecked();
				if (field.GetCells()[y + 1, x].GetName() == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (field.GetCells()[y + 1, x].GetName() == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x, y + 1);
				}
				field.GetCells()[y + 1, x].ResetIsChecked();
			}
			return isSourceCell;
		}

		private bool CheckDownNeighbor(int x, int y)
		{
			bool isCell = false;
			if (y + 1 < field.GetRow() && field.GetCells()[y + 1, x].GetIsEmpty() == false)
			{
				isCell = true;
			}
			return isCell;
		}

		private bool CheckLeftCell(int x, int y)
		{
			bool isSourceCell = false;
			if (x - 1 >= 0 && field.GetCells()[y, x - 1].GetIsCheckec() == false)
			{
				field.GetCells()[y, x - 1].SetIsChecked();
				if (field.GetCells()[y, x - 1].GetName() == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (field.GetCells()[y, x - 1].GetName() == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x - 1, y);
				}
				field.GetCells()[y, x - 1].ResetIsChecked();

			}
			return isSourceCell;
		}

		private bool CheckLeftNeighbor(int x, int y)
		{
			bool isCell = false;
			if (x - 1 >= 0 && field.GetCells()[y, x - 1].GetIsEmpty() == false)
			{
				isCell = true;
			}
			return isCell;
		}

		private bool CheckRightCell(int x, int y)
		{
			bool isSourceCell = false;
			if (x + 1 < field.GetColumn() && field.GetCells()[y, x + 1].GetIsCheckec() == false)
			{
				field.GetCells()[y, x + 1].SetIsChecked();
				if (field.GetCells()[y, x + 1].GetName() == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (field.GetCells()[y, x + 1].GetName() == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x + 1, y);
				}
				field.GetCells()[y, x + 1].ResetIsChecked();

			}
			return isSourceCell;
		}

		private bool CheckRightNeighbor(int x, int y)
		{
			bool isCell = false;
			if (x + 1 < field.GetColumn() && field.GetCells()[y, x + 1].GetIsEmpty() == false)
			{
				isCell = true;
			}
			return isCell;
		}

		private bool CheckUpCell(int x, int y)
		{
			bool isSourceCell = false;
			if (y - 1 >= 0 && field.GetCells()[y - 1, x].GetIsCheckec() == false)
			{
				field.GetCells()[y - 1, x].SetIsChecked();
				if (field.GetCells()[y - 1, x].GetName() == SourceCell.sourceName)
				{
					isSourceCell = true;
				}
				else if (field.GetCells()[y - 1, x].GetName() == PipeCell.pipeName)
				{
					isSourceCell = CheckCell(x, y - 1);
				}
				field.GetCells()[y - 1, x].ResetIsChecked();

			}
			return isSourceCell;
		}

		private bool CheckUpNeighbor(int x, int y)
		{
			bool isCell = false;
			if (y - 1 >= 0 && field.GetCells()[y - 1, x].GetIsEmpty() == false)
			{
				isCell = true;
			}
			return isCell;
		}
	}
}