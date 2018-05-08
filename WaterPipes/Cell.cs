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

		public char CharacterForCell { get; internal set; } = ' ';

		public ConsoleColor ColorForCharacter { get; set; } = ConsoleColor.Black;

		public bool HasWater { get; internal set; }

		public bool IsChecked { get; internal set; }

		public bool IsEmpty { get; internal set; } = true;

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