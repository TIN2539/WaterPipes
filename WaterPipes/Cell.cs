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

		public char CharacterForCell { get; private set; } = ' ';

		public ConsoleColor ColorForCharacter { get; private set; } = ConsoleColor.Black;

		public bool HasWater { get; private set; }

		public bool IsChecked { get; set; }

		public bool IsEmpty { get; private set; } = true;

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