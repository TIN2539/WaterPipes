using System;

namespace WaterPipes
{
	internal class Program
	{
		internal static void Main()
		{
			Game game = new Game();
			game.UserField.Paint();
			do
			{
				game.Update();
			} while (!game.IsKeyPressed(Console.ReadKey(true).Key));
		}
	}
}