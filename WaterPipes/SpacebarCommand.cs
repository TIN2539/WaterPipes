﻿using System;

namespace WaterPipes
{
	internal class SpacebarCommand : Command
	{
		private Game game;

		public SpacebarCommand(Game game) : base(ConsoleKey.Spacebar)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			do
			{
				game.Play();
			} while (game.IsGameOver() == false);
			return base.Execute();
		}
	}
}