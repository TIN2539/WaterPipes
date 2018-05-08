using System;

namespace WaterPipes
{
	internal class Cell
	{
		public Cell()
		{
		}

		public Cell(bool isEmpty, char characterForCell, bool hasWater, ConsoleColor colorForCharacter, string name)
		{
			IsEmpty = isEmpty;
			CharacterForCell = characterForCell;
			ColorForCharacter = colorForCharacter;
			HasWater = hasWater;
			IsChecked = false;
			Name = name;
		}

		public char CharacterForCell { get; set; } = ' ';

		public ConsoleColor ColorForCharacter { get; set; } = ConsoleColor.Black;

		public bool HasWater { get; set; } = false;

		public bool IsChecked { get; set; } = false;

		public bool IsEmpty { get; set; } = true;

		public string Name { get;} = "Cell";

		public void ChangeHasWater()
		{
			HasWater = true;
			ColorForCharacter = ConsoleColor.Blue;
		}

		public void WriteCell(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = ColorForCharacter;
			Console.Write(CharacterForCell);
			Console.ResetColor();
		}
	}
}