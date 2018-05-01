using System;

namespace WaterPipes
{
	internal class Cursor
	{
		private const char characterForCursor = 'X';
		private int currentX;
		private int currentY;

		public Cursor(int currentX, int currentY)
		{
			this.currentX = currentX;
			this.currentY = currentY;
		}

		public int DecrementX()
		{
			return --currentX;
		}

		public int DecrementY()
		{
			return --currentY;
		}

		public int GetCurrentX()
		{
			return currentX;
		}

		public int GetCurrentY()
		{
			return currentY;
		}

		public int IncrementX()
		{
			return ++currentX;
		}

		public int IncrementY()
		{
			return ++currentY;
		}

		public void ShowCursor()
		{
			Console.SetCursorPosition(currentX, currentY);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(characterForCursor);
			Console.ResetColor();
		}
	}
}