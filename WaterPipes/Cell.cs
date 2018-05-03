using System;

namespace WaterPipes
{
	internal class Cell
	{
		public Cell()
		{
			IsEmpty = true;
			CharacterForCell = ' ';
			ColorForCharacter = ConsoleColor.Black;
			HasWater = false;
			IsChecked = false;
			Name = "Cell";
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

		public char CharacterForCell { get; set; }

		public ConsoleColor ColorForCharacter { get; set; }

		public bool HasWater { get; set; }

		public bool IsChecked { get; set;}

		public bool IsEmpty { get; set; }

		public string Name { get; set; }

		public virtual void WriteCell(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = ColorForCharacter;
			Console.Write(CharacterForCell);
			Console.ResetColor();
		}

		public void ChangeHasWater()
		{
			HasWater = true;
			ColorForCharacter = ConsoleColor.Blue;
		}
	}
}