using System;

namespace WaterPipes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();
			game.GetField().Paint();
			do
			{
				game.Update();
			} while (!game.IsKeyPressed(Console.ReadKey(true).Key));
		}
	}
}