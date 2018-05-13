using System;

namespace WaterPipes
{
	internal class Field
	{
		private const char characterForFrame = '+';
		private int height;
		private int width;

		public Field(int row, int column)
		{
			Column = column;
			Row = row;
			width = column + 2; // +2 - поправка с учетом наличия нижней и верхней границ поля
			height = row + 2; // +2 - поправка с учетом наличия левой и правой границ поля
			Cells = new Cell[row, column];
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < column; j++)
				{
					Cells[i, j] = new Cell();
				}
			}
		}

		public Cell[,] Cells { get; internal set; }

		public int Column { get; internal set; }

		public int LeftMost { get; } = 1;

		public int Row { get; internal set; }

		public int TopMost { get; } = 2;

		public void Paint()
		{
			Console.CursorVisible = false;

			Console.SetCursorPosition(LeftMost - 1, TopMost - 1); // -1 -- сдвинуть курсор за пределы игрового поля для рисовки рамки
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

		public void Update()
		{
			Console.SetCursorPosition(LeftMost, TopMost);
			for (int i = 0; i < Row; i++)
			{
				for (int j = 0; j < Column; j++)
				{
					Cells[i, j].WriteCell(Console.CursorLeft, Console.CursorTop);
				}
				Console.SetCursorPosition(LeftMost, TopMost + i + 1); // +1 - перемещение курсора на 1 строку вниз
			}
		}
	}
}