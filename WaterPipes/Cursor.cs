using System;

namespace WaterPipes
{
	internal class Cursor
	{
		private const char characterForCursor = 'X';

		public Cursor(int currentX, int currentY)
		{
			CurrentX = currentX;
			CurrentY = currentY;
		}

		public int CurrentX { get; internal set; }

		public int CurrentY { get; internal set; }

		public int DecrementX()
		{
			return --CurrentX;
		}

		public int DecrementY()
		{
			return --CurrentY;
		}

		public int IncrementX()
		{
			return ++CurrentX;
		}

		public int IncrementY()
		{
			return ++CurrentY;
		}

		public void ShowCursor()
		{
			Console.SetCursorPosition(CurrentX, CurrentY);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(characterForCursor);
			Console.ResetColor();
		}
	}
}