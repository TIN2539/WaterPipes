using System;

namespace WaterPipes
{
	internal class SCommand : Command
	{
		private Game game;

		public SCommand(Game game) : base(ConsoleKey.S)
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