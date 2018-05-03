﻿using System;

namespace WaterPipes
{
	internal class S : Command
	{
		private Game game;

		public S(Game game) : base(ConsoleKey.S)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			game.UserField.Cells[game.UserCursor.CurrentY - game.UserField.TopMost, game.UserCursor.CurrentX - game.UserField.LeftMost] = new SourceCell();
			return base.Execute();
		}
	}
}