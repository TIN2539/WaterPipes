using System;

namespace WaterPipes
{
	internal class Cell
	{
		private char characterForCell;
		private ConsoleColor colorForCharacter;
		private bool hasWater;
		private bool isChecked;
		private bool isEmpty;
		private string name;

		public Cell()
		{
			isEmpty = true;
			characterForCell = ' ';
			colorForCharacter = ConsoleColor.Black;
			hasWater = false;
			isChecked = false;
			name = "Cell";
		}

		public Cell(bool isEmpty, char characterForCell, bool hasWater, ConsoleColor colorForCharacter, string name)
		{
			this.isEmpty = isEmpty;
			this.characterForCell = characterForCell;
			this.colorForCharacter = colorForCharacter;
			this.hasWater = hasWater;
			isChecked = false;
			this.name = name;
		}

		public virtual void WriteCell(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.ForegroundColor = colorForCharacter;
			Console.Write(characterForCell);
			Console.ResetColor();
		}

		public void ChangeHasWater()
		{
			hasWater = true;
			colorForCharacter = ConsoleColor.Blue;
		}

		public char GetCharacterForCell()
		{
			return characterForCell;
		}

		public ConsoleColor GetColor()
		{
			return colorForCharacter;
		}

		public bool GetHasWater()
		{
			return hasWater;
		}

		public bool GetIsCheckec()
		{
			return isChecked;
		}

		public bool GetIsEmpty()
		{
			return isEmpty;
		}

		public string GetName()
		{
			return name;
		}

		public void ResetIsChecked()
		{
			isChecked = false;
		}

		public void SetIsChecked()
		{
			isChecked = true;
		}
	}
}