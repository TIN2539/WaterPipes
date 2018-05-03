using System;

namespace WaterPipes
{
	internal class Spacebar : Command
	{
		private Game game;

		public Spacebar(Game game) : base(ConsoleKey.Spacebar)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			do
			{
				game.Play();
			} while (game.IsGameOver == false);
			return base.Execute();
		}
	}
}