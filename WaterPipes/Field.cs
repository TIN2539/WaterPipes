using System;

namespace WaterPipes
{
	internal class Field
	{
		private const char characterForFrame = '+';
		private const int leftMost = 1;
		private const int topMost = 2;

		private Cell[,] cells;
		private int column;
		private int height;
		private int row;
		private int width;

		public Field(int row, int column)
		{
			this.column = column;
			this.row = row;
			width = column + 2; // +2 - поправка с учетом наличия нижней и верхней границ поля
			height = row + 2; // +2 - поправка с учетом наличия левой и правой границ поля
			cells = new Cell[row, column];
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					cells[i, j] = new Cell();
				}
			}
		}

		public Cell[,] GetCells()
		{
			return cells;
		}

		public int GetColumn()
		{
			return column;
		}

		public int GetLeftMost()
		{
			return leftMost;
		}

		public int GetRow()
		{
			return row;
		}

		public int GetTopMost()
		{
			return topMost;
		}

		public void Paint()
		{
			Console.CursorVisible = false;

			Console.SetCursorPosition(leftMost - 1, topMost - 1); // -1 -- сдвинуть курсор за пределы игрового поля для рисовки рамки
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write(characterForFrame);
						Console.ResetColor();
					}
					else
					{
						Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
					}
				}
				Console.WriteLine();
			}
		}

		public void SetCell(Cell[,] cells)
		{
			this.cells = cells;
		}

		public void Update()
		{
			Console.SetCursorPosition(leftMost, topMost);
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					cells[i, j].WriteCell(Console.CursorLeft, Console.CursorTop);
				}
				Console.SetCursorPosition(leftMost, topMost + i + 1); // +1 - перемещение курсора на 1 строку вниз
			}
		}
	}
}